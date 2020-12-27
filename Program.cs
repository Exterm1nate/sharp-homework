using System;
using System.Xml.Serialization;
using System.IO;

namespace Homework
{
    public enum WagonType
    {
        Passenger,
        Freight
    }

    [Serializable]
    public class Wagon
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public WagonType Type { get; set; }
        public int Seats { get; set; }
        public int LoadCapacity { get; set; }

        public Wagon() {}

        public Wagon(string name, string serialNumber, WagonType type, int seats, int loadCapacity)
        {
            Name = name;
            SerialNumber = serialNumber;
            Type = type;
            Seats = seats;
            LoadCapacity = loadCapacity;
        }
    }

    public enum LocomotiveType
    {
        Thermal,
        Electric
    }

    [Serializable]
    public class Locomotive
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public LocomotiveType Type { get; set; }

        public Locomotive() {}

        public Locomotive(string name, string serialNumber, LocomotiveType type)
        {
            Name = name;
            SerialNumber = serialNumber;
            Type = type;
        }
    }

    [Serializable]
    public class Train
    {
        public string Number { get; set; }
        public Locomotive Locomotive { get; set; }
        public Wagon[] Wagons { get; set; }

        public Train() {}

        public Train(string number, Locomotive locomotive, Wagon[] wagons)
        {
            Number = number;
            Locomotive = locomotive;
            Wagons = wagons;
        }
    }

    class Program
    {
        static void Main(string[] args) 
        {
            var first_wagon = new Wagon("Вагон-бар", "РТ-200", WagonType.Passenger, 42, 0);
            var second_wagon = new Wagon("Фитинговая платформа", "13-1258-01", WagonType.Freight, 0, 72);
            Wagon[] wagons = new Wagon[] { first_wagon, second_wagon };
            var locomotive = new Locomotive("Маневровый тепловоз", "ЧМЭ2-293", LocomotiveType.Thermal);
            var train = new Train("Подвезем за сотку", locomotive, wagons);

            XmlSerializer formatter = new XmlSerializer(typeof(Train));
            using (FileStream fs = new FileStream("train.xml", FileMode.OpenOrCreate)) 
            {
                formatter.Serialize(fs, train);
            }
        }
    }
}
