using System;
using MySql.Data.MySqlClient;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe ticTacToe = new TicTacToe(); //Створення об'єкту гри в хрестики нолики
            ticTacToe.StartGame(); //Запуск гри
        }
    }
}
