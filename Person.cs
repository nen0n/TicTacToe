using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    abstract class Person //Абстрактний класс паролю
    {
        public string user_id; // Поле айді юзера
        public string user_name; //Поле імені юзера
        public string user_password; //Поле паролю юзера

        public abstract void Win_Game(Player player, int rating); //Абстрактна функція перемоги у грі
        public abstract void Lose_Game(Player player, int rating); //Абстрактна функція програшу у грі
        public abstract void Draw_Game(Player player, int rating); //Абстрактна функція нічиї у грі
    }
}
