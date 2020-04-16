using System;
using System.Collections.Generic;
using System.Linq;

namespace Domashka5
{
    /// <summary>
    /// Задание 5
    ///   Написать программу: пользователь вводит число от 1 до 9999 (сумму
    /// выдачи в банкомате). Необходимо вывести на экран словами введенную
    /// сумму и в конце написать название валюты с правильным окончанием.
    /// Например: 7431 – семь тысяч четыреста тридцать один доллар, 2149 – две
    /// тысячи сто сорок девять долларов, 15 – пятнадцать долларов, 3 – три
    /// доллара. Для решения этой задачи вам необходимо будет применять
    /// оператор % (остаток от деления).
    /// </summary>
    public class Task5
    {
        public static void Main()
        {
            var numbs = EnterNumber();
            int enterNumber;
            while (!int.TryParse(numbs, out enterNumber))
            {
                Console.WriteLine("Введено не число.");
                numbs = EnterNumber();
            }

            if (enterNumber <= 0 || enterNumber > 9999)
                Console.WriteLine("Число не входит в диапазон от 1 до 9999");
            else
            {
                Console.WriteLine("Вы ввели: ");

                var stringParts = new List<string>{
                    GetThousandthPart(enterNumber),
                    GetHundredthPart(enterNumber),
                    GetDecadesWithCurrencyParts(enterNumber)
                }.Where(s => !string.IsNullOrEmpty(s));

                var result = string.Join(' ', stringParts);
                result = char.ToUpper(result[0]) + result.Substring(1);
                Console.WriteLine(result);
            }
            Console.ReadKey();
        }

        static string EnterNumber()
        {
            Console.Write("Введите число от 1 до 9999: ");
            return Console.ReadLine();
        }

        static string GetThousandthPart(int number)
        {
            var v = (number / 1000) % 10;
            return v switch
            {
                1 => "Одна тысяча",
                2 => "Две тысячи",
                3 => "Три тысячи",
                4 => "Четыре тысячи",
                5 => "Пять тысяч",
                6 => "Шесть тысяч",
                7 => "Семь тысяч",
                8 => "Восемь тысяч",
                9 => "Девять тысяч",
                _ => string.Empty,
            };
        }

        static string GetHundredthPart(int number)
        {
            var v = (number / 100) % 10;
            return v switch
            {
                1 => "сто",
                2 => "двести",
                3 => "триста",
                4 => "четыреста",
                5 => "пятьсот",
                6 => "шестьсот",
                7 => "семьсот",
                8 => "восемьсот",
                9 => "девятьсот",
                _ => string.Empty
            };
        }

        static string GetDecadesWithCurrencyParts(int number)
        {
            var isOneDecade = (number / 10) % 10 == 1;
            var oneDigitNum = number % 10;
            var secondDigitNum = number % 100;
            return isOneDecade
            ? oneDigitNum switch
            {
                0 => "десять долларов",
                1 => "одинадцать долларов",
                2 => "двенадцать долларов",
                3 => "тринадцать долларов",
                4 => "четырнадцать долларов",
                5 => "пятнадцать долларов",
                6 => "шестнадцать долларов",
                7 => "семнадцать долларов",
                8 => "восемнадцать долларов",
                9 => "девятнадцать долларов",
                _ => string.Empty
            } : string.Join(' ',
            new List<string>{
                secondDigitNum switch
                {
                    1 => "десять",
                    2 => "двадцать",
                    3 => "тридцать",
                    4 => "сорок",
                    5 => "пятьдесят",
                    6 => "шестьдесят",
                    7 => "семьдесят",
                    8 => "восемьдесят",
                    9 => "девяносто",
                    _ => string.Empty
                },
                GetUnites(number),
                GetCurrency(number)
            }
            .Where(s => !string.IsNullOrEmpty(s))
            .ToArray());

            string GetUnites(int number)
            {
                var v = number % 10;
                return v switch
                {
                    0 => "долларов",
                    1 => "один",
                    2 => "два",
                    3 => "три",
                    4 => "четыре",
                    5 => "пять",
                    6 => "шесть",
                    7 => "семь",
                    8 => "восемь",
                    9 => "девять",
                    _ => string.Empty
                };
            }

            string GetCurrency(int number)
            {
                var v = number % 10;
                return v switch
                {
                    0 => "долларов",
                    1 => "доллар",
                    2 => "доллара",
                    3 => "доллара",
                    4 => "доллара",
                    5 => "долларов",
                    6 => "долларов",
                    7 => "долларов",
                    8 => "долларов",
                    9 => "долларов",
                    _ => string.Empty
                };
            }
        }
    }
}
