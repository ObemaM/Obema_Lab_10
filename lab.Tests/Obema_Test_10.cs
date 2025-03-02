using Microsoft.VisualStudio.TestPlatform.TestHost;
using WagonClass;

namespace Obema_Test_10
{
    [TestClass]
    public class WagonTests
    {
        [TestMethod]
        public void DefaultConstructor()
        {
            Wagon wagon = new Wagon();

            Assert.AreEqual(1, wagon.Number);
            Assert.AreEqual(100, wagon.MaxSpeed);
            Assert.AreEqual(0, wagon.ID.Id);
        }

        [TestMethod]
        public void ValueConstructor()
        {
            Wagon wagon = new Wagon(5, 10, 200);

            Assert.AreEqual(5, wagon.ID.Id);
            Assert.AreEqual(10, wagon.Number);
            Assert.AreEqual(200, wagon.MaxSpeed);
        }

        [TestMethod]
        public void NumberTest()
        {
            Wagon wagon = new Wagon();
            wagon.Number = 500;

            Assert.AreEqual(500, wagon.Number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NumberTestException()
        {
            Wagon wagon = new Wagon();
            wagon.Number = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NumberTestBigException()
        {
            Wagon wagon = new Wagon();
            wagon.Number = 1000;
        }

        [TestMethod]
        public void SpeedTest()
        {
            Wagon wagon = new Wagon();
            wagon.MaxSpeed = 250;

            Assert.AreEqual(250, wagon.MaxSpeed);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SpeedTestNegativeException()
        {
            Wagon wagon = new Wagon();
            wagon.MaxSpeed = -50;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SpeedTestBigException()
        {
            Wagon wagon = new Wagon();
            wagon.MaxSpeed = 400;
        }

        [TestMethod]
        public void EqualsTrue()
        {
            Wagon wagon1 = new Wagon(5, 10, 200);
            Wagon wagon2 = new Wagon(5, 10, 200);

            Assert.IsTrue(wagon1.Equals(wagon2));
        }

        [TestMethod]
        public void EqualsFalse()
        {
            Wagon wagon1 = new Wagon(5, 10, 200);
            Wagon wagon2 = new Wagon(5, 11, 200);

            Assert.IsFalse(wagon1.Equals(wagon2));
        }

        [TestMethod]
        public void CopyTest()
        {
            Wagon original = new Wagon(5, 10, 200);

            Wagon clone = (Wagon)original.Clone();

            Assert.AreEqual(original.ID.Id, clone.ID.Id);
            Assert.AreEqual(original.Number, clone.Number);
            Assert.AreEqual(original.MaxSpeed, clone.MaxSpeed);
            Assert.AreNotSame(original, clone);
        }

        [TestMethod]
        public void CompareToZero()
        {
            Wagon wagon1 = new Wagon(5, 10, 200);
            Wagon wagon2 = new Wagon(5, 10, 200);

            Assert.AreEqual(0, wagon1.CompareTo(wagon2));
        }

        [TestMethod]
        public void CompareToNegative()
        {
            Wagon wagon1 = new Wagon(5, 5, 200);
            Wagon wagon2 = new Wagon(5, 10, 200);

            Assert.IsTrue(wagon1.CompareTo(wagon2) < 0);
        }

        [TestMethod]
        public void CompareToPositive()
        {
            Wagon wagon1 = new Wagon(5, 15, 200);
            Wagon wagon2 = new Wagon(5, 10, 200);

            Assert.IsTrue(wagon1.CompareTo(wagon2) > 0);
        }

        [TestMethod]
        public void EqualsNullFalse()
        {
            Wagon wagon = new Wagon();

            Assert.IsFalse(wagon.Equals(null));
        }

        [TestMethod]
        public void EqualsDifferentTypeFalse()
        {
            Wagon wagon = new Wagon();
            object obj = new object();

            Assert.IsFalse(wagon.Equals(obj));
        }

        [TestMethod]
        public void CompareToNullPositive()
        {
            Wagon wagon = new Wagon(5, 10, 200);

            Assert.IsTrue(wagon.CompareTo(null) > 0);
        }
    }

    [TestClass]
    public class FreightWagonTests
    {
        [TestMethod]
        public void DefaultConstructor()
        {
            FreightWagon wagon = new FreightWagon();

            Assert.AreEqual("Не указано", wagon.CargoType);
            Assert.AreEqual(50, wagon.Tonnage);
            Assert.AreEqual(1, wagon.Number);
            Assert.AreEqual(100, wagon.MaxSpeed);
            Assert.AreEqual(0, wagon.ID.Id);
        }

        [TestMethod]
        public void ValueConstructor()
        {
            FreightWagon wagon = new FreightWagon(5, 10, 200, "Металлы", 800);

            Assert.AreEqual("Металлы", wagon.CargoType);
            Assert.AreEqual(800, wagon.Tonnage);
            Assert.AreEqual(10, wagon.Number);
            Assert.AreEqual(200, wagon.MaxSpeed);
            Assert.AreEqual(5, wagon.ID.Id);
        }

        [TestMethod]
        public void CargoTypeTest()
        {
            FreightWagon wagon = new FreightWagon();
            wagon.CargoType = "Нефть";

            Assert.AreEqual("Нефть", wagon.CargoType);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CargoTypeSpaceTestException()
        {
            FreightWagon wagon = new FreightWagon();
            wagon.CargoType = " ";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CargoTypeOutOfArrayTestException()
        {
            FreightWagon wagon = new FreightWagon();
            wagon.CargoType = "Текстиль";
        }

        [TestMethod]
        public void TonnageTest()
        {
            FreightWagon wagon = new FreightWagon();
            wagon.Tonnage = 900;

            Assert.AreEqual(900, wagon.Tonnage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TonnageTestNegativeException()
        {
            FreightWagon wagon = new FreightWagon();
            wagon.Tonnage = -100;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TonnageTestBigException()
        {
            FreightWagon wagon = new FreightWagon();
            wagon.Tonnage = 1500;
        }

        [TestMethod]
        public void EqualsTrue()
        {
            FreightWagon wagon1 = new FreightWagon(5, 10, 200, "Зерно", 700);
            FreightWagon wagon2 = new FreightWagon(5, 10, 200, "Зерно", 700);

            Assert.IsTrue(wagon1.Equals(wagon2));
        }

        [TestMethod]
        public void EqualsFalse()
        {
            FreightWagon wagon1 = new FreightWagon(5, 10, 200, "Зерно", 700);
            FreightWagon wagon2 = new FreightWagon(5, 10, 200, "Нефть", 700);

            Assert.IsFalse(wagon1.Equals(wagon2));
        }

        [TestMethod]
        public void CopyTest()
        {
            FreightWagon original = new FreightWagon(5, 10, 200, "Древесина", 600);

            FreightWagon clone = (FreightWagon)original.Clone();

            Assert.AreEqual(original.ID.Id, clone.ID.Id);
            Assert.AreEqual(original.Number, clone.Number);
            Assert.AreEqual(original.MaxSpeed, clone.MaxSpeed);
            Assert.AreEqual(original.CargoType, clone.CargoType);
            Assert.AreEqual(original.Tonnage, clone.Tonnage);
            Assert.AreNotSame(original, clone);
        }
    }

    [TestClass]
    public class ComparerTests
    {
        [TestMethod]
        public void CompareSpeedsPositive()
        {
            var comparer = new Comparer();
            var wagon1 = new Wagon { MaxSpeed = 200 };
            var wagon2 = new Wagon { MaxSpeed = 150 };
            int result = comparer.Compare(wagon1, wagon2);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareSpeedsZero()
        {
            var comparer = new Comparer();
            var wagon1 = new Wagon { MaxSpeed = 180 };
            var wagon2 = new Wagon { MaxSpeed = 180 };
            int result = comparer.Compare(wagon1, wagon2);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareSpeedNegative()
        {
            var comparer = new Comparer();
            var wagon1 = new Wagon { MaxSpeed = 150 };
            var wagon2 = new Wagon { MaxSpeed = 200 };
            int result = comparer.Compare(wagon1, wagon2);

            Assert.IsTrue(result < 0);
        }
    }

    [TestClass]
    public class DisciplineTests
    {
        [TestMethod]
        public void DefaultConstructor()
        {
            Discipline d = new Discipline();

            Assert.AreEqual("Новая дисциплина", d.Name);
            Assert.AreEqual(0, d.ContactHours);
            Assert.AreEqual(0, d.SelfHours);
        }

        [TestMethod]
        public void ValueConstructor()
        {
            Discipline d = new Discipline("Математика", 40, 60);

            Assert.AreEqual("Математика", d.Name);
            Assert.AreEqual(40, d.ContactHours);
            Assert.AreEqual(60, d.SelfHours);
        }

        [TestMethod]
        public void CopyConstructor()
        {
            Discipline original = new Discipline("Физика", 50, 70);

            Discipline copy = new Discipline(original);

            Assert.AreEqual(original.Name, copy.Name);
            Assert.AreEqual(original.ContactHours, copy.ContactHours);
            Assert.AreEqual(original.SelfHours, copy.SelfHours);
        }

        [TestMethod]
        public void NameTest()
        {
            Discipline d = new Discipline();
            d.Name = "";

            Assert.AreEqual("Без названия", d.Name);
        }

        [TestMethod]
        public void ContactHoursTest()
        {
            Discipline d = new Discipline();
            d.ContactHours = 150;

            Assert.AreEqual(150, d.ContactHours);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContactHoursTestNegative()
        {
            Discipline d = new Discipline();
            d.ContactHours = -10;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContactHoursBigTest()
        {
            Discipline d = new Discipline();
            d.ContactHours = 350;
        }

        [TestMethod]
        public void SelfHoursTestPositive()
        {
            Discipline d = new Discipline();
            d.SelfHours = 300;

            Assert.AreEqual(300, d.SelfHours);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SelfHoursTestNegative()
        {
            Discipline d = new Discipline();
            d.SelfHours = -50;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SelfHoursBigTest()
        {
            Discipline d = new Discipline();
            d.SelfHours = 500;
        }

        [TestMethod]
        public void EqualsTrue()
        {
            Discipline d1 = new Discipline("Fall", 100, 200);
            Discipline d2 = new Discipline("Fall", 100, 200);

            Assert.IsTrue(d1.Equals(d2));
        }

        [TestMethod]
        public void EqualsFalse()
        {
            Discipline d1 = new Discipline("Put", 100, 200);
            Discipline d2 = new Discipline("It", 100, 200);

            Assert.IsFalse(d1.Equals(d2));
        }

        [TestMethod]
        public void EqualsDifferentType()
        {
            Discipline d1 = new Discipline("On", 100, 200);
            object obj = new object();

            Assert.IsFalse(d1.Equals(obj));
        }
    }

    [TestClass]
    public class IdNumberTests
    {
        [TestMethod]
        public void DefaultConstructor()
        {
            IdNumber id = new IdNumber();
            Assert.AreEqual(0, id.Id);
        }

        [TestMethod]
        public void ValueConstructor()
        {
            IdNumber id = new IdNumber(50);
            Assert.AreEqual(50, id.Id);
        }

        [TestMethod]
        public void IdTest()
        {
            IdNumber id = new IdNumber();
            id.Id = 75;

            Assert.AreEqual(75, id.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IdTestNegativeException()
        {
            IdNumber id = new IdNumber();
            id.Id = -10;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IdTestBigException()
        {
            IdNumber id = new IdNumber();
            id.Id = 150;
        }

        [TestMethod]
        public void EqualsTrue()
        {
            IdNumber id1 = new IdNumber(30);
            IdNumber id2 = new IdNumber(30);

            Assert.IsTrue(id1.Equals(id2));
        }

        [TestMethod]
        public void EqualsFalse()
        {
            IdNumber id1 = new IdNumber(30);
            IdNumber id2 = new IdNumber(40);

            Assert.IsFalse(id1.Equals(id2));
        }

        [TestMethod]
        public void EqualsNullFalse()
        {
            IdNumber id = new IdNumber(30);

            Assert.IsFalse(id.Equals(null));
        }

        [TestMethod]
        public void EqualsDifferentTypeFalse()
        {
            IdNumber id = new IdNumber(30);
            object obj = new object();

            Assert.IsFalse(id.Equals(obj));
        }
    }

    [TestClass]
    public class PassengerWagonTests
    {
        [TestMethod]
        public void DefaultConstructor()
        {
            PassengerWagon wagon = new PassengerWagon();

            Assert.AreEqual(10, wagon.BedSeats);
            Assert.AreEqual(50, wagon.SittingSeats);
            Assert.AreEqual(1, wagon.Number);
            Assert.AreEqual(100, wagon.MaxSpeed);
            Assert.AreEqual(0, wagon.ID.Id);
        }

        [TestMethod]
        public void ValueConstructor()
        {
            PassengerWagon wagon = new PassengerWagon(5, 10, 200, 20, 150);

            Assert.AreEqual(20, wagon.BedSeats);
            Assert.AreEqual(150, wagon.SittingSeats);
            Assert.AreEqual(10, wagon.Number);
            Assert.AreEqual(200, wagon.MaxSpeed);
            Assert.AreEqual(5, wagon.ID.Id);
        }

        [TestMethod]
        public void BedSeatsTest()
        {
            PassengerWagon wagon = new PassengerWagon();
            wagon.BedSeats = 50;

            Assert.AreEqual(50, wagon.BedSeats);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BedSeatsTestNegativeException()
        {
            PassengerWagon wagon = new PassengerWagon();
            wagon.BedSeats = -10;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BedSeatsTestBigException()
        {
            PassengerWagon wagon = new PassengerWagon();
            wagon.BedSeats = 150;
        }

        [TestMethod]
        public void SittingSeatsTest()
        {
            PassengerWagon wagon = new PassengerWagon();
            wagon.SittingSeats = 100;

            Assert.AreEqual(100, wagon.SittingSeats);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SittingSeatsTestNegativeException()
        {
            PassengerWagon wagon = new PassengerWagon();
            wagon.SittingSeats = -20;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SittingSeatsTestBigException()
        {
            PassengerWagon wagon = new PassengerWagon();
            wagon.SittingSeats = 300;
        }

        [TestMethod]
        public void EqualsTrue()
        {
            PassengerWagon wagon1 = new PassengerWagon(5, 10, 200, 30, 120);
            PassengerWagon wagon2 = new PassengerWagon(5, 10, 200, 30, 120);

            Assert.IsTrue(wagon1.Equals(wagon2));
        }

        [TestMethod]
        public void EqualsFalse()
        {
            PassengerWagon wagon1 = new PassengerWagon(5, 10, 200, 30, 120);
            PassengerWagon wagon2 = new PassengerWagon(5, 10, 200, 40, 120);

            Assert.IsFalse(wagon1.Equals(wagon2));
        }

        [TestMethod]
        public void CopyTest()
        {
            PassengerWagon original = new PassengerWagon(5, 10, 200, 25, 150);

            PassengerWagon clone = (PassengerWagon)original.Clone();

            Assert.AreEqual(original.ID.Id, clone.ID.Id);
            Assert.AreEqual(original.Number, clone.Number);
            Assert.AreEqual(original.MaxSpeed, clone.MaxSpeed);
            Assert.AreEqual(original.BedSeats, clone.BedSeats);
            Assert.AreEqual(original.SittingSeats, clone.SittingSeats);
            Assert.AreNotSame(original, clone);
        }

        [TestMethod]
        public void EqualsNullsFalse()
        {
            PassengerWagon wagon = new PassengerWagon();

            Assert.IsFalse(wagon.Equals(null));
        }

        [TestMethod]
        public void EqualsDifferentTypeFalse()
        {
            PassengerWagon wagon = new PassengerWagon();
            object obj = new object();

            Assert.IsFalse(wagon.Equals(obj));
        }
    }

    [TestClass]
    public class RestaurantWagonTests
    {
        [TestMethod]
        public void DefaultConstructor()
        {
            RestaurantWagon wagon = new RestaurantWagon();

            Assert.AreEqual(0, wagon.BedSeats);
            Assert.AreEqual("Не указан", wagon.WorkMode);
            Assert.AreEqual(0, wagon.ID.Id);
            Assert.AreEqual(1, wagon.Number);
            Assert.AreEqual(100, wagon.MaxSpeed);
            Assert.AreEqual(0, wagon.BedSeats);
        }

        [TestMethod]
        public void ValueConstructor()
        {
            RestaurantWagon wagon = new RestaurantWagon(5, 10, 200, 0, 150, "Круглосуточно");

            Assert.AreEqual(0, wagon.BedSeats);
            Assert.AreEqual("Круглосуточно", wagon.WorkMode);
            Assert.AreEqual(5, wagon.ID.Id);
            Assert.AreEqual(10, wagon.Number);
            Assert.AreEqual(200, wagon.MaxSpeed);
            Assert.AreEqual(150, wagon.SittingSeats);
        }

        [TestMethod]
        public void WorkModeTest()
        {
            RestaurantWagon wagon = new RestaurantWagon();
            wagon.WorkMode = "С 8:00 до 22:00";

            Assert.AreEqual("С 8:00 до 22:00", wagon.WorkMode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WorkModeTestException()
        {
            RestaurantWagon wagon = new RestaurantWagon();
            wagon.WorkMode = "Неправильный режим";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WorkModeTestSpaceException()
        {
            RestaurantWagon wagon = new RestaurantWagon();
            wagon.WorkMode = " ";
        }

        [TestMethod]
        public void BedSeatsZeroTest()
        {
            RestaurantWagon wagon = new RestaurantWagon();
            Assert.AreEqual(0, wagon.BedSeats);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BedSeatsSetterNonZeroException()
        {
            RestaurantWagon wagon = new RestaurantWagon();
            wagon.BedSeats = 5;
        }

        [TestMethod]
        public void EqualsTrue()
        {
            RestaurantWagon wagon1 = new RestaurantWagon(5, 10, 200, 0, 150, "С 10:00 до 20:00");
            RestaurantWagon wagon2 = new RestaurantWagon(5, 10, 200, 0, 150, "С 10:00 до 20:00");

            Assert.IsTrue(wagon1.Equals(wagon2));
        }

        [TestMethod]
        public void EqualsDifferentFalse()
        {
            RestaurantWagon wagon1 = new RestaurantWagon(5, 10, 200, 0, 150, "Круглосуточно");
            RestaurantWagon wagon2 = new RestaurantWagon(5, 10, 200, 0, 150, "С 8:00 до 22:00");

            Assert.IsFalse(wagon1.Equals(wagon2));
        }

        [TestMethod]
        public void CopyTest()
        {
            RestaurantWagon original = new RestaurantWagon(5, 10, 200, 0, 150, "С 10:00 до 20:00");

            RestaurantWagon clone = (RestaurantWagon)original.Clone();

            Assert.AreEqual(original.ID.Id, clone.ID.Id);
            Assert.AreEqual(original.Number, clone.Number);
            Assert.AreEqual(original.MaxSpeed, clone.MaxSpeed);
            Assert.AreEqual(original.SittingSeats, clone.SittingSeats);
            Assert.AreEqual(original.WorkMode, clone.WorkMode);
            Assert.AreNotSame(original, clone);
        }

        [TestMethod]
        public void EqualsNullFalse()
        {
            RestaurantWagon wagon = new RestaurantWagon();

            Assert.IsFalse(wagon.Equals(null));
        }

        [TestMethod]
        public void EqualsDifferentTypeFalse()
        {
            RestaurantWagon wagon = new RestaurantWagon();
            object obj = new object();

            Assert.IsFalse(wagon.Equals(obj));
        }

        [TestMethod]
        public void EqualsDifferentBaseFalse()
        {
            RestaurantWagon wagon1 = new RestaurantWagon(5, 10, 200, 0, 150, "С 8:00 до 22:00");
            RestaurantWagon wagon2 = new RestaurantWagon(6, 10, 200, 0, 150, "С 8:00 до 22:00");

            Assert.IsFalse(wagon1.Equals(wagon2));
        }
    }

    [TestClass]
    public class Part_2_Tests // Тесты для 3 статических функций из части 2
    {
        [TestMethod]
        public void SummaryTonnageTestZero()
        {
            Wagon[] wagons = new Wagon[]
            {
                new PassengerWagon(),
                new RestaurantWagon()
            };

            int result = Obema_Lab_10.Program.SummaryTonnage(wagons);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SummaryTonnageTest()
        {
            Wagon[] wagons = new Wagon[]
            {
                new FreightWagon(1, 2, 150, "Металлы", 50),
                new FreightWagon(2, 3, 160, "Зерно", 70),
                new PassengerWagon()
            };

            int result = Obema_Lab_10.Program.SummaryTonnage(wagons);

            Assert.AreEqual(120, result);
        }

        [TestMethod]
        public void MinimalSpeedTestNegative()
        {
            Wagon[] wagons = new Wagon[0];

            int result = Obema_Lab_10.Program.MinimalSpeed(wagons);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void MinimalSpeedTest()
        {
            Wagon[] wagons = null;

            int result = Obema_Lab_10.Program.MinimalSpeed(wagons);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void SleepyPeopleTest()
        {
            Wagon[] wagons = new Wagon[]
            {
                new FreightWagon(1, 2, 150, "Металлы", 50),
                new RestaurantWagon(2, 3, 160, 0, 30, "Круглосуточно")
            };

            int result = Obema_Lab_10.Program.SleepyPeople(wagons);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SleepyPeopleTestCorrect()
        {
            Wagon[] wagons = new Wagon[]
            {
                new PassengerWagon(1, 2, 150, 20, 50),
                new PassengerWagon(2, 3, 160, 10, 30),
                new FreightWagon(3, 4, 120, "Зерно", 70)
            };

            int result = Obema_Lab_10.Program.SleepyPeople(wagons);

            Assert.AreEqual(30, result);
        }
    }
}
