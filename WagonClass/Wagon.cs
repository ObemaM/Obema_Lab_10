using System;

namespace WagonClass
{
    public class Wagon : IdNumber, IInit, IComparable<Wagon>, ICloneable, IUpgradable
    {
        public IdNumber ID { get; set; }
        public int number;
        public int maxSpeed;
        protected int defaultMaxSpeed; // Поле для хранения начальной скорости

        public int Number
        {
            get => number;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Номер не может быть отрицательным.");

                if (value > 999)
                    throw new ArgumentException("Номер не может превышать 999.");

                number = value;
            }
        }

        public int MaxSpeed
        {
            get => maxSpeed;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Скорость не может быть отрицательной.");

                if (value > 300)
                    throw new ArgumentException("Скорость не может превышать 300 км/ч.");

                maxSpeed = value;
            }
        }

        public Wagon()
        {
            ID = new IdNumber(0);
            Number = 1;
            MaxSpeed = 100;
            defaultMaxSpeed = MaxSpeed; // Сохраняем начальное значение скорости
        }

        public Wagon(int id, int number, int maxSpeed)
        {
            ID = new IdNumber(id);
            Number = number;
            MaxSpeed = maxSpeed;
            defaultMaxSpeed = MaxSpeed; // Сохраняем начальное значение скорости
        }

        public virtual string Show()
        {
            return $"Номер: {Number}, Максимальная скорость: {MaxSpeed}";
        }

        public virtual void Init()
        {
            bool validID = false; // Проверяем
            while (!validID)
            {
                Console.Write("Введите номер вагона: ");

                if (int.TryParse(Console.ReadLine(), out int realID))
                {
                    try
                    {
                        ID = new IdNumber(realID);
                        validID = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                }
                else
                    Console.WriteLine("Ошибка: Введите целое число.");
            }

            bool validNumber = false; // Проверяем
            while (!validNumber)
            {
                Console.Write("Введите номер вагона: ");

                if (int.TryParse(Console.ReadLine(), out int realNumber))
                {
                    try
                    {
                        Number = realNumber;
                        validNumber = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                }
                else
                    Console.WriteLine("Ошибка: Введите целое число.");
            }

            bool validSpeed = false;
            while (!validSpeed)
            {
                Console.Write("Введите максимальную скорость вагона: ");

                if (int.TryParse(Console.ReadLine(), out int realSpeed))
                {
                    try
                    {
                        MaxSpeed = realSpeed;
                        validSpeed = true;
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

        public virtual void RandomInit()
        {
            Random random = new Random();
            ID.id = random.Next(1, 100);
            Number = random.Next(1, 1000);
            MaxSpeed = random.Next(1, 301);
            defaultMaxSpeed = MaxSpeed; // Сохраняем начальное значение скорости
        }

        public string JustShow()
        {
            return $"Номер: {Number}, Максимальная скорость: {MaxSpeed}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false; // Если obj равен null, то объекты не равны
            if (obj is not Wagon) return false; // Если obj не является объектом типа Wagon, то объекты не равны
            Wagon other = (Wagon)obj; // Приводим obj к типу Wagon, чтобы точно был доступ к полям
            return this.Number == other.Number && this.MaxSpeed == other.MaxSpeed && ID.Equals(other.ID);
        }

        public int CompareTo(Wagon? other)
        {
            if (other == null)
                return 1;
            return this.Number.CompareTo(other.Number);
        }

        public virtual object Clone()
        {
            return new Wagon(this.ID.Id, this.Number, this.MaxSpeed);
        }

        public Wagon ShallowCopy()
        {
            return (Wagon)MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Номер: {Number}, Максимальная скорость: {MaxSpeed}";
        }

        public void UpgradeSpeed(int additionalSpeed)
        {
            if (additionalSpeed <= 0)
                throw new ArgumentException("Увеличение скорости должно быть положительным числом.");

            if (MaxSpeed+additionalSpeed > 300)
                MaxSpeed = 300; // Ограничиваем максимальную скорость
            else
                MaxSpeed += additionalSpeed;

            Console.WriteLine($"Скорость вагона увеличена на {additionalSpeed} км/ч. Новая скорость: {MaxSpeed} км/ч.");
        }

        public void ResetToDefaults()
        {
            MaxSpeed = defaultMaxSpeed; // Возвращаем скорость к начальному значению
            Console.WriteLine($"Параметры вагона сброшены к начальным. Максимальная скорость: {MaxSpeed} км/ч.");
        }
    }
}