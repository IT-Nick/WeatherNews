using System.IO;
using System.ServiceProcess;

using System.Threading.Tasks;
using WeatherAunonc;

//Разработать службу, которая ежедневно (отправляет смс или другим способом уведомляет )
//пользователей о предстоящей погоде в некотором заданном городе.
//Время уведомления и телефоны пользователей и города пользователей задаются в настройках службы.;

namespace WinServWeather
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override async void OnStart(string[] args)
        {
            base.OnStart(args);

            string personName = args[0];

            string personCity = args[1];

            string personEmail = args[2];

            File.AppendAllText(@"C:\Users\lenovo\Desktop\sendlog.txt", "Service started,\n " + "высылаю сообщение по почте " + personEmail + " для " + personName + "...");
            while (true)
            {
                WeatherApi.WeatherApis(personCity, personName, personEmail);
                File.AppendAllText(@"C:\Users\lenovo\Desktop\sendlog.txt", "\nИнформация о погоде для " + personName + " ушла на почту " + personEmail);
                await Task.Delay(60000);
            }
        }
    }
}
