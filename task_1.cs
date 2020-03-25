using System;

namespace Domashki_1
{
    #region Задача 1.

    /// <summary>
    /// Задание 1
    /// Написать программу которая просит пользователя ввести два числа.
    /// Затем возвращает сумму и произведение двух чисел.
    /// Требования:
    /// 1) Файл должен состоять из 3 файлов(main.cpp, calc.cpp, calc.h).
    /// 2) Необходимо объявить функции в calc.cpp:
    /// - Функция ввода: int getNum();
    /// - Функция вывода: void printNum(double num);
    /// - Фунция сложения: double sumNums(double num1, double num2);
    /// - Фунция умножения: double mulNums(double num1, double num2);
    /// </summary>

    public class Task1
    {
        public double getNum()
        {
            var str = Console.ReadLine();
            return double.Parse(str);
        }

        public double mulNums(double left, double right)
        {
            return left * right;
        }

        public void printNum(double num)
        {
            Console.WriteLine(num);
        }

        public double sumNums(double left, double right)
        {
            return left + right;
        }

        public void Main()
        {
            var solver = new Task1();
            Console.Write("Введите первое число: ");
            var left = solver.getNum();
            Console.Write("Введите второе число: ");
            var right = solver.getNum();
            var sumResult = solver.sumNums(left, right);
            var mulResult = solver.mulNums(left, right);
            solver.printNum(sumResult);
            solver.printNum(mulResult);

            Console.ReadLine();
        }
    }
    #endregion
}
