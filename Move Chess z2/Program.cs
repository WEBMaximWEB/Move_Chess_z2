using System;
using System.Security.Cryptography.X509Certificates;

namespace ChessMove
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] array = {
                { "A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1"},
                { "A2", "B2", "C2", "D2", "E2", "F2", "G2", "H2"},
                { "A3", "B3", "C3", "D3", "E3", "F3", "G3", "H3"},
                { "A4", "B4", "C4", "D4", "E4", "F4", "G4", "H4"},
                { "A5", "B5", "C5", "D5", "E5", "F5", "G5", "H5"},
                { "A6", "B6", "C6", "D6", "E6", "F6", "G6", "H6"},
                { "A7", "B7", "C7", "D7", "E7", "F7", "G7", "H7"},
                { "A8", "B8", "C8", "D8", "E8", "F8", "G8", "H8"},
            };

            string SPosition, EPosition, buchstabe, buchstabe1;
            int Zahl, Zahl1;

            Console.Write("Начальное ");
            SPosition = Check();
            //деление на число и букву
            Zahl = int.Parse(SPosition.Substring(1));
            buchstabe = SPosition.Substring(0, 1).ToUpper();

            CheckN(Zahl);
            CheckB(buchstabe);
            // конвертирование
            SPosition = buchstabe + Zahl;
            int[] StartPosition = Coordination(array, SPosition);


            // Конечная позиция
            Console.Write("Конечное ");
            EPosition = Check();
            Zahl1 = int.Parse(EPosition.Substring(1));
            buchstabe1 = EPosition.Substring(0, 1).ToUpper();

            CheckN(Zahl1);
            CheckB(buchstabe1);
            // конвертирование
            EPosition = buchstabe1 + Zahl1;
            int[] EndPosition = Coordination(array, EPosition);


            Console.Write("Напишите стандартное обозначение фигуры, которую собируетесь проверить");
            string piece = Console.ReadLine();

            if (piece == "К" || piece == "N")
                Horse(StartPosition[0], StartPosition[1], EndPosition[0], EndPosition[1]);
            else if (piece == "Кр" || piece == "K")
                King(StartPosition[0], StartPosition[1], EndPosition[0], EndPosition[1]);
            else if (piece == "Л" || piece == "R")
                Rook(StartPosition[0], StartPosition[1], EndPosition[0], EndPosition[1]);
            else if (piece == "С" || piece == "B")
                Bishop(StartPosition[0], StartPosition[1], EndPosition[0], EndPosition[1]);
            else if (piece == "Ф" || piece == "Q")
                Queen(StartPosition[0], StartPosition[1], EndPosition[0], EndPosition[1]);
            else if (piece == "п" || piece == "p" || piece == " ")
                Pawn(StartPosition[0], StartPosition[1], EndPosition[0], EndPosition[1]);
            else
                Console.WriteLine("Вы ввели неправильное значеине");
        }

        public static string Check()
        {
            Console.Write("положение фигуры:");
            string SPosition;
            SPosition = Console.ReadLine();
            if (SPosition.Length != 2)
            {
                Console.WriteLine("Вы явно допустили ошибку");
                Check();
            }

            return SPosition;
        }


        public static int[] Coordination(string[,] array1, string Position)
        {
            int[] a = { 0, 0 };
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (array1[i, j] == Position)
                    {
                        a[0] = i;
                        a[1] = j;
                    }
                }
            }
            return a;
        }

        public static void CheckN(int Zahl)
        {
            // проверка числа
            bool T = false;
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            foreach (int i in numbers)
            {
                if (Zahl == i)
                    T = true;
            }
            if (T == false)
                Console.WriteLine("У вас ошибка при вводе строки поля");
        }

        public static void CheckB(string buchstabe)
        {
            // проверка буквы
            bool T = false;
            string[] bs = { "A", "B", "C", "D", "E", "F", "G", "H" };
            foreach (string i in bs)
            {
                if (buchstabe == i)
                    T = true;
            }
            if (T == false)
                Console.WriteLine("У вас ошибка при вводе столбца поля");
        }
        public static void Horse(int x, int y, int x1, int y1)
        {
            if (((Math.Abs(x1 - x) == 2) && (Math.Abs(y1 - y) == 1)) || ((Math.Abs(x1 - x) == 1) && (Math.Abs(y1 - y) == 2)))
                Console.WriteLine("Все ок");
            else
                Console.WriteLine("Такого хода не существует");
        }

        public static void King(int x, int y, int x1, int y1)
        {
            if (((Math.Abs(x1 - x) == 1) || (Math.Abs(x1 - x) == 0)) && ((Math.Abs(y1 - y) == 1) || (Math.Abs(y1 - y) == 0)))
                Console.WriteLine("Все ок");
            else
                Console.WriteLine("Такого хода не существует");
        }

        public static void Rook(int x, int y, int x1, int y1)
        {
            if ((Math.Abs(x1 - x) == 0) || (Math.Abs(y1 - y) == 0))
                Console.WriteLine("Все ок");
            else
                Console.WriteLine("Такого хода не существует");
        }

        public static void Bishop(int x, int y, int x1, int y1)
        {
            if (Math.Abs(x1 - x) == Math.Abs(y1 - y))
                Console.WriteLine("Все ок");
            else
                Console.WriteLine("Такого хода не существует");
        }

        public static void Queen(int x, int y, int x1, int y1)
        {
            if ((Math.Abs(x1 - x) == Math.Abs(y1 - y)) || ((Math.Abs(x1 - x) == 0) || (Math.Abs(y1 - y) == 0)))
                Console.WriteLine("Все ок");
            else
                Console.WriteLine("Такого хода не существует");
        }

        public static void Pawn(int x, int y, int x1, int y1)
        {
            if (Math.Abs(x1 - x) == 1 && Math.Abs(y1 - y) == 0)
                Console.WriteLine("Все ок");
            else
                Console.WriteLine("Такого хода не существует");
        }
    }
}