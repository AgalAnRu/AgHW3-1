using System;
using System.Threading;

namespace AgHW3_1
{
    internal class Program
    {
        static string promtPressAnyKey = "Нажмите любую клавишу для продолжения...";
        static void Main(string[] args)
        {
            
            Print1();
            Console.WriteLine(promtPressAnyKey);
            Console.ReadKey();
            Print2();
            Console.WriteLine(promtPressAnyKey);
            Console.ReadKey();
            Print3();
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
            GetInput getInput = new GetInput();
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
    }
    internal class GetInput
    {
        internal ushort Uint16()
        {
            //uint result;
            string inputStr = string.Empty;
            while (true)
            {
                Console.WriteLine("Введите число в пределах 0...65535 и нажмите Enter");
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
