using System;
using System.Collections.Generic;

namespace OOP7
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            bool isContinueCycle = true;
            int day = 0;

            while (isContinueCycle)
            {
                day++;
                Console.Write("Рейс - " + day + "\n");

                logic.NewAmazingDay();

                Console.Write("\nЕсли хотите Выйти нажмите esc\n");

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    isContinueCycle = false;
                    Console.WriteLine("esc");
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    class Logic
    {
        private DataBase _dataBase = new();

        internal void NewAmazingDay()
        {
            _dataBase.GenerateRoute();
            _dataBase.GenerateTotalTicetsSold();
            _dataBase.CreateNps();
            _dataBase.CreateTicetsWagon();
            FormTrain();
        }

        private void FormTrain()
        {
            ShowPassenger();

            int svWagon = HowManyWagon(_dataBase.QuantityTicetsSvWagon, _dataBase.WagonSvCapcitiy);
            int compartmentWagon = HowManyWagon(_dataBase.QuantityTcetsCompartmentWagon, _dataBase.WagonCompartmentCapcitiy);
            int reservedWagon = HowManyWagon(_dataBase.QuantityTicetsReservedSeatWagon, _dataBase.WagonReservedCapcitiy);

            ShowTrain(svWagon, compartmentWagon, reservedWagon);
        }

        private void ShowPassenger()
        {
            Console.WriteLine("Рейс - " + _dataBase.TrainRoute);
            Console.WriteLine("\nВсего пассажиров - " + _dataBase.TotalTicetsSold);
            Console.WriteLine("Пассажиров вагонов СВ - " + _dataBase.QuantityTicetsSvWagon);
            Console.WriteLine("Пассажиров вагонов Купе - " + _dataBase.QuantityTcetsCompartmentWagon);
            Console.WriteLine("Пассажиров вагонов плацкарт - " + _dataBase.QuantityTicetsReservedSeatWagon);
        }

        private void ShowTrain(int svWagon,int compartmentWagon,int reservedWagon)
        {
            Console.WriteLine("\nВсего вагонов - " + (svWagon + compartmentWagon + reservedWagon));
            Console.WriteLine("Состав поезда - СВ - " + svWagon + " вагон");
            Console.WriteLine("Состав поезда - Купейный - " + compartmentWagon + " вагон");
            Console.WriteLine("Состав поезда - Плацкартный - " + reservedWagon + " вагон");
        }

        private int HowManyWagon(int ticets, int wagonCapacity)
        {
            double wagons = Convert.ToDouble(ticets) / Convert.ToDouble(wagonCapacity);
            int wagonTemp = (int)wagons;
            wagons -= wagonTemp;

            if (wagons > 0)
            {
                wagonTemp++;
            }
            return wagonTemp;
        }
    }

    class DataBase
    {
        internal readonly int WagonSvCapcitiy = 18;
        internal readonly int WagonCompartmentCapcitiy = 34;
        internal readonly int WagonReservedCapcitiy = 52;

        private List<NPS> _nps = new();
        private Random _random = new Random();

        private int _ratioHigh = 70;
        private int _ratioMedium = 15;
        private string[] _trainRoute = { "040Й Москва - Уфа", "040К Киев - Симферополь", "040Л Севастополь - Киев", "040П Севастополь - Киев", "040Ц Санкт-Петербург - Джалтыр", "040Ш Киев - Симферополь", "041В Москва - Киев", "041Г Нижний Новгород - Новгород Великий (Новгород-на-Волхове)", "041Ж Волгоград - Астрахань", "041Й Саранск - Москва", "041М Воркута - Москва", "041П Днепропетровск - Трускавец", "041Р Атырау - Алматы", "041С Астрахань - Волгоград", "041Т Алматы - Атырау", "041Х Атырау - Алматы", "041Ц Алматы - Атырау", "041Э Казань - Нижний Новгород", "042А Москва - Новгород Великий (Новгород-на-Волхове)", "042В Москва - Воркута", "042Й Москва - Саранск", "042К Киев - Москва", "042Л Трускавец - Днепропетровск", "042Ч Новгород Великий (Новгород-на-Волхове) - Нижний Новгород", "043К Киев - Ивано-Франковск", "043Л Ивано-Франковск - Киев", "043С Санкт-Петербург - Новороссийск", "043Т Алматы - Костанай", "043Ц Костанай - Алматы", "043Э Хабаровск - Москва", "044С Новороссийск - Санкт-Петербург", "044Э Москва - Хабаровск", "045А Санкт-Петербург - Иваново", "045В Воронеж - Москва", "045Е Екатеринбург - Кисловодск", "045Й Тамбов - Москва", "045Л Ужгород - Лисичанск", "045С Кисловодск - Екатеринбург", "045Т Алматы - Павлодар", "045Ц Павлодар - Алматы", "045Я Иваново - Санкт-Петербург", "046В Москва - Воронеж", "046Д Лисичанск - Ужгород", "046М Москва - Тамбов", "047А Санкт-Петербург - Львов", "047Г Муром - Москва", "047Д Донецк - Симферополь", "047Ж Балаково - Москва", "047Й Москва - Балаково", "047Т Атырау - Нур-Султан", "047Ц Нур-Султан - Атырау", "047Ч Бендеры - Москва", "047Щ Кишинев - Москва", "047Ь Москва - Кишинев", "048В Москва - Муром", "048Л Львов - Санкт-Петербург", "048П Севастополь - Донецк", "049А Санкт-Петербург - Кисловодск", "049Б Санкт-Петербург - Брест", "049Г Казань - Москва", "049Д Киев - Львов", "049Е Нижний Тагил - Москва", "049Й Самара - Москва", "049К Киев - Трускавец", "049Х Алматы - Уральск", "049Ч Кисловодск - Санкт-Петербург", "049Я Санкт-Петербург - Брест" };
        private string[] _gender = { "Болтик", "Гаечка" };
        private string[] _status = { "High", "Medium", "low" };

        internal int TotalTicetsSold { get; private set; }
        internal int QuantityTicetsSvWagon { get; private set; }
        internal int QuantityTcetsCompartmentWagon { get; private set; }
        internal int QuantityTicetsReservedSeatWagon { get; private set; }
        internal string TrainRoute { get; private set; }

        internal int GetWagonSvCapcitiy()
        {
            return WagonSvCapcitiy;
        }

        internal int GetWagonCompartmentCapcitiy()
        {
            return WagonCompartmentCapcitiy;
        }

        internal int GetWagonReservedCapcitiy()
        {
            return WagonReservedCapcitiy;
        }

        internal void AddTrainRoute(string trainRoute)
        {
            TrainRoute = trainRoute;
        }

        internal string GetGender(int index, ref int maxNumber)
        {
            int length = _gender.Length;
            maxNumber = length;

            return _gender[index];
        }

        internal void GenerateRoute()
        {
            Random random = new();

            TrainRoute = _trainRoute[random.Next(0, _trainRoute.Length)];
        }

        internal void GenerateTotalTicetsSold()
        {
            int maxPassengers = 1000;
            Random random = new();

            int minPassangers = maxPassengers / 2;

            TotalTicetsSold = random.Next(minPassangers, maxPassengers);
        }

        internal void CreateNps()
        {
            for (int i = 0; i < TotalTicetsSold; i++)
            {
                NPS nps = new NPS(i.ToString(), AssignStatus(), AssignGender(_gender));

                _nps.Add(nps);
            }
        }

        internal void CreateTicetsWagon()
        {
            foreach (NPS nps in _nps)
            {
                if (nps.Status == _status[0])
                {
                    QuantityTicetsSvWagon++;
                }
                else if (nps.Status == _status[1])
                {
                    QuantityTcetsCompartmentWagon++;
                }
                else
                {
                    QuantityTicetsReservedSeatWagon++;
                }
            }
        }

        private string AssignGender(string[] gender)
        {
            string tempGender = "Болтик";

            tempGender = gender[_random.Next(0, _gender.Length)];

            return tempGender;
        }

        private string AssignStatus()
        {
            string tempStatus = "low";

            int[] statusRatio = { TotalTicetsSold / _ratioHigh, TotalTicetsSold / _ratioMedium, TotalTicetsSold };

            int randomNumber = _random.Next(0, TotalTicetsSold);

            if (randomNumber < statusRatio[0])
            {
                tempStatus = _status[0];
            }
            else if (randomNumber > statusRatio[0] & randomNumber < statusRatio[1])
            {
                tempStatus = _status[1];
            }

            return tempStatus;
        }
    }

    abstract class Wagon
    {
        internal int Capacity { get; private set; }

        internal int Number { get; private set; }
    }

    class SvWagon : Wagon
    {
    }

    class CompartmentWagon : Wagon
    {
    }

    class ReservedSeatWagon : Wagon
    {
    }

    class NPS
    {
        internal string IdNumber { get; private set; }

        internal string Status { get; private set; }

        internal string Gender { get; private set; }

        internal NPS(string id, string status, string gender)
        {
            IdNumber = id;
            Status = status;
            Gender = gender;
        }
    }
}
