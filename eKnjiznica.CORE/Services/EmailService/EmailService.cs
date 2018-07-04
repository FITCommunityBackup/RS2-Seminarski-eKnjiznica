using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Services.EmailService
{
 


    public class EmailService : IEmailService
    {
        public string EmailFrom { get; set; }
        public SmtpClient SmtpClient { get; set; }

        public async Task SendBooks(List<string> bookLocations,string to)
        {
            using (MailMessage objMailMessage = new MailMessage())
            {
                objMailMessage.From = new MailAddress(EmailFrom);
                objMailMessage.To.Add(new MailAddress(to));
                objMailMessage.Subject = "Knjige";

                bookLocations.ForEach(x => objMailMessage.Attachments.Add(new Attachment(AppDomain.CurrentDomain.BaseDirectory + "/" + x)));
                try
                {
                    await SmtpClient.SendMailAsync(objMailMessage);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
