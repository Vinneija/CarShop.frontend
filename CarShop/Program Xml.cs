using System.Text.Json;
using static System.Reflection.Assembly;
using System.Xml.Serialization;
using System.Collections.Generic;
using CarShop.Library;
using System;
using System.IO;
using System.Linq;

    class Program: CarFileOperator
    {
        private static readonly string FilePath = @"C:\SchoolFiles\CarXml.xml";

        static void Main(string[] args)
        {
            var car = new Car() { Model = "audi", Color = "black" };
            XmlSerialization(car);
            JsonSerialization(car);

            Console.ReadLine();
        }

        public static void XmlSerialization(Car car)
        {
            var list = new List<Car> { car, car };

            var serializer = new XmlSerializer(typeof(List<Car>));

            using (var fs = new FileStream(FilePath, FileMode.Open))
            {
                serializer.Serialize(fs, list);
            }

            using (var fs = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                var carFromFile = (List<Car>)serializer.Deserialize(fs);

                Console.WriteLine($"Car object : model = {carFromFile.FirstOrDefault().Model} color = {carFromFile.FirstOrDefault().Color}");

            }
        }

        public static void JsonSerialization(Car car)
        {
            var json = JsonSerializer.Serialize<Car>(car);
            Console.WriteLine(json);

            var desObject = JsonSerializer.Deserialize<Car>(json);

            Console.WriteLine($"Car object : model = {desObject.Model} color = {desObject.Color}");
        }
    }
