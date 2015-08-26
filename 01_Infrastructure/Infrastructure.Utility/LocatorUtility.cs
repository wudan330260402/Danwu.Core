using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Infrastructure.Utility
{
    /// <summary>
    /// 定位
    /// </summary>
    public class LocatorUtility
    {
        private static String IP_DBFILE_PATH = @"qqwry.dat";
        private static String PHONE_DBFILE_PATH = @"MpData.dat";

        /// <summary>
        /// 根据IP地址获取位置信息
        /// </summary>
        /// <returns></returns>
        public static IpLocation QueryIpLocation(string ips)
        {
            if (!File.Exists(IP_DBFILE_PATH))
            {
                throw new Exception("文件不存在!");
            }
            FileStream fs = new FileStream(IP_DBFILE_PATH, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryReader fp = new BinaryReader(fs);
            //读文件头,获取首末记录偏移量
            int fo = fp.ReadInt32();
            int lo = fp.ReadInt32();
            //IP值
            uint ipv = IpStringToInt(ips);
            // 获取IP索引记录偏移值
            int rcOffset = getIndexOffset(fs, fp, fo, lo, ipv);
            fs.Seek(rcOffset, System.IO.SeekOrigin.Begin);

            IpLocation ipl;
            if (rcOffset >= 0)
            {
                fs.Seek(rcOffset, System.IO.SeekOrigin.Begin);
                //读取开头IP值
                ipl.IpStart = fp.ReadUInt32();
                //转到记录体
                fs.Seek(ReadInt24(fp), System.IO.SeekOrigin.Begin);
                //读取结尾IP值
                ipl.IpEnd = fp.ReadUInt32();
                ipl.Country = GetString(fs, fp);
                ipl.City = GetString(fs, fp);
            }
            else
            {
                //没找到
                ipl.IpStart = 0;
                ipl.IpEnd = 0;
                ipl.Country = "未知国家";
                ipl.City = "未知地址";
            }
            fp.Close();
            fs.Close();
            return ipl;
        }

        /// <summary>
        /// 根据手机号获取位置信息
        /// </summary>
        /// <returns></returns>
        public static PhoneLocation QueryPhoneLocation(int num)
        {
            if (!File.Exists(PHONE_DBFILE_PATH))
            {
                throw new Exception("文件不存在!");
            }
            FileStream fs = new FileStream(PHONE_DBFILE_PATH, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryReader fp = new BinaryReader(fs);

            //读文件头,获取首末记录偏移量
            int fo = fp.ReadInt32();
            int lo = fp.ReadInt32();
            int rcOffset = getIndexOffset(fs, fp, fo, lo, num);
            PhoneLocation mpl;
            if (rcOffset >= 0)
            {
                fs.Seek(rcOffset, System.IO.SeekOrigin.Begin);
                //读取号码段起始地址和结束地址
                mpl.NumStart = fp.ReadInt32();
                mpl.NumEnd = fp.ReadInt32();
                //如果查询的号码处于中间空段
                if (num > mpl.NumEnd)
                {
                    mpl.NumStart = 0; mpl.NumEnd = 0;
                    mpl.Location = "未知地址";
                }
                else
                {
                    //读取字符串偏移量,3字节!
                    int lstrOffset = ReadInt24(fp);
                    fs.Seek(lstrOffset, System.IO.SeekOrigin.Begin);
                    //读取归属地字符串
                    mpl.Location = ReadString(fp);
                }
            }
            else
            {
                //没找到记录
                mpl.NumStart = 0; mpl.NumEnd = 0;
                mpl.Location = "未知地址";
            }
            fp.Close();
            fs.Close();
            return mpl;
        }

        #region private methods

        //获取号码段记录在文件中的偏移量
        private static int getIndexOffset(FileStream fs, BinaryReader fp, int _fo, int _lo, int num)
        {
            int fo = _fo, lo = _lo;
            int mo;    //中间偏移量
            int mv;    //中间值
            int fv, lv; //边界值
            int llv;   //边界末末值
            fs.Seek(fo, System.IO.SeekOrigin.Begin);
            fv = fp.ReadInt32();
            fs.Seek(lo, System.IO.SeekOrigin.Begin);
            lv = fp.ReadInt32();
            llv = fp.ReadInt32();
            //边界检测处理
            if (num < fv)
                return -1;
            else if (num > llv)
                return -1;
            //使用"二分法"确定记录偏移量
            do
            {
                mo = fo + (lo - fo) / 11 / 2 * 11;
                fs.Seek(mo, System.IO.SeekOrigin.Begin);
                mv = fp.ReadInt32();
                if (num >= mv)
                    fo = mo;
                else
                    lo = mo;
                if (lo - fo == 11)
                    mo = lo = fo;
            } while (fo != lo);
            return mo;
        }

        // 函数功能: 采用“二分法”搜索索引区, 定位IP索引记录位置
        private static int getIndexOffset(FileStream fs, BinaryReader fp, int _fo, int _lo, uint ipv)
        {
            int fo = _fo, lo = _lo;
            int mo;    //中间偏移量
            uint mv;    //中间值
            uint fv, lv; //边界值
            uint llv;   //边界末末值
            fs.Seek(fo, System.IO.SeekOrigin.Begin);
            fv = fp.ReadUInt32();
            fs.Seek(lo, System.IO.SeekOrigin.Begin);
            lv = fp.ReadUInt32();
            //临时作它用,末记录体偏移量
            mo = ReadInt24(fp);
            fs.Seek(mo, System.IO.SeekOrigin.Begin);
            llv = fp.ReadUInt32();
            //边界检测处理
            if (ipv < fv)
                return -1;
            else if (ipv > llv)
                return -1;
            //使用"二分法"确定记录偏移量
            do
            {
                mo = fo + (lo - fo) / 7 / 2 * 7;
                fs.Seek(mo, System.IO.SeekOrigin.Begin);
                mv = fp.ReadUInt32();
                if (ipv >= mv)
                    fo = mo;
                else
                    lo = mo;
                if (lo - fo == 7)
                    mo = lo = fo;
            } while (fo != lo);
            return mo;
        }
        // 字符串数值型判断
        public static bool IsNumeric(string s)
        {
            if (s != null && System.Text.RegularExpressions.Regex.IsMatch(s, @"^-?\d+$"))
                return true;
            else
                return false;
        }
        // IP字符串->长整型值
        public static uint IpStringToInt(string IpString)
        {
            uint Ipv = 0;
            string[] IpStringArray = IpString.Split('.');
            int i;
            uint Ipi;
            for (i = 0; i < 4 && i < IpStringArray.Length; i++)
            {
                if (IsNumeric(IpStringArray[i]))
                {
                    Ipi = (uint)Math.Abs(Convert.ToInt32(IpStringArray[i]));
                    if (Ipi > 255) Ipi = 255;
                    Ipv += Ipi << (3 - i) * 8;
                }
            }
            return Ipv;
        }
        // 长整型值->IP字符串
        public static string IntToIpString(uint Ipv)
        {
            string IpString = "";
            IpString += (Ipv >> 24) + "." + ((Ipv & 0x00FF0000) >> 16) + "." + ((Ipv & 0x0000FF00) >> 8) + "." + (Ipv & 0x000000FF);
            return IpString;
        }
        // 读取字符串
        private static string ReadString(BinaryReader fp)
        {
            byte[] TempByteArray = new byte[128];
            int i = 0;
            do
            {
                TempByteArray[i] = fp.ReadByte();
            } while (TempByteArray[i++] != '\0' && i < 128);
            return System.Text.Encoding.Default.GetString(TempByteArray).TrimEnd('\0');
        }
        // 读取三字节的整数
        private static int ReadInt24(BinaryReader fp)
        {
            if (fp == null) return -1;
            int ret = 0;
            ret |= (int)fp.ReadByte();
            ret |= (int)fp.ReadByte() << 8 & 0xFF00;
            ret |= (int)fp.ReadByte() << 16 & 0xFF0000;
            return ret;
        }
        // 读取IP所在地字符串
        private static string GetString(FileStream fs, BinaryReader fp)
        {
            byte Tag;
            int Offset;
            Tag = fp.ReadByte();
            if (Tag == 0x01)		// 重定向模式1: 城市信息随国家信息定向
            {
                Offset = ReadInt24(fp);
                fs.Seek(Offset, System.IO.SeekOrigin.Begin);
                return GetString(fs, fp);
            }
            else if (Tag == 0x02)	// 重定向模式2: 城市信息没有随国家信息定向
            {
                Offset = ReadInt24(fp);
                int TmpOffset = (int)fs.Position;
                fs.Seek(Offset, System.IO.SeekOrigin.Begin);
                string TmpString = GetString(fs, fp);
                fs.Seek(TmpOffset, System.IO.SeekOrigin.Begin);
                return TmpString;
            }
            else	// 无重定向: 最简单模式
            {
                fs.Seek(-1, System.IO.SeekOrigin.Current);
                return ReadString(fp);
            }
        }

        #endregion
    }

    /// <summary>
    /// IP查询结果结构
    /// </summary>
    public struct IpLocation
    {
        public uint IpStart;
        public uint IpEnd;
        public string Country;
        public string City;

        public override string ToString()
        {
            return String.Format("IpStart:{0},IpEnd:{1},Country:{2},City:{3}", IpStart, IpEnd, Country, City);
        }
    }

    /// <summary>
    /// 手机号查询结果结构
    /// </summary>
    public struct PhoneLocation
    {
        public int NumStart;
        public int NumEnd;
        public string Location;

        public override string ToString()
        {
            return String.Format("NumStart:{0},NumEnd:{1},Location:{2}", NumStart, NumEnd, Location);
        }
    }
}
