using System;

namespace AgHW3_1
{
    internal class Program
    {
        static string promtPressAnyKey = "Нажмите любую клавишу для продолжения...";
        private static GetInput getInput = new GetInput();
        private static Random rnd = new Random();
        delegate void method();
        static string[] menuItems = new string[8];
        static void Main(string[] args)
        {
            MenuInitialization();
            method[] methods = new method[] { Task1Part1, Task1Part2, Task1Part3, Task1Part4,
                Task2, Task3, Task4, QuitFromConsole};
            int selectedMenuItem;
            AgMenu menu = new AgMenu(menuItems);
            do
            {
                selectedMenuItem = menu.ShowMenu();
                Console.Clear();
                methods[selectedMenuItem]();
                if (selectedMenuItem == menuItems.Length - 1)
                    continue;
                NextScreen();
            } while (selectedMenuItem != menuItems.Length - 1);
        }
        static void MenuInitialization()
        {
            menuItems[0] = "Задача 1. Часть 1";
            menuItems[1] = "Задача 1. Часть 2";
            menuItems[2] = "Задача 1. Часть 3";
            menuItems[3] = "Задача 1. Часть 4";
            menuItems[4] = "Задача 2.";
            menuItems[5] = "Задача 3";
            menuItems[6] = "Задача 4";
            menuItems[7] = "Выход";
        }
        static void QuitFromConsole()
        {
            //NextScreen();
        }
        static void NextScreen()
        {
            Console.WriteLine(promtPressAnyKey);
            Console.ReadKey();
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
            Console.WriteLine("Вывод целых положительных чисел (кратных 3 или 5) до заданного числа (используется for)");
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
                    minPrime = (ushort)i;
                    break;
                }
            }
            for (int i = (value + 1); i <= ushort.MaxValue; i++)
            {
                if (IsPrime(i))
                {
                    maxPrime = (ushort)i;
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
                for (int i = 2; i <= number / 2; i++)
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
            Console.WriteLine($"(Введите число в пределах {diapazon} и нажмите Enter)");
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
    internal class AgMenu
    {
        string[] menuItems;
        int counter;
        internal AgMenu(string[] menuItems) => this.menuItems = menuItems;
        internal int ShowMenu()
        {
            ConsoleKey key;
            do
            {
                Console.Clear();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == counter)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(menuItems[i]);
                    if (i == counter)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.WriteLine("(Выберите пункт меню и нажмите Enter " +
                    "или нажмите Escape для выхода)");
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == menuItems.Length)
                        counter = 0;
                }
                if (key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1)
                        counter = menuItems.Length - 1;
                }
            } while (key != ConsoleKey.Enter && key != ConsoleKey.Escape);
            if (key == ConsoleKey.Escape)
                counter = menuItems.Length - 1;
            return counter;
        }
    }
}
