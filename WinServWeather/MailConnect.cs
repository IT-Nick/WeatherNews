using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace WeatherAunonc
{
    internal class MailConnect
    {
        public static void MailConnects(string personName, string message, string email)
        {
            try
            {

                using (MailMessage mm = new MailMessage(personName + " weatherinformation3@mail.ru", email))
                {
                    mm.Subject = personName + ", оповещение о погоде";
                    mm.Body = message;
                    mm.IsBodyHtml = false;
                    using (SmtpClient sc = new SmtpClient("smtp.mail.ru", 25))
                    {
                        sc.EnableSsl = true;
                        sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                        sc.UseDefaultCredentials = false;
                        sc.Credentials = new NetworkCredential("weatherinformation3@mail.ru", "zuabtbRLfYcuNAJsCDuY");//7Yp8J9SBpVUr9Ey7MmaK
                        sc.Send(mm);
                    }
                }

            }

            catch (SmtpException ex)
            {
                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
