using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game // Класс гри
    {
        public string Person1_id; //Поле айді головного гравця
        public string Person2_id;//Поле айді опонента
        public string Person1_name;//Поле імені гравця
        public string Person2_name;//Поле імені опонента
        public int Rating;//Поле рейтинга гри
        public string IDOfGame;//Поле айді гри
        public string Result;//Поле результату
        public Game(string __person1, string __person2, string __person1_name, string __person2_name, int __rating, Player.Result __result) //Конструктор об'єкту класса гри
        {
            Person1_id = __person1;//Присвоєння айді гравця
            Person2_id = __person2;//Присвоєння айді опонента
            Person1_name = __person1_name;//Присвоєння імені гравця
            Person2_name = __person2_name;//Присвоєння імені опонента
            Rating = __rating;//Присвоєння рейтингу
            if (__result == Player.Result.Win)//Присвоєння результату
                Result = "Win";
            else
                if (__result == Player.Result.Lose)
                    Result = "Lose";
                else
                    Result = "Draw";

            Guid myuuid = Guid.NewGuid();// Створення об'єкту классу GUID
            IDOfGame = myuuid.ToString();//Створення айді гравця
        }
    }
}
