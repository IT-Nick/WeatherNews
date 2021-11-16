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

                using (MailMessage mm = new MailMessage(personName + " weatherinformation@mail.ru", email))
                {
                    mm.Subject = personName + ", оповещение о погоде";
                    mm.Body = message;
                    mm.IsBodyHtml = false;
                    using (SmtpClient sc = new SmtpClient("smtp.mail.ru", 25))
                    {
                        sc.EnableSsl = true;
                        sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                        sc.UseDefaultCredentials = false;
                        sc.Credentials = new NetworkCredential("weatherinformation@mail.ru", "7Yp8J9SBpVUr9Ey7MmaK");//J3M-pRQ-Rdt-S7c
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
