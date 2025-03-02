using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagonClass
{
    public class FreightWagon : Wagon, IInit
    {
        private string cargoType;
        private int tonnage;

        public string CargoType
        {
            get => cargoType;
            set
            {
                string[] validTypes = { "Металлы", "Зерно", "Нефть", "Древесина", "Не указано" };

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Назначение груза не может быть пустым.");

                if (!validTypes.Contains(value))
                    throw new ArgumentException($"Недопустимый тип груза: {value}. Допустимые значения: {string.Join(", ", validTypes)}");

                cargoType = value;
            }
        }

        public int Tonnage
        {
            get => tonnage;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Тоннаж не может быть отрицательным.");

                if (value > 1000)
                    throw new ArgumentException("Тоннаж не может превышать 1000.");

                tonnage = value;
            }
        }

        public FreightWagon() : base() // По умолчанию
        {
            CargoType = "Не указано";
            Tonnage = 50;
        }

        public FreightWagon(int id, int number, int maxSpeed, string cargoType, int tonnage) : base(id, number, maxSpeed)
        {
            CargoType = cargoType;
            Tonnage = tonnage;
        }

        public override void Show()
        {
            Console.WriteLine("Грузовой вагон:");
            base.Show();
            Console.WriteLine($"Назначение груза: {CargoType}");
            Console.WriteLine($"Тоннаж: {Tonnage}");
        }

        public override void Init()
        {
            base.Init();

            bool validCargo = false; // Проверяем
            while (!validCargo)
            {
                Console.Write("Введите назначение груза: ");
                string input = Console.ReadLine();
                try
                {
                    CargoType = input;
                    validCargo = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }

            bool validTonnage = false;
            while (!validTonnage)
            {
                Console.Write("Введите тоннаж: ");
                if (int.TryParse(Console.ReadLine(), out int tonnageInput))
                {
                    try
                    {
                        Tonnage = tonnageInput;
                        validTonnage = true;
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

        public override void RandomInit() // Переопределение метода RandomInit(). Также сбрасываем количество койко-мест в 0.
        {
            base.RandomInit();
            string[] modes = { "Металлы", "Зерно", "Нефть", "Древесина", "Не указано" };
            Random random = new Random();
            CargoType = modes[random.Next(modes.Length)];
            Tonnage = random.Next(0, 1001);
        }

        public void JustShow() // Для не виртуального вывода
        {
            Console.WriteLine("Грузовой вагон:");
            Console.WriteLine($"Номер вагона: {Number}");
            Console.WriteLine($"Максимальная скорость: {MaxSpeed} км/ч");
            Console.WriteLine($"Назначение груза: {CargoType}");
            Console.WriteLine($"Тоннаж: {Tonnage}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is not FreightWagon) return false;
            FreightWagon other = (FreightWagon)obj;
            return (base.Equals(obj) && other.CargoType == this.CargoType && other.Tonnage == this.Tonnage);
        }

        public override object Clone()
        {
            Wagon baseClone = (Wagon)this.MemberwiseClone(); // Вызываем Clone() из базового класса

            return new FreightWagon(this.ID.id, this.Number, this.MaxSpeed, this.CargoType, this.Tonnage); // Создаем новый объект дочернего класса с полным копированием всех полей
        }

        public override string ToString()
        {
            return $"Грузовой вагон: ID вагона: {ID}, Номер вагона: {Number}, Максимальная скорость: {MaxSpeed} км/ч, Назначение груза: {CargoType}, Тоннаж: {Tonnage}";
        }
    }
}