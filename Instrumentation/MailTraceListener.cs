using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Instrumentation
{
    public class MailTraceListener : DefaultTraceListener
    {
        public override void Write(string message)
        {
            MailMessage email = new MailMessage();
            email.IsBodyHtml = true;
            email.Body = 
                "<p style='color:red; font-size: 14px'>" + message + "</p>";
            email.From = new MailAddress("trabalhoentra21@gmail.com");
            email.To.Add(new MailAddress("marcelo.bernart@gmail.com"));
            email.Subject = "ERRO CATASTRÓFICO";
            //email.Attachments.Add(new Attachment("img.png"));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("trabalhoentra21@gmail.com",
                                                     "csharp>java");
            try
            {
                smtp.Send(email);
            }
            catch
            {

            }
        }
    }
}
