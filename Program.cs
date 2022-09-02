using System;
using System.Threading;

namespace AgHW3_1
{
    internal class Program
    {
        static string promtPressAnyKey = "Нажмите любую клавишу для продолжения...";
        private static GetInput getInput = new GetInput();
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            Task1Part1();
            NextScreen();
            Task1Part2();
            NextScreen();
            Task1Part3();
            NextScreen();
            Task1Part4();
            NextScreen();
            Task2();
            NextScreen();
            Task3();
            NextScreen();
            Task4();
            NextScreen();
        }
        static void NextScreen()
        {
            Console.WriteLine(promtPressAnyKey);
            Console.ReadKey();
            Console.Clear();
        }
        static void Task1Part1()
        {
            Console.WriteLine("Вывод цифр 0...9 (используется for)");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void Task1Part2()
        {
            Console.WriteLine("Вывод чисел 10...1 (используется for)");
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine(i);
            }
        }
        static void Task1Part3()
        {
            uint maxValue = 0;
            Console.WriteLine("Вывод целых положительных чисел до заданного числа (используется for)");
            maxValue = getInput.Uint16();
            for (int i = 1; i < maxValue; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine($"{i}\t- кратно 3");
                }
                if (i % 5 == 0)
                {
                    Console.WriteLine($"{i}\t- кратно 5");
                }
            }
        }
        static void Task1Part4()
        {
            Console.WriteLine("Вывод случайного ряда целых чисел");
            Console.WriteLine("Введите границы диапазона:");
            short minValue = getInput.Int16();
            short maxValue = getInput.Int16();
            Console.WriteLine("Введите число повторений:");
            byte numberDice = getInput.Byte();
            if (minValue > maxValue)
            {
                short val = maxValue;
                maxValue = minValue;
                minValue = val;
            }
            for (int i = 0; i < numberDice; i++)
            {
                Console.WriteLine(rnd.Next(minValue, (maxValue + 1)));
            }
        }
        static void Task2()
        {
            Console.WriteLine("Введите строку символов и нажмите Enter");
            string inputString = Console.ReadLine();
            bool isEvenNumber = false;
            foreach (char ch in inputString)
            {
                if (isEvenNumber)
                    Console.Write(Char.ToUpper(ch));
                else
                    Console.Write(Char.ToLower(ch));
                isEvenNumber = !isEvenNumber;
            }
            Console.WriteLine();
        }
        static void Task3()
        {
            Console.WriteLine("Поиск близжайшего простого числа " +
                "в пределах 0...65535 от введённого");
            ushort minPrime = 0;
            ushort maxPrime = 0;
            ushort value = getInput.Uint16();

            for (int i = (value - 1); i > 0; i--)
            {
                if (IsPrime(i))
                {
                    minPrime = (ushort) i;
                    break;
                }
            }
            for (int i = (value + 1); i <= ushort.MaxValue; i++)
            {
                if (IsPrime(i))
                {
                    maxPrime = (ushort) i;
                    break;
                }
            }
            Console.Write("Близжайшее простое число: ");
            if (minPrime == 0)
            {
                Console.WriteLine(maxPrime);
                return;
            }
            if (maxPrime == 0)
            {
                Console.WriteLine(minPrime);
                return;
            }
            if ((value - minPrime) < (maxPrime - value))
                Console.WriteLine(minPrime);
            if ((value - minPrime) > (maxPrime - value))
                Console.WriteLine(maxPrime);
            if ((value - minPrime) == (maxPrime - value))
                Console.WriteLine($"слева - {minPrime}, справа - {maxPrime}");
            return;

            bool IsPrime(int number)
            {
                for (int i = 2; i <= number/2; i++)
                {
                    if (number % i == 0)
                        return false;
                }
                return true;
            }
        }
        static void Task4()
        {
            byte numberTypes = 0;
            while (numberTypes == 0)
            {
                Console.WriteLine("Введите количество томов");
                numberTypes = getInput.Byte();
            }
            int[] types = new int[numberTypes];
            int volumeAllPages = rnd.Next(8000, 10001);
            int volumeSet = 0;
            int tail = 0;
            int tailCount = 0;
            Console.WriteLine($"Всего в наличии {volumeAllPages} листов");
            Console.WriteLine($"Один набор состоит из {numberTypes} томов");
            for (int i = 0; i < numberTypes; i++)
            {
                types[i] = rnd.Next(50, 201);
                Console.WriteLine($"Том {i + 1} - {types[i]} листов.");
                volumeSet += types[i];
            }
            Console.WriteLine($"Всего набор состоит из {volumeSet} листов");
            Console.WriteLine($"Можно изготовить {volumeAllPages / volumeSet} полных наборов");
            tail = volumeAllPages % volumeSet;
            if (tail > types[0])
            {
                Console.WriteLine("Дополнительно можно напечатать:");
                while (tail > 0)
                {
                    tail -= types[tailCount];
                    if (tail > 0)
                    {
                        tailCount++;
                        Console.WriteLine($"Том {tailCount}");
                    }
                }
            }
        }
    }
    internal class GetInput
    {
        private void PromtInputFromDiapazon(string str)
        {
            string diapazonShot = "-32 768...32 767";
            string diapazonUshot = "0...65535";
            string diapazonByte = "0...255";
            string diapazon = "";
            switch (str)
            {
                case "short":
                    diapazon = diapazonShot;
                    break;
                case "ushort":
                    diapazon = diapazonUshot;
                    break;
                case "byte":
                    diapazon = diapazonByte;
                    break;
            }
            Console.WriteLine($"Введите число в пределах {diapazon} и нажмите Enter");
        }
        internal byte Byte()
        {
            string inputStr = string.Empty;
            while (true)
            {
                PromtInputFromDiapazon("byte");
                inputStr = Console.ReadLine();
                if (byte.TryParse(inputStr, out byte result))
                {
                    return result;
                }
            }
        }
        internal short Int16()
        {
            string inputStr = string.Empty;
            while (true)
            {
                PromtInputFromDiapazon("short");
                inputStr = Console.ReadLine();
                if (short.TryParse(inputStr, out short result))
                    return result;
            }
        }
        internal ushort Uint16()
        {
            string inputStr = string.Empty;
            while (true)
            {
                PromtInputFromDiapazon("ushort");
                inputStr = Console.ReadLine();
                if (ushort.TryParse(inputStr, out ushort result))
                    return result;
            }
        }
        internal double Double(string _askDouble)
        {
            string _str = string.Empty;
            char c;
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            char separateChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            if (Console.CursorLeft > 0) _askDouble = "\n" + _askDouble;
            Console.Write(_askDouble);
            while (true)
            {
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Backspace && _str.Length > 0)
                {
                    _str = _str.Remove(_str.Length - 1);
                    Console.Write("\b \b");
                    continue;
                }
                c = cki.KeyChar;
                if (c == '.' || c == ',')
                {
                    c = separateChar;
                }
                _str += c.ToString();
                if ((c == separateChar || c == '-') && _str.Length == 1)
                {
                    Console.Write(c);
                    continue;
                }

                if (double.TryParse(_str, out double result))
                    Console.Write(c);
                else
                    _str = _str.Remove(_str.Length - 1);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return result;
                }
            }
        }
    }
}
