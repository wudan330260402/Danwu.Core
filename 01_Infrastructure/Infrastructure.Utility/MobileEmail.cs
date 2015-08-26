using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Infrastructure.Utility
{
    public class MobileEmail
    {
        /// <summary>
        /// 给指定手机发送短信
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="content"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool SendMobileMessage(string mobile, string content, out string msg)
        {
            var url = "http://sms.shoptao.cn:30000/webservice/burgeonsmsservice.asmx/SendSMS3";

            IDictionary<string, string> dict = new Dictionary<string, string>();
            //dict.Add("userId", ConfigurationHelper.SmsUserName);
            //dict.Add("userPwd", ConfigurationHelper.SmsPassword);
            dict.Add("sendTime", null);
            dict.Add("mobiless", mobile);
            dict.Add("smsContent", content);
            dict.Add("addSerial", "");
            dict.Add("smstype", "");
            dict.Add("channel", "");
            dict.Add("format", "");
            msg = PostModel(url, dict);
            if (!string.IsNullOrEmpty(msg) && msg.IndexOf("成功") > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary> 
        /// 发送邮件
        /// </summary> 
        /// <param name="to">收件人邮件地址</param> 
        /// <param name="from">发件人邮件地址</param> 
        /// <param name="subject">邮件主题</param> 
        /// <param name="body">邮件内容</param> 
        /// <param name="username">登录smtp主机时用到的用户名,注意是邮件地址'@'以前的部分</param> 
        /// <param name="password">登录smtp主机时用到的用户密码</param> 
        /// <param name="smtpHost">发送邮件用到的smtp主机</param> 
        public static bool Send(string to, string from, string subject, string body, string username, string password, string smtpHost)
        {
            MailMessage myMail = new MailMessage(from, to, subject, body);
           
            myMail.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题的编码
            myMail. BodyEncoding= System.Text.Encoding.UTF8;//邮件内容的编码
            myMail.IsBodyHtml = true;//邮件的内容为Html格式
            SmtpClient client = new SmtpClient(smtpHost);//指定SMTP服务器
            client.Credentials = new NetworkCredential(username, password);//指定用户名和密码
            client.EnableSsl = false;//是否加密连接
            client.Send(myMail);//发送指定邮件
           
            return true;
        }
        public static string PostModel(string strUrl, IDictionary<string, string> parameters)
        {
            string str = "";
            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> pair in parameters)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        str = str + "&";
                    }
                    str = str + pair.Key;
                    str = str + "=";
                    str = str + pair.Value;
                }
            }
            return PostModel(strUrl, str);
        }
        public static string PostModel(string strUrl, string strParm)
        {
            Encoding encoding = Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(strParm);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), encoding);
            char[] buffer = new char[0x100];
            int length = reader.Read(buffer, 0, 0x100);
            string str = null;
            while (length > 0)
            {
                str = str + new string(buffer, 0, length);
                length = reader.Read(buffer, 0, 0x100);
            }
            reader.Close();
            response.Close();
            return str;
        }
        public static string lowEmail(string email)
        {
           string emailreg=@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
           if (Regex.IsMatch(email, emailreg))
           {
               return email.ToLower();

           }
           else {
               return email;
           }
        
        }
    }
}