using System;

namespace CreationalPatternsExample
{
    // Базовий клас
    public abstract class BaseClass
    {
        // Віртуальний метод
        public abstract void ShowInfo();
    }

    // Похідний клас 1: Числа, що діляться на 3
    public class DivisibleByThree : BaseClass
    {
        public override void ShowInfo()
        {
            Console.WriteLine("Це клас, що генерує числа, які діляться на 3.");
        }

        public void GenerateNumbers(int count)
        {
            Console.WriteLine("Числа, що діляться на 3:");
            int number = 3;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(number);
                number += 3;
            }
        }
    }

    // Похідний клас 2: Числа, що діляться на 3 із залишком 1
    public class DivisibleByThreePlusOne : BaseClass
    {
        public override void ShowInfo()
        {
            Console.WriteLine("Це клас, що генерує числа, які діляться на 3 із залишком 1.");
        }

        public void GenerateNumbers(int count)
        {
            Console.WriteLine("Числа, що діляться на 3 із залишком 1:");
            int number = 1;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(number);
                number += 3;
            }
        }
    }

    // Похідний клас 3: Числа, що діляться на 3 із залишком 2
    public class DivisibleByThreePlusTwo : BaseClass
    {
        public override void ShowInfo()
        {
            Console.WriteLine("Це клас, що генерує числа, які діляться на 3 із залишком 2.");
        }

        public void GenerateNumbers(int count)
        {
            Console.WriteLine("Числа, що діляться на 3 із залишком 2:");
            int number = 2;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(number);
                number += 3;
            }
        }
    }

    // Абстрактна фабрика
    public abstract class NumberFactory
    {
        public abstract BaseClass CreateNumberSet();
    }

    // Фабрика для класу DivisibleByThree
    public class DivisibleByThreeFactory : NumberFactory
    {
        public override BaseClass CreateNumberSet()
        {
            return new DivisibleByThree();
        }
    }

    // Фабрика для класу DivisibleByThreePlusOne
    public class DivisibleByThreePlusOneFactory : NumberFactory
    {
        public override BaseClass CreateNumberSet()
        {
            return new DivisibleByThreePlusOne();
        }
    }

    // Фабрика для класу DivisibleByThreePlusTwo
    public class DivisibleByThreePlusTwoFactory : NumberFactory
    {
        public override BaseClass CreateNumberSet()
        {
            return new DivisibleByThreePlusTwo();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Виберіть тип чисел:");
            Console.WriteLine("1. Діляться на 3");
            Console.WriteLine("2. Діляться на 3 із залишком 1");
            Console.WriteLine("3. Діляться на 3 із залишком 2");

            int choice = int.Parse(Console.ReadLine());

            NumberFactory factory = choice switch
            {
                1 => new DivisibleByThreeFactory(),
                2 => new DivisibleByThreePlusOneFactory(),
                3 => new DivisibleByThreePlusTwoFactory(),
                _ => throw new ArgumentException("Невірний вибір")
            };

            // Створення об'єкта за допомогою фабрики
            BaseClass numberSet = factory.CreateNumberSet();
            numberSet.ShowInfo();

            // Введення кількості чисел
            Console.WriteLine("Введіть кількість чисел:");
            int count = int.Parse(Console.ReadLine());
            // Виклик відповідного методу для генерації чисел
            if (numberSet is DivisibleByThree divisibleByThree)
            {
                divisibleByThree.GenerateNumbers(count);
            }
            else if (numberSet is DivisibleByThreePlusOne divisibleByThreePlusOne)
            {
                divisibleByThreePlusOne.GenerateNumbers(count);
            }
            else if (numberSet is DivisibleByThreePlusTwo divisibleByThreePlusTwo)
            {
                divisibleByThreePlusTwo.GenerateNumbers(count);
            }

            Console.WriteLine("Робота програми завершена.");
        }
    }
}