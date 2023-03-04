using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace TicTacToe
{
    class Hashing //Класс хешування 
    {
        static public string HashingPassword(string input) //Статична функція що повертає захешований пароль
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input); //Розбиття на байти початкового пароля
            SHA256 sha256 = SHA256.Create(); //Створення об'єкту классу SHA256 
            byte[] hash = sha256.ComputeHash(inputBytes); //Хешування паролю у байти
            string hashString = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant(); //Конвертація бітів захешованого паролю у стрінг з видаленням всіх тире
            return hashString; //Повернення захешованого паролю
        }
    }
}
