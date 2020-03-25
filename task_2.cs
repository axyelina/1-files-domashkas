using System;

namespace Domashki_2
{
    #region Задача 2.
    /// <summary>
    /// Задание 2
    /// Напишите короткую программу-симулятор падения мячика с башни.
    /// Сначала пользователю предлагается ввести высоту башни в метрах.
    /// Не забывайте о гравитации (9,8м/с2) и о том, что у мячика нет
    /// начальной скорости(он держится в руках). Программа должна выводить
    /// расстояние от земли, на котором находится мячик после 0, 1, 2, 3, 4 и 5
    /// секунд падения.
    /// Минимальная высота: 0 метров (ниже мячику падать нельзя).
    /// В вашей программе должен быть заголовочный файл constants.h с
    /// пространством имён myConstants. В myConstants определите символьную
    /// константу для хранения значения силы тяжести на Земле (9.8).
    /// Требования:
    /// 1) Файл должен состоять из 3 файлов(main.cpp, calc.cpp, calc.h).
    /// 2) Напишите функцию для вычисления высоты мячика через х
    /// секунд падения.Используйте следующую формулу: высота мячика =
    /// константа_гравитации * x_секунд2 / 2.
    /// Пример результата выполнения программы:
    /// Enter the initial height of the tower in meters: 100
    /// At 0 seconds, the ball is at height: 100 meters
    /// At 1 seconds, the ball is at height: 95.1 meters
    /// At 2 seconds, the ball is at height: 80.4 meters
    /// At 3 seconds, the ball is at height: 55.9 meters
    /// At 4 seconds, the ball is at height: 21.6 meters
    /// At 5 seconds, the ball is on the ground.
    /// Примечание №1: В зависимости от начальной высоты, мячик может
    /// и не достичь земли в течение 5 секунд — это нормально.
    /// Примечание №2: Символ ^ не является экспонентом в C++. В
    /// формуле вместо него используйте знак умножения*.
    /// </summary>
    public class Task2
    {
        const double Gravity = 9.8;

        /// <summary>
        /// Считает высоту, на которой находится мячик, падающий с башни height-высотой, спустя n секунд.
        /// </summary>
        /// <returns></returns>
        private static double CalcHeight(int height, int seconds)
        {
            // расстояние от земли до мячика = константа_гравитации * x_секунд ^ 2 / 2.
            var distance = Gravity * Math.Pow(seconds, 2) / 2;
            return height - distance;
        }

        public static void Main()
        {
            Console.Write("Enter the initial height of the tower in meters: ");
            var towerHeightStr = Console.ReadLine();
            var towerHeight = int.Parse(towerHeightStr);
            if (towerHeight < 0)
                throw new ArgumentException("Введена высота ниже минимальной (0 метров)");
            var distance = (double)towerHeight;
            var seconds = 0;
            while (distance > 0)
            {
                Console.WriteLine($"At {seconds} seconds, the ball is at height: {distance:f1} meters");
                seconds++;
                distance = CalcHeight(towerHeight, seconds);
            }
            Console.WriteLine($"At {seconds} seconds, the ball is on the ground");
            Console.ReadKey();
        }
    }

    #endregion
}
