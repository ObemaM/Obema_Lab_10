
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WagonClass
{
    public class Discipline : IInit // Убраны некоторые методы, чтобы не тестировать лишнего
    {
        private string name;
        private int contactHours;
        private int selfHours;
        private static int objectCount = 0;

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    name = "Без названия";
                else
                    name = value;
            }
        }

        public int ContactHours
        {
            get => contactHours;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Аудиторные часы не могут быть отрицательными.");

                if (value > 300)
                    throw new ArgumentException("Аудиторные часы не могут превышать 300.");

                contactHours = value;
            }
        }

        public int SelfHours
        {
            get => selfHours;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Часы самостоятельной работы не могут быть отрицательными.");

                if (value > 400)
                    throw new ArgumentException("Часы самостоятельной работы не могут превышать 400.");

                selfHours = value;
            }
        }

        public Discipline()
        {
            Name = "Новая дисциплина";
            ContactHours = 0;
            SelfHours = 0;
            objectCount++;
        }

        public Discipline(string name, int contactHours, int selfHours)
        {
            Name = name;
            ContactHours = contactHours;
            SelfHours = selfHours;
            objectCount++;
        }

        public Discipline(Discipline other)
        {
            Name = other.Name;
            ContactHours = other.ContactHours;
            SelfHours = other.SelfHours;
            objectCount++;
        }


        public void Init()
        {
            bool validName = false;
            while (!validName)
            {
                Console.Write("Введите название дисциплины: ");
                string input = Console.ReadLine();
                try
                {
                    Name = input;
                    validName = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка ввода: " + ex.Message);
                }
            }

            bool validContactHours = false;
            while (!validContactHours)
            {
                Console.Write("Введите количество аудиторных часов: ");
                if (int.TryParse(Console.ReadLine(), out int contactHoursInput))
                {
                    try
                    {
                        ContactHours = contactHoursInput;
                        validContactHours = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите целое число.");
                }
            }

            bool validSelfHours = false;
            while (!validSelfHours)
            {
                Console.Write("Введите количество часов самостоятельной работы: ");
                if (int.TryParse(Console.ReadLine(), out int selfHoursInput))
                {
                    try
                    {
                        SelfHours = selfHoursInput;
                        validSelfHours = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                }
                else
                    Console.WriteLine("Ошибка: Введите целое число.");
            }
        }

        public void RandomInit()
        {
            Random random = new Random();
            Name = $"Дисциплина {random.Next(0, 200)}";
            ContactHours = random.Next(0, 301);
            SelfHours = random.Next(0, 401);
        }

        public override bool Equals(object obj)
        {
            if (obj is Discipline other)
            {
                return Name == other.Name && ContactHours == other.ContactHours && SelfHours == other.SelfHours;
            }
            else
            {
                return false;
            }
        }

        public override string ToString() // Для 3 части
        {
            return $"Дисциплина: Название: {Name}, Аудиторные часы: {ContactHours}, Самостоятельные часы: {SelfHours}";
        }
    }
}