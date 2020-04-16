using System;
using System.Collections.Generic;
namespace Domashka4
{
    #region Задача 4.
    /// <summary>
    /// Задание 4
    /// Написать программу «Депозитный калькулятор», которая выводит
    ///     прибыль, которую получит пользователь. Пользователь вводит сумму
    ///     депозита и количество месяцев хранения денег в банке.
    ///     Необходимо провести расчет и 
    ///     1. показать на экран прибыль с депозита в месяц, 
    ///     2. за весь срок депозита, 
    ///     3. общую сумму к выплате в конце срока.
    ///     Валюта пусть будет – доллар США. Процентная ставка – 5%
    ///     годовых.Формула расчета процентов в месяц –
    ///     СуммаДепозита * (ПроцентнаяСтавка / 100) * ДнейВМесяце / ДнейВГоду 
    /// </summary>
    public class task_4
    {
        const int InterestRate = 5;
        const decimal AverageDaysInMonth = 29.3M;
        const decimal AverageDaysInYear = 365.25M;

        public static decimal CalcPercentsInMonth(decimal deposite)
        {
            var interestRatePercents = InterestRate / 100M;
            // СуммаДепозита * (ПроцентнаяСтавка / 100) * ДнейВМесяце / ДнейВГоду.
            return deposite * interestRatePercents * AverageDaysInMonth / AverageDaysInYear;
        }

        public static decimal CalcPercentsInYear(decimal deposite)
            => 12 * CalcPercentsInMonth(deposite);

        public static decimal CalcWholePeriodSum(decimal deposite, int months)
            => deposite + months * CalcPercentsInMonth(deposite);

        public static void Main4()
        {
            //Ввод депозита
            Console.WriteLine("Введите сумму депозита");
            var deposite = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество месяцев вклада");
            var time = int.Parse(Console.ReadLine());

            var outputStrings = new List<string>{
                { $"Прибыль с процентов в месяц: {CalcPercentsInMonth(deposite):f2}" },
                { $"Прибыль с процентов в год: {CalcPercentsInYear(deposite):f2}" },
                { $"Общая сумма выплаты в конце срока: {CalcWholePeriodSum(deposite, time):f2}" }
            };

            outputStrings.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
    #endregion
}
