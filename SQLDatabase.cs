using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace TicTacToe
{
    class SQLDatabase // Класс датабази
    {
        private string myConnectionString = "server=127.0.0.1;uid=root;pwd=DOM435tnt;database=tictactoe"; //Поле конфігурації підключення до MySQL

        public Player Registration(string name, string password) //Метод реєстрації гравця що повертає гравця і додає його до бази
        {
            Player new_player = new Player(name, password); //Створення об'єкту классу гравець

            MySql.Data.MySqlClient.MySqlConnection conn; //Створення підлючення
            conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString); //Під'єднання
            conn.Open(); //Відкриття бази
            MySqlCommand comm = conn.CreateCommand(); //Створення команди


            MySqlCommand cmd = conn.CreateCommand(); //Створення команди
            cmd.CommandText = "SELECT * FROM Player WHERE user_name ='" + name + "'"; //Команда яка повертає гравця із бази по імені
            MySqlDataReader reader = cmd.ExecuteReader(); //Створення зчитувача
            while (reader.Read()) //Цикл, що йде поки зчитується
            {
                if(reader["user_id"].ToString() != "") //Перевірка чи є вже такий гравець у базі
                {
                    return null; //Повернення помилки
                }
            }
            reader.Close(); //Закриття зчитувача
            comm.CommandText = "INSERT INTO Player(user_id, user_name, user_password, current_rating, games_count) VALUES (@user_id, @user_name, @user_password, @current_rating, @games_count)"; //Команда вставки об'єкта гравця у базу
            comm.Parameters.AddWithValue("@user_id", new_player.user_id); //Вставка у команду параметру
            comm.Parameters.AddWithValue("@user_name", new_player.user_name);//Вставка у команду параметру
            comm.Parameters.AddWithValue("@user_password", new_player.user_password);//Вставка у команду параметру
            comm.Parameters.AddWithValue("@current_rating", new_player.current_rating);//Вставка у команду параметру
            comm.Parameters.AddWithValue("@games_count", new_player.games_count);//Вставка у команду параметру
            comm.ExecuteNonQuery(); //Виконання команди
            conn.Close();//Закриття під'єднаня

            return new_player;
        }

        public Player LogIn(string name, string password) //Метод входження у аккаунт, що повертає гравця або помилку
        {
            MySql.Data.MySqlClient.MySqlConnection conn; //Створення підлючення
            conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString); //Під'єднання
            conn.Open(); //Відкриття бази
            MySqlCommand cmd = conn.CreateCommand(); //Створення команди
            cmd.CommandText = "SELECT * FROM Player WHERE user_name ='" + name + "'"; //Команда яка повертає гравця із бази по імені
            MySqlDataReader reader = cmd.ExecuteReader();//Створення зчитувача
            Player exist_player = new Player(name, password); // Створення об'єкту гравця
            while (reader.Read())//Цикл, що йде поки зчитується
            {
                exist_player = new Player(reader["user_id"].ToString(), reader["user_name"].ToString(), reader["user_password"].ToString(), Int32.Parse(reader["current_rating"].ToString()), UInt32.Parse(reader["games_count"].ToString())); 
                //Переприсвоєння гравця на гравця із бази

                if (name == exist_player.user_name && Hashing.HashingPassword(password) == exist_player.user_password) //Перевірка чи співпадають введені дані із данними із бази
                {
                    return exist_player; //Повернення гравця
                }
            }
            return null; //Повернення помилки
        }

        public void UpdateInfo(string name, int current_rating, uint games_count) //Метод, що оновлює інформацію про гравця у базі
        {
            MySql.Data.MySqlClient.MySqlConnection conn; //Створення підлючення
            conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString); //Під'єднання
            conn.Open(); //Відкриття бази
            MySqlCommand comm = conn.CreateCommand(); //Створення команди
            comm.CommandText = "UPDATE Player SET current_rating = @current_rating, games_count = @games_count Where user_name = @name"; //Команда оновлення інформації гравця про його рейтинг та кількість ігор
            comm.Parameters.AddWithValue("@name", name);//Вставка у команду параметру
            comm.Parameters.AddWithValue("@current_rating", current_rating);//Вставка у команду параметру
            comm.Parameters.AddWithValue("@games_count", games_count);//Вставка у команду параметру
            comm.ExecuteNonQuery();//Виконнаня команди
            conn.Close(); //Закриття під'єднання
        }

        public void AddGame(Game game)
        {
            MySql.Data.MySqlClient.MySqlConnection conn; //Створення підлючення
            conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString); //Під'єднання
            conn.Open(); //Відкриття бази
            MySqlCommand comm = conn.CreateCommand(); //Створення команди
            comm.CommandText = "INSERT INTO Game(Person1_id, Person2_id, Person1_name, Person2_name, Rating, IDOfGame, Result) VALUES (@Person1_id, @Person2_id, @Person1_name, @Person2_name, @Rating, @IDOfGame, @Result)"; 
            //Команда вставки гри до бази
            comm.Parameters.AddWithValue("@Person1_id", game.Person1_id);//Вставка у команду параметру
            comm.Parameters.AddWithValue("@Person2_id", game.Person2_id);//Вставка у команду параметру
            comm.Parameters.AddWithValue("@Person1_name", game.Person1_name);//Вставка у команду параметру
            comm.Parameters.AddWithValue("@Person2_name", game.Person2_name);//Вставка у команду параметру
            comm.Parameters.AddWithValue("@Rating", game.Rating);//Вставка у команду параметру
            comm.Parameters.AddWithValue("@IDOfGame", game.IDOfGame);//Вставка у команду параметру
            comm.Parameters.AddWithValue("@Result", game.Result);//Вставка у команду параметру
            comm.ExecuteNonQuery();//Виконнаня команди
            conn.Close(); //Закриття під'єднання
        }

        public void ShowGames(string id)
        {

            MySql.Data.MySqlClient.MySqlConnection conn; //Створення підлючення
            conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString); //Під'єднання
            conn.Open(); //Відкриття бази
            MySqlCommand cmd = conn.CreateCommand();//Створення команди

            cmd.CommandText = "SELECT current_rating FROM Player WHERE user_id ='" + id + "'"; //Команда, що поверне рейтинг гравця 
            MySqlDataReader reader = cmd.ExecuteReader(); //Створення зчитувача
            while (reader.Read())//Цикл, що йде поки зчитується
            {
                Console.WriteLine("Поточний рейтинг " + reader["current_rating"].ToString() + "\n"); //Вивід рейтингу гравця
            }
            reader.Close(); // Закриття зчитувача 

            cmd.CommandText = "SELECT * FROM Game WHERE Person1_id ='" + id + "'"; //Команда, що поверне гру гравця
            reader = cmd.ExecuteReader();  //Відкриття зчитувача

            while (reader.Read()) //Цикл, що йде поки зчитується
            {
                Console.WriteLine("Гравець " + reader["Person1_name"].ToString() + " грав з " + reader["Person2_name"].ToString() + " на рейтинг " + reader["Rating"].ToString() + " з результатом " + reader["Result"].ToString() + "\nАйдi гри " + reader["IDOfGame"].ToString() + "\n");
                //Виведення інформації про гру
            }
        }
    }
}
