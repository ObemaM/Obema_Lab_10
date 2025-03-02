using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WagonClass
{
    public class PassengerWagon : Wagon, IInit
    {
        protected int bedSeats; // Протектед для производных классов
        protected int sittingSeats;

        public int BedSeats
        {
            get => bedSeats;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество койко-мест не может быть отрицательным.");

                if (value > 100)
                    throw new ArgumentException("Количество койко-мест не может превышать 100.");

                bedSeats = value;
            }
        }

        public int SittingSeats
        {
            get => sittingSeats;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество сидячих мест не может быть отрицательным.");

                if (value > 200)
                    throw new ArgumentException("Количество сидячих мест не может превышать 200.");

                sittingSeats = value;
            }
        }

        public PassengerWagon() : base() // По умолчанию
        {
            BedSeats = 10;
            SittingSeats = 50;
        }

        public PassengerWagon(int id, int number, int maxSpeed, int bedSeats, int sittingSeats) : base(id, number, maxSpeed)
        {
            BedSeats = bedSeats;
            SittingSeats = sittingSeats;
        }

        public override void Show()
        {
            Console.WriteLine("Пассажирский вагон:");
            base.Show();
            Console.WriteLine($"Количество койко-мест: {BedSeats}");
            Console.WriteLine($"Количество сидячих мест: {SittingSeats}");
        }

        public override void Init() // Переопределение метода Init()
        {
            base.Init();

            bool validBed = false;
            while (!validBed)
            {
                Console.Write("Введите количество койко-мест: ");
                if (int.TryParse(Console.ReadLine(), out int bed))
                {
                    try
                    {
                        BedSeats = bed;
                        validBed = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                }
                else
                    Console.WriteLine("Ошибка: Введите целое число."); // В случае ввода строки тоже
            }

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
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Random random = new Random();
            BedSeats = random.Next(0, 101);
            SittingSeats = random.Next(0, 201);
        }

        public void JustShow() // Для не виртуального
        {
            Console.WriteLine("Пассажирский вагон:");
            Console.WriteLine($"Номер вагона: {Number}");
            Console.WriteLine($"Максимальная скорость: {MaxSpeed} км/ч");
            Console.WriteLine($"Количество койко-мест: {BedSeats}");
            Console.WriteLine($"Количество сидячих мест: {SittingSeats}");
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is not PassengerWagon) return false;
            PassengerWagon other = (PassengerWagon)obj;
            return (base.Equals(obj) && other.BedSeats == this.BedSeats && other.SittingSeats == this.SittingSeats);
        }
        public override object Clone()
        {
            Wagon baseClone = (Wagon)this.MemberwiseClone(); // Clone из базового класса

            return new PassengerWagon(this.ID.id, this.Number, this.MaxSpeed, this.BedSeats, this.SittingSeats);
        }

        public PassengerWagon ShallowCopy()
        {
            return (PassengerWagon)this.MemberwiseClone(); // Поверхностное копирование
        }

        public override string ToString()
        {
            return $"Пассажирский вагон: ID вагона: {ID}, Номер вагона: {Number}, Максимальная скорость: {MaxSpeed} км/ч, Количество койко-мест: {BedSeats}, Количество сидячих мест: {SittingSeats}";
        }
    }
}