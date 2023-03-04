using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Player : Person // Класс гравець, що наслідує людину
    {
        SQLDatabase database = new SQLDatabase(); //Створення об'єкту классу бази данних
        public enum Result // Поле перелічення результатів ігор
        {
            Win,
            Lose,
            Draw
        }
        public int current_rating = 1000; //Поле рейтингу гравця
        public uint games_count = 0; //Поле кількості ігор гравця
        public Player(string __user_name, string password) //Конструктор об'єкту класса гравця, для нового гравця
        {
            user_name = __user_name; //Присвоєння імені
            user_password = Hashing.HashingPassword(password); //Хешування паролю
            Guid myuuid = Guid.NewGuid(); //Створення об'єкту классу GUID
            user_id = myuuid.ToString(); //Створення айді гравця
        }

        public Player(string __user_id, string __user_name, string __user_password, int __current_rating, uint __games_count) //Конструктор об'єкту класса гравця, для існуючого гравця
        {
            user_name = __user_name; //Присвоєння імені
            user_password = __user_password; //Присвоєння паролю
            user_id = __user_id; //Присвоєння айді
            current_rating = __current_rating; //Присвоєння рейтингу
            games_count = __games_count; //Присвоєння кількості ігор
        }


        public override void Win_Game(Player opponent, int rating) //Перезавантаження функції перемоги у грі
        {
            if (rating > 0) //Перевірка на рейтинг гри
            {
                Game game_for_this_player = new Game(this.user_id, opponent.user_id, this.user_name, opponent.user_name, rating, Result.Win); //створення об'єкту гри для гравця
                Game game_for_opponent = new Game(opponent.user_id, this.user_id, opponent.user_name, this.user_name, rating, Result.Lose); //сворення об'єккту гри для опонента
                this.current_rating += rating; //Зміна рейтину для гравця
                opponent.current_rating -= rating; //Зміна рейтингу для опонента
                if (opponent.current_rating < 1) //Перевірка на рейтинг менше 1
                    opponent.current_rating = 1;
                database.AddGame(game_for_this_player); //Додавання до бази гри гравця
                database.AddGame(game_for_opponent); //Додавання до бази гри опонента
                this.games_count++; //Збільшення кількості ігор гравця
                opponent.games_count++; //Збільшення кількості ігор опонента
                database.UpdateInfo(this.user_name, this.current_rating, this.games_count); //Оновлення інформації у базі про гравця
                database.UpdateInfo(opponent.user_name, opponent.current_rating, opponent.games_count); //Оновлення інформації у базі про опонента
            }
            else
            {
                Console.WriteLine("Rating for game below 0"); //Якщо рейтинг гри менше 0
            }
        }

        public override void Lose_Game(Player opponent, int rating) //Перезавантаження функції програшу у грі
        {
            if (rating > 0) //Перевірка на рейтинг гри
            {
                Game game_for_this_player = new Game(this.user_id, opponent.user_id, this.user_name, opponent.user_name, rating, Result.Lose);//створення об'єкту гри для гравця
                Game game_for_opponent = new Game(opponent.user_id, this.user_id, opponent.user_name, this.user_name, rating, Result.Win);//сворення об'єккту гри для опонента
                this.current_rating -= rating; //Зміна рейтину для гравця
                if (this.current_rating < 1)//Перевірка на рейтинг менше 1
                    this.current_rating = 1;
                opponent.current_rating += rating;//Зміна рейтингу для опонента
                database.AddGame(game_for_this_player);//Додавання до бази гри гравця
                database.AddGame(game_for_opponent);//Додавання до бази гри опонента
                this.games_count++; //Збільшення кількості ігор гравця
                opponent.games_count++; //Збільшення кількості ігор опонента
                database.UpdateInfo(this.user_name, this.current_rating, this.games_count); //Оновлення інформації у базі про гравця
                database.UpdateInfo(opponent.user_name, opponent.current_rating, opponent.games_count); //Оновлення інформації у базі про опонента
            }
            else
            {
                Console.WriteLine("Rating for game below 0"); //Якщо рейтинг гри менше 0
            }
        }

        public override void Draw_Game(Player opponent, int rating) //Перезавантаження функції нічиї у грі
        {
            Game game_for_this_player = new Game(this.user_id, opponent.user_id, this.user_name, opponent.user_name, rating, Result.Draw);//створення об'єкту гри для гравця
            Game game_for_opponent = new Game(opponent.user_id, this.user_id, opponent.user_name, this.user_name, rating, Result.Draw);//сворення об'єккту гри для опонента
            database.AddGame(game_for_this_player);//Додавання до бази гри гравця
            database.AddGame(game_for_opponent);//Додавання до бази гри опонента
            this.games_count++; //Збільшення кількості ігор гравця
            opponent.games_count++; //Збільшення кількості ігор опонента
            database.UpdateInfo(this.user_name, this.current_rating, this.games_count); //Оновлення інформації у базі про гравця
            database.UpdateInfo(opponent.user_name, opponent.current_rating, opponent.games_count); //Оновлення інформації у базі про опонента
        }
    }

}

