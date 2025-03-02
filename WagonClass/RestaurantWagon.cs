using System;
using System.Diagnostics;

namespace WagonClass
{
    public class RestaurantWagon : PassengerWagon, IInit
    {
        private string workMode;

        public string WorkMode
        {
            get => workMode;
            set
            {
                string[] modes = { "Круглосуточно", "С 8:00 до 22:00", "С 10:00 до 20:00", "Не указан" };

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Режим работы не может быть пустым.");

                if (!modes.Contains(value))
                    throw new ArgumentException($"Недопустимый режим работы: {value}.  Допустимые значения: {string.Join(", ", modes)}");

                workMode = value;
            }
        }

        public new int BedSeats
        {
            get => 0;
            set
            {
                if (value != 0)
                    throw new ArgumentException("В ресторане не может быть койко-мест.");
                base.BedSeats = 0;
            }
        }

        public RestaurantWagon() : base() // Конструктор по умолчанию: задаём количество койко-мест равным 0
        {
            base.BedSeats = 0;
            WorkMode = "Не указан";
        }

        public RestaurantWagon(int id, int number, int maxSpeed, int bedSeats, int sittingSeats, string workMode) : base(id, number, maxSpeed, bedSeats, sittingSeats) // Конструктор с параметрами. Здесь явно передаём 0 для койко-мест,
        {
            WorkMode = workMode;
        }

        public override void Show() // Переопределение метода Show(), в котором выводим информацию о ресторане.
        {
            Console.WriteLine("Вагон-ресторан:");
            Console.WriteLine($"ID вагона: {ID}");
            Console.WriteLine($"Номер вагона: {Number}");
            Console.WriteLine($"Максимальная скорость: {MaxSpeed} км/ч");
            Console.WriteLine($"Количество койко-мест: {BedSeats}");
            Console.WriteLine($"Количество сидячих мест: {SittingSeats}");
            Console.WriteLine($"Режим работы: {WorkMode}");
        }

        public override void Init()
        {
            bool validSitting = false;
            while (!validSitting)
            {
                Console.Write("Введите количество сидячих мест: ");
                if (int.TryParse(Console.ReadLine(), out int sitting))
                {
                    try
                    {
                        SittingSeats = sitting;
                        validSitting = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                }
                else
                    Console.WriteLine("Ошибка: Введите целое число.");
            }

            base.BedSeats = 0; // Чтобы ввода не было в консоли, сразу сбрасываем 

            bool validWork = false;
            while (!validWork)
            {
                Console.Write("Введите режим работы вагона-ресторана: ");
                string input = Console.ReadLine();
                try
                {
                    WorkMode = input;
                    validWork = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка ввода: " + ex.Message);
                }
            }
        }

        public override void RandomInit() // Переопределение метода RandomInit(). Также сбрасываем количество койко-мест в 0.
        {
            base.RandomInit();
            base.BedSeats = 0;
            string[] modes = { "Круглосуточно", "С 8:00 до 22:00", "С 10:00 до 20:00" };
            Random random = new Random();
            WorkMode = modes[random.Next(modes.Length)];
        }

        public void JustShow()
        {
            Console.WriteLine("Вагон-ресторан:");
            Console.WriteLine($"ID вагона: {ID}");
            Console.WriteLine($"Номер вагона: {Number}");
            Console.WriteLine($"Максимальная скорость: {MaxSpeed} км/ч");
            Console.WriteLine($"Количество койко-мест: {BedSeats}"); // При этом в выводе из PassengerWagon количество койко-мест будет 0
            Console.WriteLine($"Количество сидячих мест: {SittingSeats}");
            Console.WriteLine($"Режим работы: {WorkMode}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is not RestaurantWagon) return false;
            RestaurantWagon other = (RestaurantWagon)obj;
            return (base.Equals(obj) && other.WorkMode == this.WorkMode);
        }

        public RestaurantWagon ShallowCopy()
        {
            return (RestaurantWagon)this.MemberwiseClone();
        }

        public override object Clone()
        {
            PassengerWagon baseClone = (PassengerWagon)this.MemberwiseClone();

            return new RestaurantWagon(this.ID.id, this.Number, this.MaxSpeed, this.BedSeats, this.SittingSeats, this.WorkMode);
        }

        public override string ToString()
        {
            return $"Вагон-ресторан: ID вагона: {ID}, Номер вагона: {Number}, Максимальная скорость: {MaxSpeed} км/ч, Количество койко-мест: 0, Количество сидячих мест: {SittingSeats}, Режим работы: {WorkMode}";
        }
    }
}