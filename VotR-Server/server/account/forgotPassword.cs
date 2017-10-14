using System;
using System.Collections.Specialized;
using Anna.Request;
using common;
using log4net;
using SendGrid.Helpers.Mail;

namespace server.account
{
    class forgotPassword : RequestHandler
    {
        private static readonly ILog PassLog = LogManager.GetLogger("PassLog");

        public override void HandleRequest(RequestContext context, NameValueCollection query)
        {
            // get query
            var accEmail = query["guid"];

            // verify email exist
            DbAccount acc;
            var status = Database.Verify(accEmail, "", out acc);
            if (!Utils.IsValidEmail(accEmail) || status == LoginStatus.AccountNotExists)
            {
                Write(context, "<Error>Email not recognized</Error>");
                return;
            }
                
            string email = "admin@votrproject.com";
            string pass = "]ChjCKUiHzR1n";
          /*  try
            {
                SmtpClient client = new SmtpClient
                {
                    Host = "mail.privateemail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(email, pass),
                    Timeout = 10000,
                };
                MailMessage mm = new MailMessage(your_iD, "recepient@gmail.com", "Password Reset Protocol - Votr", "Please confirm that'd you like to reset your password for the associated email by replying!");
                client.Send(mm);
            }
            catch (Exception e)
            {
                Write(context, "<Error>Password could not be reset</Error>");
                PassLog.Warn($"Password could not reset requested. IP: {context.Request.ClientIP()}, Account: {acc.Name} ({acc.AccountId})");
                
            }*/

            
            Write(context, "<Success />");
            PassLog.Info($"Password reset requested. IP: {context.Request.ClientIP()}, Account: {acc.Name} ({acc.AccountId})");
        }
    }
}
