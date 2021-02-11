using System;
using static Matrix.Const;

namespace Matrix
{
    static class Const
    {
        public const int WIDTH    = 30;    //Ширина поля

        public const int HIGHT    = 35;    //Высота поля

        public const int SIZE     = 50;    //Размер символа

        public const int BGN_KTK  = 12449; //Начальное значение Unicode Katakana

        public const int END_KTK  = 12539; //Конечное значение Unicode Katakana

        public const int RUN_CHAR = 40;    //Колличество бегущих столбцов
    }

    static class Func
    {
        public static Random rand = new Random();
        public static string GetRandString()
        {
            if (rand.Next(0, 2) == 1)
                return ((char)rand.Next(BGN_KTK, END_KTK)).ToString();
            else
                return rand.Next(0, 10).ToString();
        }
    }
}