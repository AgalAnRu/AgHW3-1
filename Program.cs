using System;
using System.Threading;

namespace AgHW3_1
{
    internal class Program
    {
        static string promtPressAnyKey = "Нажмите любую клавишу для продолжения...";
        private static GetInput getInput = new GetInput();
        static void Main(string[] args)
        {

            Print1();
            NextScreen();
            Print2();
            NextScreen();
            Print3();
            NextScreen();
            Print4();
            NextScreen();
        }
        static void NextScreen()
        {
            Console.WriteLine(promtPressAnyKey);
            Console.ReadKey();
        }
        static void Print1()
        {
            Console.Clear();
            Console.WriteLine("Вывод цифр 0...9 (используется for)");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void Print2()
        {
            Console.Clear();
            Console.WriteLine("Вывод чисел 10...1 (используется for)");
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine(i);
            }
        }
        static void Print3()
        {
            uint maxValue = 0;
            Console.Clear();
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
        static void Print4()
        {
            Random rnd = new Random();
            Console.Clear();
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
            for (int i = 0; i < maxValue; i++)
            {
                Console.WriteLine(rnd.Next(minValue, (maxValue + 1)));
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
                {
                    return result;
                }
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
                {
                    return result;
                }

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
