using Newtonsoft.Json;
using System.Net;
using WeatherAunonc;

//Разработать службу, которая ежедневно (отправляет смс или другим способом уведомляет )
//пользователей о предстоящей погоде в некотором заданном городе.
//Время уведомления и телефоны пользователей и города пользователей задаются в настройках службы.

using System;

namespace WeatherAunonc
{

    class Program : WeatherApi
    {

        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            int counter = 0;

            while (true)
            {
                Console.WriteLine("Введите имя пользователя: ");
                //string personName = "Stepan";
                string? personName = Console.ReadLine();

                Console.WriteLine("Введите город, например: Moscow. \nГород: ");
                //string personEmail = "weatherinformation@mail.ru";
                string? personCity = Console.ReadLine();

                Console.WriteLine("Введите вашу почту для оповещений, " + personName + ": ");
                //string personCity = "Moscow";

                string? personEmail = Console.ReadLine();

                persons.Add(new Person() { Name = personName, Email = personEmail, City = personCity });


                Console.Write("Пользователи, включенные в рассылку: ");
                foreach (var i in persons)
                {
                    Console.Write("{0}, ", i.Name);
                }


                Thread t = new Thread(() => Thr(persons[counter].City, persons[counter].Name, persons[counter].Email));
                t.Start();

                Console.WriteLine("высылаю сообщение по почте " + persons[counter].Email + " для " + persons[counter].Name + "...");

                WeatherApis(persons[counter].City, persons[counter].Name, persons[counter].Email);
                counter++;
            }
            
        }

        public static void Thr(string city, string name, string email)
        {
            while (true)
            {
                Thread.Sleep(30000); //Соответственно можно поставить и 24 часа, для демонстрации выставил 30 секунд
                WeatherApis(city, name, email);
            }
        }
    }
}