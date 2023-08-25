
using System.Net;
using System.Net.Mail;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Models;
using MailKit.Security;

namespace NDDTraining.Infra.Services
{
    public class EmailService: IEmailService
    {
        
        public void BuildAndSendMail(Email email)
        {
            string templateName = "";

            switch (email.type)
            {
                case Domain.Enums.EmailType.Registration:
                    templateName = "Registration.html";
                    break;
                case Domain.Enums.EmailType.ResetPassword:
                    templateName = "ResetPassword.html";
                    break;
                default:
                    break;
            }

            var body = GetEmailTemplateByName(templateName);           
            body = ReplaceParameters(body, email.Parameters);
            SendEmail(email.To, email.Subject, body);

        }

        private void SendEmail( string To, string subject, string body)
        {
           

            MailMessage email = new MailMessage();           

            email.From = new MailAddress("rebekah.swaniawski66@ethereal.email");

            email.To.Add(new MailAddress(To));

            email.Subject = subject;

            email.Body = body;            

            email.IsBodyHtml = true;

            email.Priority = MailPriority.Normal;

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587);
            smtp.Authenticate("rebekah.swaniawski66@ethereal.email", "ktpB8RfAuCEN8Gb5Xj");
           

            // SmtpClient smtp = new SmtpClient("in-v3.mailjet.com",587);

            //smtp.EnableSsl = false;

          //  smtp.Credentials = new NetworkCredential("1caa0c71f61d336725763c57b12cdcf9", "b61d9c5fa8357384ef44e76c19d32298");

           // smtp.Credentials = new NetworkCredential();

            try
            {
                smtp.Send((MimeKit.MimeMessage)email);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",  ex.ToString());
            }
        }




        private string GetEmailTemplateByName(string templateName)
        {
            FileStream fileStream = new FileStream($"../NDDTraining.Infra/Templates/{templateName}", FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                return reader.ReadToEnd();
            }
        }


        
        private string ReplaceParameters(string template, IDictionary<string, string> parameters)
        {
            foreach (var param in parameters)
            {
                if (!template.Contains("{{"))
                    break;
                template = template.Replace("{{" + param.Key + "}}", param.Value);
            }
            return template;
        }
    }
}