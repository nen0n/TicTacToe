using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Field // Класс поля
    {
        private List<string> field = new List<string> // Поле списку стрінгів для графічного виводу поля
        { "╔═══════╦═══════╦═══════╗",
          "║       ║       ║       ║",
          "║       ║       ║       ║",
          "║   0   ║   1   ║   2   ║",
          "║       ║       ║       ║",
          "║       ║       ║       ║",
          "╠═══════╬═══════╬═══════╣",
          "║       ║       ║       ║",
          "║       ║       ║       ║",
          "║   3   ║   4   ║   5   ║",
          "║       ║       ║       ║",
          "║       ║       ║       ║",
          "╠═══════╬═══════╬═══════╣",
          "║       ║       ║       ║",
          "║       ║       ║       ║",
          "║   6   ║   7   ║   8   ║",
          "║       ║       ║       ║",
          "║       ║       ║       ║",
          "╚═══════╩═══════╩═══════╝"
        };
        private List<string> o_sign = new List<string> // Поле списку стрінгів для графічного виводу нуля
        {
            " 00000 ",
            "00   00",
            "00   00",
            "00   00",
            " 00000 "
        };
        private List<string> x_sign = new List<string> // Поле списку стрінгів для графічного виводу хрестика
        {
            "xx   xx",
            "  x x  ",
            "   x   ",
            "  x x  ",
            "xx   xx"
        };

        public int[,] turn_field = new int[3, 3] // Поле масиву для збереження ходів гравців
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };

        public void Print_Field() // Метод виведення поля 
        {
            for(int i=0; i < field.Count; i++) // Цикл, що йде по всім строкам списку поля
                Console.WriteLine(field[i]); // Виведення строки поля
        }

        public void Insert_X_Sign(int position) // Метод вставки у поле хрестика
        {
            int y_position = position / 3; //Знаходження у координати
            int x_position = position % 3; //Знаходження х координати
            for (int i = 0; i < 5; i++) //Цикл, що йде по списку хрестика
            {
                field[1 + i + y_position * 6] = field[1 + i + y_position * 6].Remove(1 + x_position * 8, 7); //Видалення строки із поля
                field[1 + i + y_position * 6] = field[1 + i + y_position * 6].Insert(1 + x_position * 8, x_sign[i]); //Вставка у поле строки хрестика
            }
        }
        public void Insert_O_Sign(int position) // Метод вставки у поле нулика
        {
            int y_position = position / 3; //Знаходження у координати
            int x_position = position % 3; //Знаходження х координати
            for (int i = 0; i < 5; i++) //Цикл, що йде по списку нулика
            {
                field[1 + i + y_position * 6] = field[1 + i + y_position * 6].Remove(1 + x_position * 8, 7); //Видалення строки із поля
                field[1 + i + y_position * 6] = field[1 + i + y_position * 6].Insert(1 + x_position * 8, o_sign[i]); //Вставка у поле строки хрестика
            }
        }

        public void Insert_Win_Line(int start, int end) // Метод вставки у поле переможної лінії
        {
            int start_y_position = start / 3; // Знаходження у координати початку
            int start_x_position = start % 3; // Знаходження х координати початку
            int end_y_position = end / 3; // Знаходження у координати кінця
            int end_x_position = end % 3; // Знаходження х координати кінця

            if (end_x_position != start_x_position && end_y_position != start_y_position) // Перевірка чи є переможна лінія діагональною
            {
                if(start_x_position == 0) // Перевірка чи переможна лінія лежить на головній лінії
                {
                    for (int y = 0; y < 3; y++) // Цикл вставки переможної лінії
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            field[1 + y * 6 + i] = field[1 + y * 6 + i].Remove(2 + (y) * 8 + i, 1); //Видалення
                            field[1 + y * 6 + i] = field[1 + y * 6 + i].Insert(2 + (y) * 8 + i, "*"); //Вставка
                        }
                    }
                }
                else // Вставка переможної лінії на побічній діагоналі
                {
                    for (int y = 0; y < 3; y++)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            field[1 + y * 6 + i] = field[1 + y * 6 + i].Remove(6 + (2 - y) * 8 - i, 1); //Видалення 
                            field[1 + y * 6 + i] = field[1 + y * 6 + i].Insert(6 + (2 - y) * 8 - i, "*"); //Вставка
                        }
                    }
                }
            }
            else
            {
                if (end_y_position == start_y_position) // Якщо переможна лінія горизонтальна
                {
                    for(int x = 0; x < 3; x++)
                    {
                        for(int i = 0; i < 7; i++)
                        {
                            field[3 + start_y_position * 6] = field[3 + start_y_position * 6].Remove(1 + x * 8 + i, 1);
                            field[3 + start_y_position * 6] = field[3 + start_y_position * 6].Insert(1 + x * 8 + i, "*");
                        }
                    }
                }
                else // Якщо переможна лінія вертикальна
                {
                    for (int y = 0; y < 3; y++)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            field[1 + y * 6 + i] = field[1 + y * 6 + i].Remove(4 + start_x_position * 8, 1);
                            field[1 + y * 6 + i] = field[1 + y * 6 + i].Insert(4 + start_x_position * 8, "*");
                        }
                    }
                }
            }
            
        }
        public int Check_Winner() //Перевірка чи після ходу вийграв якийсь гравець
        {
            for (int i = 0; i < 3; i++)
            {
                if (turn_field[i, 0] == turn_field[i, 1] && turn_field[i, 0] == turn_field[i, 2] && turn_field[i, 0] != 0) // Перевірка вертикалі
                    return turn_field[i, 0]; //Повернення переможця
                if (turn_field[0, i] == turn_field[1, i] && turn_field[0, i] == turn_field[2, i] && turn_field[0, i] != 0) // Перевірка горизонталі
                    return turn_field[i, 0]; //Повернення переможця
            }
            if(turn_field[0, 0] == turn_field[1, 1] && turn_field[0, 0] == turn_field[2, 2] && turn_field[0, 0] != 0) //Перевірка головної діагоналі
                return turn_field[1, 1]; //Повернення переможця
            if (turn_field[0, 2] == turn_field[1, 1] && turn_field[0, 2] == turn_field[2, 0] && turn_field[2, 0] != 0) //Перевірка побічної діагоналі
                return turn_field[1, 1]; //Повернення переможця
            return 0; //Якщо не має переможця
        }

        public void Check_Win_Line() // Вставка переможної лінії на поле
        {
            for (int i = 0; i < 3; i++)
            {
                if (turn_field[i, 0] == turn_field[i, 1] && turn_field[i, 0] == turn_field[i, 2] && turn_field[i, 0] != 0)// Перевірка вертикалі
                    Insert_Win_Line(i, i + 6); //Вставка лінії
                if (turn_field[0, i] == turn_field[1, i] && turn_field[0, i] == turn_field[2, i] && turn_field[0, i] != 0)// Перевірка горизонталі
                    Insert_Win_Line(3 * i, 3 * i + 2);//Вставка лінії
            }
            if (turn_field[0, 0] == turn_field[1, 1] && turn_field[0, 0] == turn_field[2, 2] && turn_field[0, 0] != 0)//Перевірка головної діагоналі
                Insert_Win_Line(0, 8);//Вставка лінії
            if (turn_field[0, 2] == turn_field[1, 1] && turn_field[0, 2] == turn_field[2, 0] && turn_field[2, 0] != 0) //Перевірка побічної діагоналі
                Insert_Win_Line(2, 6);//Вставка лінії
        }

        public void Clear_Fields() //Метод очищення полів
        {
            field = new List<string> //Переприсвоєння візуального поля на чисте
            {
              "╔═══════╦═══════╦═══════╗",
              "║       ║       ║       ║",
              "║       ║       ║       ║",
              "║   0   ║   1   ║   2   ║",
              "║       ║       ║       ║",
              "║       ║       ║       ║",
              "╠═══════╬═══════╬═══════╣",
              "║       ║       ║       ║",
              "║       ║       ║       ║",
              "║   3   ║   4   ║   5   ║",
              "║       ║       ║       ║",
              "║       ║       ║       ║",
              "╠═══════╬═══════╬═══════╣",
              "║       ║       ║       ║",
              "║       ║       ║       ║",
              "║   6   ║   7   ║   8   ║",
              "║       ║       ║       ║",
              "║       ║       ║       ║",
              "╚═══════╩═══════╩═══════╝" 
              };

            turn_field = new int[3, 3] //Переприсвоєння поля ходів гравців
            {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
            };
        }
    }
}
