using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAunonc
{
    class WeatherApi
    {
        public static void WeatherApis(string city, string personName, string email)
        {
            string api = "14e8d36413e9e544406e91c5fa203605";

            string param = "&units=metric";

            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + param + "&appid=" + api;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            WResponse wresponse = JsonConvert.DeserializeObject<WResponse>(response);
            string fullMessage = "Температура для пользователя " + personName + " в городе " + wresponse.Name + ": " + wresponse.Main.Temp + " C";
            MailConnect.MailConnects(personName, fullMessage, email);
        }
    }
}
