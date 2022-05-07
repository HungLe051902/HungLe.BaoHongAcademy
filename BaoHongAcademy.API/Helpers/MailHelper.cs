using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BaoHongAcademy.API.Helpers
{
    public class MailHelper
    {
        public static async Task<string> SendMail(string _from, string _to, string _subject, string _content)
        {
            MailMessage message = new MailMessage(_from, _to, _subject, _content);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);

            using var smtpClient = new SmtpClient("localhost");

            try
            {
                await smtpClient.SendMailAsync(message);
                return "DONE";
            }
            catch (System.Exception e)
            {

                System.Console.WriteLine(e.Message);
                return "FAIL";
            }
        }

        public static async Task<string> SendGmail(string _from, string _to, string _subject, string _content, string _gmail, string _password)
        {
            MailMessage message = new MailMessage(_from, _to, _subject, _content);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);

            using var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_gmail, _password);

            try
            {
                await smtpClient.SendMailAsync(message);
                return "DONE";
            }
            catch (System.Exception e)
            {

                System.Console.WriteLine(e.Message);
                return "FAIL";
            }
        }
    }
}
