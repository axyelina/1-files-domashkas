using System;

namespace Domashki_3
{
    #region Задача 3.
    ///<summary>
    /// Задание 3.
    /// Напишите программу, которая просит пользователя ввести число от 0 до 255 (0105 5879).
    /// Выведите его как 8-битное двоичное число(в парах по 4 цифры).
    /// Не используйте побитовые операторы
    /// Пример результата выполнения программы:
    /// Число 255 = 1111 1111
    /// </summary>

    public class Task3
    {
        public static int CalcIt(int x, int multiplier)
        {
            var digit = x >= multiplier ? 1 : 0;
            Console.Write(digit);

            return x >= multiplier ? x - multiplier : x;
        }
        public static void Main()
        {
            Console.Write("Введите число от 0 до 255: ");
            var y = Console.ReadLine();
            var x = int.Parse(y);
            var multipliers = new[] { 128, 64, 32, 16, 8, 4, 2, 1 };

            var count = 0;
            foreach (var multiplier in multipliers)
            {
                if (count > 0 && count % 4 == 0)
                    Console.Write(" ");
                x = CalcIt(x, multiplier);
                count++;
            }
            Console.ReadKey();
        }
    }
    #endregion
}
