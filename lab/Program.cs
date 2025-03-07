using System;
using WagonClass;

namespace Obema_Lab_10
{
    public class Program
    {
        public static int CheckInt(string message, int min, int max)
        {
            int number;
            bool isNumber;
            do
            {
                InputHelper.OneText(message);
                isNumber = int.TryParse(Console.ReadLine(), out number);
                if (!isNumber || number < min || number > max)
                {
                    InputHelper.Text($"Некорректный ввод. Число должно быть от {min} до {max}");
                    isNumber = false;
                }

            } while (!isNumber);

            return number;
        }

        public static int SummaryTonnage(Wagon[] wagons) // Для is
        {
            int summaryTonnage = 0;

            foreach (var wagon in wagons)
            {
                if (wagon is FreightWagon)
                    summaryTonnage += ((FreightWagon)wagon).Tonnage;
            }

            return summaryTonnage;
        }

        public static int MinimalSpeed(Wagon[] wagons)
        {
            if (wagons == null || wagons.Length == 0)
                return -1;

            int minimalSpeed = wagons[0].MaxSpeed;

            foreach (var wagon in wagons)
            { // Используем typeof для проверки типа
                if (wagon.GetType() == typeof(Wagon) || wagon.GetType() == typeof(RestaurantWagon) || wagon.GetType() == typeof(FreightWagon) || wagon.GetType() == typeof(PassengerWagon))
                {
                    if (wagon.MaxSpeed < minimalSpeed)
                        minimalSpeed = wagon.MaxSpeed;
                }
            }

            return minimalSpeed;
        }

        public static int SleepyPeople(Wagon[] wagons)
        {
            int summaryBeds = 0;

            foreach (var wagon in wagons)
            {
                PassengerWagon passengerWagon = wagon as PassengerWagon; // Используем as. Если wagon не PassengerWagon, passengerWagon будет null.
                if (passengerWagon != null)
                {
                    summaryBeds += passengerWagon.BedSeats;
                }
            }

            return summaryBeds;
        }

        static void Main()
        {
            Wagon[] wagons = new Wagon[25];
            int currentIndex = 0;
            Random random = new Random();

            InputHelper.Text("Часть 1");

            for (int i = 0; i < wagons.Length - 1; i++)
            {
                int type = random.Next(3);

                Wagon newWagon = null;

                switch (type)
                {
                    case 0:
                        newWagon = new PassengerWagon();
                        break;
                    case 1:
                        newWagon = new FreightWagon();
                        break;
                    case 2:
                        newWagon = new RestaurantWagon();
                        break;
                }

                if (newWagon != null)
                {
                    newWagon.RandomInit();
                    wagons[i] = newWagon;
                    currentIndex++;
                }
            }

            int choice;

            InputHelper.Text("\nВведите 25-ый элемент массива c клавиатуры");
            do
            {
                InputHelper.Text("\nВыберите тип вагона для добавления:");
                InputHelper.Text("1. Пассажирский вагон");
                InputHelper.Text("2. Грузовой вагон");
                InputHelper.Text("3. Вагон-ресторан");

                InputHelper.OneText("Ваш выбор: ");
                choice = CheckInt("Выберите тип вагона для добавления: ", 1, 3);

                Wagon newWagon = null;

                switch (choice)
                {
                    case 1:
                        newWagon = new PassengerWagon();
                        break;
                    case 2:
                        newWagon = new FreightWagon();
                        break;
                    case 3:
                        newWagon = new RestaurantWagon();
                        break;
                    default:
                        InputHelper.Text("Некорректный ввод. Попробуйте еще раз.");
                        break;
                }

                if (newWagon != null)
                {
                    newWagon.Init();
                    wagons[currentIndex] = newWagon; // Добавляем новый вагон в массив
                    currentIndex++; // Увеличиваем индекс
                }

            } while (currentIndex <= 24);

            InputHelper.Text("\nПросмотр вагонов с использованием виртуальной функции Show():");
            for (int i = 0; i < currentIndex; i++)
            {
                InputHelper.Text($"\nВагон {i + 1}: ");
                InputHelper.Text(wagons[i].Show());
            }

            InputHelper.Text("\nПросмотр вагонов с использованием не виртуальной функции JustShow():");
            for (int i = 0; i < currentIndex; i++)
            {
                InputHelper.Text($"\nВагон {i + 1}: ");
                InputHelper.Text(wagons[i].JustShow());
            }

            InputHelper.Text("\nЧасть 2");

            InputHelper.Text($"\n26. Сумма койко-мест всех вагонов поезда : {SleepyPeople(wagons)}");

            InputHelper.Text($"\n28. Минимальная максимально допустимая скорость движения всех вагонов: {MinimalSpeed(wagons)}");

            InputHelper.Text($"\n29. Общий тоннаж грузовых вагонов поезда: {SummaryTonnage(wagons)}");

            InputHelper.Text("\nЧасть 3");

            currentIndex = 0;
            IInit[] classes = new IInit[25];

            for (int i = 0; i < classes.Length - 1; i++)
            {
                int type = random.Next(4); // +Discipline

                IInit newElement = null;

                switch (type)
                {
                    case 0:
                        newElement = new PassengerWagon();
                        break;
                    case 1:
                        newElement = new FreightWagon();
                        break;
                    case 2:
                        newElement = new RestaurantWagon();
                        break;
                    case 3:
                        newElement = new Discipline();
                        break;
                }

                if (newElement != null)
                {
                    newElement.RandomInit();
                    classes[i] = newElement;
                    currentIndex++;
                }
            }

            InputHelper.Text("\nВведите 25-ый элемент массива c клавиатуры");
            do
            {
                InputHelper.Text("\nВыберите тип вагона для добавления:");
                InputHelper.Text("1. Пассажирский вагон");
                InputHelper.Text("2. Грузовой вагон");
                InputHelper.Text("3. Вагон-ресторан");
                InputHelper.Text("4. Дисциплина");

                InputHelper.OneText("Ваш выбор: ");

                choice = CheckInt("Выберите тип вагона для добавления: ", 1, 4);

                IInit newElement = null;

                switch (choice)
                {
                    case 1:
                        newElement = new PassengerWagon();
                        break;
                    case 2:
                        newElement = new FreightWagon();
                        break;
                    case 3:
                        newElement = new RestaurantWagon();
                        break;
                    case 4:
                        newElement = new Discipline();
                        break;
                    default:
                        InputHelper.Text("Некорректный ввод. Попробуйте еще раз.");
                        break;
                }

                if (newElement != null)
                {
                    newElement.Init();
                    classes[currentIndex] = newElement; // Добавляем новый вагон в массив
                    currentIndex++; // Увеличиваем индекс
                }

            } while (currentIndex <= 24);

            int passengerCount = 0;
            int freightCount = 0;
            int restaurantCount = 0;
            int disciplineCount = 0;

            foreach (var wagon in classes)
            {
                InputHelper.Text("");
                InputHelper.Text(wagon.ToString());
                if (wagon is RestaurantWagon)
                    restaurantCount++;
                else if (wagon is PassengerWagon)
                    passengerCount++;
                else if (wagon is FreightWagon)
                    freightCount++;
                else if (wagon is Discipline)
                    disciplineCount++;
            }

            InputHelper.Text("\n5. Количество объектов:");
            InputHelper.Text($"Пассажирских вагонов: {passengerCount}");
            InputHelper.Text($"Грузовых вагонов: {freightCount}");
            InputHelper.Text($"Вагонов-ресторанов: {restaurantCount}");
            InputHelper.Text($"Количество дисциплин: {disciplineCount}");

            InputHelper.Text("\nНажмите для продолжения...");
            Console.ReadLine();

            InputHelper.Text("\n6. Сортировка по номеру: ");
            Array.Sort(wagons); // Возрастание

            foreach (var wagon in wagons) // Беру массив первой части, ибо в Discipline нет полей для сравнения с классами Wagon, можно через IComparableEntity - но это не по заданию
            {
                InputHelper.Text("");
                InputHelper.Text(wagon.ToString());
            }

            InputHelper.Text("\nНажмите для продолжения...");
            Console.ReadLine();

            InputHelper.Text("\n7. Бинарный поиск по имени");
            int searchNumber = CheckInt("Введите номер вагона для поиска: ", 1, 999);

            Wagon searchWagon = new Wagon { Number = searchNumber }; // Создаем объект Wagon для поиска

            int index = Array.BinarySearch(wagons, searchWagon); // Выполняем бинарный поиск

            if (index >= 0)
            {
                InputHelper.Text($"\nВагон с именем {searchNumber} найден под индексом {index}.\n");
                InputHelper.Text(wagons[index].Show());
            }
            else
            {
                InputHelper.Text($"\nВагон с именем {searchNumber} не найден.");
            }

            InputHelper.Text("\nНажмите для продолжения...");
            Console.ReadLine();

            InputHelper.Text("\n8. Сортировка по максимальной скорости: "); // Возрастание
            Array.Sort(wagons, new Comparer());

            foreach (var wagon in wagons) // Беру массив первой части, ибо в Discipline нет полей для сравнения с классами Wagon, можно через IComparableEntity - но это не по заданию
            {
                InputHelper.Text("");
                InputHelper.Text(wagon.ToString());
            }

            InputHelper.Text("\n9. Бинарный поиск по скорости");
            int searchSpeed = CheckInt("Введите номер вагона для поиска: ", 1, 300);

            searchWagon = new Wagon { MaxSpeed = searchSpeed }; // Создаем объект Wagon для поиска

            Comparer comparer = new Comparer(); // Создаем экземпляр компаратора

            int indexSpeed = Array.BinarySearch(wagons, searchWagon, comparer); // Выполняем бинарный поиск, передавая компаратор

            if (indexSpeed >= 0)
            {
                InputHelper.Text($"\nВагон со скоростью {searchSpeed} найден под индексом {indexSpeed}.\n");
                InputHelper.Text("Информация о вагоне:");
                InputHelper.Text(wagons[indexSpeed].Show());
            }
            else
            {
                InputHelper.Text($"\nВагон со скоростью {searchSpeed} не найден.");
            }

            InputHelper.Text("\nНажмите для продолжения...");
            Console.ReadLine();

            Wagon clon = (Wagon)wagons[0].Clone(); // Глубокое копирование

            Wagon copy = (Wagon)wagons[0].ShallowCopy(); // Поверхностное копирование 

            InputHelper.Text("\nИсходный вагон:");
            InputHelper.Text(wagons[0].Show());

            InputHelper.Text("\nКлон (Clone):");
            InputHelper.Text(clon.Show());

            InputHelper.Text("\nКопия (ShallowCopy):");
            InputHelper.Text(copy.Show());

            wagons[0].ID.Id = 100;
            wagons[0].Number = 100;
            wagons[0].MaxSpeed = 100;

            InputHelper.Text("\nПосле изменения исходного объекта Person:");
            InputHelper.Text("\nИсходный вагон:");
            InputHelper.Text(wagons[0].Show());

            InputHelper.Text("\nКлон (Clone):");
            InputHelper.Text(clon.Show()); // Должен остаться без изменений

            InputHelper.Text("\nКопия (ShallowCopy):");
            InputHelper.Text(copy.Show()); // Изменения видны, т.к. ссылается на тот же объект Wagon

            InputHelper.Text("\nУлучшение характеристик вагонов:");
            if (wagons[1] is IUpgradable upgradable)
            {
                InputHelper.Text($"\nТекущие параметры вагона {wagons[1].Number}:\n");
                InputHelper.Text(wagons[1].Show());

                int speedIncrease = CheckInt("Введите значение для увеличения скорости: ", 0, 300);

                upgradable.UpgradeSpeed(speedIncrease);

                InputHelper.Text("\nПараметры после улучшения:\n");
                InputHelper.Text(wagons[1].Show());

                InputHelper.Text("\nСброс к начальным параметрам...\n");
                upgradable.ResetToDefaults();

                InputHelper.Text("\nПараметры после сброса:\n");
                InputHelper.Text(wagons[1].Show());
            }
        }
    }
}