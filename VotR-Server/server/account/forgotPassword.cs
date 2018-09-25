using System;
using System.Collections.Specialized;
using Anna.Request;
using common;
using log4net;
using System.Net.Mail;
using System.Text;

namespace server.account
{
    class forgotPassword : RequestHandler
    {
        private static readonly ILog PassLog = LogManager.GetLogger("PassLog");

        string newPassword = "";

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
            string reply = "You account password on the email " + accEmail + " for Valor has been changed! Please use the randomly generated password below to login to your account and change the password to your liking." + Environment.NewLine + CreatePassword(12);

            string email = "support@valormg.com";
            string pass = "teameffort101!";
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "mail.privateemail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(email, pass);

                MailMessage mm = new MailMessage("support@valormg.com", accEmail, "Password Reset Protocol - Valor", reply);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
            }
            catch (Exception e)
            {
                Write(context, "<Error>Password could not be reset</Error>");
                throw (e);

            }
            Database.ChangePassword(query["guid"], newPassword);
            Write(context, "<Success/>");
        }


        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            newPassword = res.ToString();
            return res.ToString();
        }
    }
}
