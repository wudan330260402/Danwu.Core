using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace Infrastructure.Utility
{
    /// <summary>
    /// 生成随机验证码类
    /// </summary>
    public class ValidateCode
    {
        private const String randomString = "23456789abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
        private const Int32 max_length = 56;

        private ValidateCode()
        {
            String randomNum = this.CreateRandomCode(6);
            byte[] data = CreateImage(randomNum);

            this.Text = randomNum;
            this.Data = data;
        }
        private ValidateCode(Int32 len)
        {
            String randomNum = this.CreateRandomCode(len);
            byte[] data = CreateImage(randomNum);

            this.Text = randomNum;
            this.Data = data;
        }

        public static ValidateCode Create()
        {
            return new ValidateCode();
        }
        public static ValidateCode Create(Int32 len)
        {
            return new ValidateCode(len);
        }


        /// <summary>
        /// 生成图片
        /// </summary>
        private byte[] CreateImage(String randomNum)
        {
            Bitmap bmap = new Bitmap(randomNum.Length * 16, 30);
            Graphics gs = Graphics.FromImage(bmap);
            gs.Clear(Color.White);

            //给生成的图片添加随即噪点
            int randNum1, randNum2;

            for (int i = 0; i < 200; i++)
            {
                randNum1 = new Random(i * DateTime.Now.Millisecond * 1000).Next(bmap.Width);
                randNum2 = new Random(i * DateTime.Now.Millisecond * 100).Next(bmap.Height);

                bmap.SetPixel(randNum1, randNum2, Color.Gray);
            }

            Font font=new Font("Arial",14,(FontStyle.Bold|FontStyle.Italic|FontStyle.Strikeout));
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, bmap.Width, bmap.Height), Color.Blue, Color.DarkRed, 1.2f, true);

            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            strFormat.LineAlignment = StringAlignment.Center;

            gs.DrawString(randomNum, font, brush, new Rectangle(0, 0, bmap.Width, bmap.Height), strFormat);

            MemoryStream stream = new MemoryStream();
            bmap.Save(stream, ImageFormat.Jpeg);
            return stream.ToArray();
        }

        /// <summary>
        /// 生成指定长度的随机数
        /// </summary>
        private String CreateRandomCode(Int32 len)
        {
            StringBuilder outputStr = new StringBuilder();
            for (var i = 0; i < len; i++)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                Int32 index = random.Next(1, max_length);
                outputStr.Append(randomString[index]);
            }

            return outputStr.ToString();
        }

        /// <summary>
        /// 生成随机颜色
        /// </summary>
        private Color CreateRandomColor()
        {
            Random random;
            Int32 int_red, int_green, int_blue;

            random = new Random(Guid.NewGuid().GetHashCode());
            int_red = random.Next(256);

            random = new Random(Guid.NewGuid().GetHashCode());
            int_green = random.Next(256);

            random = new Random(Guid.NewGuid().GetHashCode());
            int_blue = random.Next(256);

            return Color.FromArgb(int_red, int_green, int_blue);
        }


        public String Text
        {
            get;
            private set;
        }

        public byte[] Data
        {
            get;
            private set;
        }
    }
}
