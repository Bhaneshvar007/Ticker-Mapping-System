using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Cylsys.Common
{
    public class EmailActivity
    {
       static string email_template_path = ConfigurationManager.AppSettings["email_template_path"];
        public static bool SendEmail(EmailModel email_model, string AlertCategory)
        {
            try
            {
                string PrimaryMailServer = ConfigurationManager.AppSettings["SmtpPrimaryMailServer"];

                string SENDER_EMAIL = ConfigurationManager.AppSettings["SenderEmail"];
                string SENDER_PASS = ConfigurationManager.AppSettings["SenderPass"];
                int PORT = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                bool IsSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSsl"]);
                string[] AleartEmailIds = ConfigurationManager.AppSettings["AleartEmailIds"].Split(',');
                string[] report_mailids = ConfigurationManager.AppSettings["ReportEmailIds"].Split(',');
                string[] file_upload_success_mailids = ConfigurationManager.AppSettings["Uploadsuccess_EmailIds"].Split(',');

                

                SmtpClient smtpClient;
                smtpClient = new SmtpClient(PrimaryMailServer, PORT);
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                MailAddress mailAddress = new MailAddress(SENDER_EMAIL);
                message.Sender = mailAddress;
                message.From = mailAddress;

                switch (AlertCategory)
                {
                    case "REPORT":
                        {
                            message.Body = GetEmailBody(email_model);
                            message.Subject = "Polling Data As On [ " + email_model.file_name + " ]";

                            if (report_mailids != null)
                            {
                                for (int i = 0; i < report_mailids.Length; i++)
                                {
                                    message.To.Add(report_mailids[i]);
                                }
                            }

                            if (File.Exists(email_model.attached_file_location))
                            {
                                System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(email_model.attached_file_location);
                                message.Attachments.Add(attach);
                            }


                            break;
                        }
                    case "INSERT ERROR":
                        {
                            message.Body = GetEmailBody(email_model);
                            message.Subject = "Polling Data As On [ " + email_model.file_name + " ]";
                            if (AleartEmailIds != null)
                            {
                                for (int i = 0; i < AleartEmailIds.Length; i++)
                                {
                                    message.To.Add(AleartEmailIds[i]);
                                }
                            }
                            break;
                        }
                    case "UPLOAD SUCCESS":
                        {
                            message.Body = GetUploadSuccessEmailBody(email_model);
                            message.Subject = "File Uploaded";
                            if (AleartEmailIds != null)
                            {
                                for (int i = 0; i < AleartEmailIds.Length; i++)
                                {
                                    message.To.Add(AleartEmailIds[i]);
                                }
                            }
                            break;
                        }
                    case "POLLING DATA":
                        {
                            message.Body = GetEmailBody(email_model);
                            message.Subject = email_model.email_subject;

                            for (int i = 0; i < email_model.to_emailids.Count; i++)
                            {
                                message.To.Add(email_model.to_emailids[i]);
                            }
                            
                            for (int i = 0; i < email_model.cc_emailids.Count; i++)
                            {
                                message.CC.Add(email_model.cc_emailids[i]);
                            }

                            foreach (string flnm in email_model.attached_files)
                            {
                                if (File.Exists(flnm))
                                {
                                    try
                                    {
                                        System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(flnm);
                                        message.Attachments.Add(attach);
                                    }
                                    catch (Exception ex)
                                    {
                                        Helper.WriteLog("error while attaching file :" + ex.Message);
                                    }
                                }
                            }
                            break;
                        }
                }
                smtpClient.Send(message);
                smtpClient.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Helper.WriteLog("Sending Mail Failed : " + ex.Message);
                return false;
            }

        }

        public static string GetEmailBody(EmailModel email_model)
        {
            string emailBody = string.Empty;

            if (File.Exists(email_template_path + "\\" + "Email_reply.html"))
            {
                using (StreamReader reader = new StreamReader(email_template_path + "\\" + "Email_reply.html"))
                {
                    emailBody = reader.ReadToEnd();
                }
            }
            return emailBody;
        }
        public static string GetUploadSuccessEmailBody(EmailModel email_model)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang='en' xmlns='http://www.w3.org/1999/xhtml'>");
            sb.AppendLine("<head><title></title></head>");
            sb.AppendLine("<body>");
            sb.AppendLine("Dear Sir/Madam");
            sb.AppendLine("</br></br>");
            sb.AppendLine("The File <b>" + email_model.file_name + "</b> has been uploaded successfully !</br>");
            sb.AppendLine("</br></br></br>");
            sb.AppendLine("Thanks & Regards");
            sb.AppendLine("</br>");
            sb.AppendLine("This is a system generated mail.");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }
    }
}
