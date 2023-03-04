using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TicTacToe // Класс гри в хрестики нолики
    {
        private Field field = new Field(); // Поле об'єкту классу поля для гри в хрестики нолики
        private SQLDatabase database = new SQLDatabase(); // Поле об'єкту класу бази данних
        private Player first_player; // Поле об'єкту классу гравця для гравця
        private Player second_player; // Поле об'єкту классу гравця для опонента
        private int rating; // Поле рейтингу гри
        public void StartGame() //Метод, що запускає гру
        {
            Registration(); //Виклик функції реєстрації
        }
        private void Registration() //Метод реєстрації
        {
            Console.Clear(); //Очищення консолі
            Console.WriteLine("Введiть iм'я першого гравця\n");
            string first_player_name = Console.ReadLine(); //Зчитування імені гравця
            Console.WriteLine("Введiть пароль гравця\n");
            string first_player_password = Console.ReadLine(); //Зчитування паролю гравця
            while (true) //Цикл, що йде поки не будуть виконані всі умови
            {
                if (database.LogIn(first_player_name, first_player_password) != null) //Перевірка чи є такий гравець у базі
                {
                    first_player = database.LogIn(first_player_name, first_player_password); //Повернення об'єкта гравця
                    Console.Clear(); //Очищення консолі
                    while (true) //Цикл, що йде поки не будуть виконані всі умови
                    {
                        Console.Clear(); //Очищення консолі
                        Console.WriteLine("Ви хочете подивитися статистику? [Y/n]?\n");
                        string answer = Console.ReadLine(); //Чи хоче гравець вивести свою статистику
                        if (answer == "Y")
                        {
                            database.ShowGames(first_player.user_id); //Виведення інформації про ігри
                            Console.ReadLine();
                        }
                        if (answer == "n")
                        {
                            break; //Закінчення виведення статистики
                        }
                        else
                        {
                            Console.WriteLine("Некоректна команда\n"); //Перевірка на некоректну команду
                        }

                    }
                    Console.Clear();//Очищення консолі
                    break; //Закінчення
                }
                else //Реєстрація цього гравця
                {
                    Console.Clear();//Очищення консолі
                    Console.WriteLine("Не знайдено такого гравця. Спробуйте ще раз або введiть команду Registration для регiстрацiї гравця\n"); 
                    Console.WriteLine("Введiть iм'я першого гравця\n");
                    first_player_name = Console.ReadLine(); //Зчитування команди 
                    if (first_player_name == "Registration") //Якщо введено Registration
                    {
                        Console.Clear();//Очищення консолі
                        Console.WriteLine("Введiть iм'я гравця для регiстрацiї\n");
                        first_player_name = Console.ReadLine(); //Зчитування імені гравця для реєстрації
                        Console.WriteLine("Введiть пароль для регiстрацiї\n");
                        first_player_password = Console.ReadLine(); //Зчитування пароля гравця
                        first_player = database.Registration(first_player_name, first_player_password); //Реєстрація гравця
                        if (first_player != null) //Якщо гравець створений
                            break;
                        else //Якщо такий гравець вже існує
                        {
                            Console.Clear();//Очищення консолі
                            Console.WriteLine("Гравець з таким логіном вже існує\n");
                        }
                    }
                    Console.WriteLine("Введiть пароль гравця\n");
                    first_player_password = Console.ReadLine(); //Зчитування паролю гравця
                    Console.Clear();//Очищення консолі
                }
            }
            Console.Clear();//Очищення консолі
            string second_player_name; //Створення імені опонента
            string second_player_password; //Створення паролю опонента
            while (true)//Цикл, що йде поки не будуть виконані всі умови
            {
                Console.WriteLine("Введiть iм'я другого гравця\n");
                second_player_name = Console.ReadLine(); //Зчитування імені опонента
                Console.WriteLine("Введiть пароль гравця\n");
                second_player_password = Console.ReadLine(); //Зчитування паролю опонента
                if (second_player_name != first_player_name) //Перевірка чи не є опонент тим же гравцем
                {
                    break; //Закінчення циклу
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Опонент той же гравець\n");//Помилка
                }
            }
            while (true)//Цикл, що йде поки не будуть виконані всі умови
            {
                if (database.LogIn(second_player_name, second_player_password) != null)//Перевірка чи є такий опонент у базі
                {
                    second_player = database.LogIn(second_player_name, second_player_password);//Повернення об'єкта опонента
                    Console.Clear();
                    while (true)//Цикл, що йде поки не будуть виконані всі умови
                    {
                        Console.Clear(); //Очищення консолі
                        Console.WriteLine("Ви хочете подивитися статистику? [Y/n]?\n");
                        string answer = Console.ReadLine(); //Чи хоче гравець вивести свою статистику
                        if (answer == "Y")
                        {
                            database.ShowGames(first_player.user_id); //Виведення інформації про ігри
                            Console.ReadLine();
                        }
                        if (answer == "n")
                        {
                            break; //Закінчення виведення статистики
                        }
                        else
                        {
                            Console.WriteLine("Некоректна команда\n"); //Перевірка на некоректну команду
                        }

                    }
                    Console.Clear();//Очищення консолі
                    break; //Закінчення
                }
                else
                {
                    Console.Clear();//Очищення консолі
                    Console.WriteLine("Не знайдено такого гравця. Спробуйте ще раз або введiть команду Registration для регiстрацiї гравця\n");
                    Console.WriteLine("Введiть iм'я другого гравця\n");
                    second_player_name = Console.ReadLine();//Зчитування імені опонента
                    if (second_player_name == "Registration")//Якщо введено Registration
                    {
                        Console.Clear();//Очищення консолі
                        Console.WriteLine("Введiть iм'я гравця для регiстрацiї\n");
                        second_player_name = Console.ReadLine();//Зчитування імені опонента для реєстрації
                        Console.WriteLine("Введiть пароль для регiстрацiї\n");
                        second_player_password = Console.ReadLine();//Зчитування паролю гравця для реєстрації
                        second_player = database.Registration(second_player_name, second_player_password);//Реєстрація опонента
                        if (second_player != null)//Якщо опонент створенний
                            break;
                        else
                        {
                            Console.Clear();//Очищення консолі
                            Console.WriteLine("Гравець з таким логіном вже існує\n"); //Помилка
                        }
                    }
                    Console.WriteLine("Введiть пароль гравця\n");
                    second_player_password = Console.ReadLine(); //Зчитування паролю опонента
                    Console.Clear();//Очищення консолі
                }
            }
            Console.Clear();//Очищення консолі
            Play_Game(); // Виклик методу гри у гру
        }

        private void Play_Game() //Метод гри
        {
            while (true) //Цикл, що йде поки не будуть виконані всі умови
            {
                Console.WriteLine("Введiть рейтинг на який будете грати\n");
                string rating_s = Console.ReadLine(); //Зчитування рейтингу гри
                if(Int32.TryParse(rating_s, out rating)) //Перевірка на правильність вводу даних
                {
                    rating = Int32.Parse(rating_s); //Переведення у число
                    if (rating > 0) //Закінчення циклу
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неправильний рейтинг\n"); //Помилка рейтинг менше нуля
                    }
                }
                else
                {
                    Console.WriteLine("Неправильний рейтинг\n"); //Помилка рейтинг не число
                }
            }
            Console.Clear(); //Очищення консолі
            int turn; //Номер ходу
            string turn_s; //Хід гравців
            Random random = new Random(); //Об'єкт классу рандом
            int j = random.Next() % 2; //Вибір рандомного гравця
            for (int i = 0; i < 9; i++) //Цикл, що йде до 9 ходів гравців
            {
                Console.Clear(); //Очищення консолі
                if(j == 0) //Хід першого гравця
                {
                    while (true) //Цикл, що йде поки не будуть виконані всі умови
                    {
                        field.Print_Field(); //Виведення поля
                        Console.WriteLine("Хiд " + first_player.user_name + "\n");  
                        turn_s = Console.ReadLine(); //Зчитування ходу
                        if (Int32.TryParse(turn_s, out turn)) //Перевірка на число
                        {
                            turn = Int32.Parse(turn_s); //Переведення в число
                            if (turn <= 8 && turn >= 0 && field.turn_field[turn % 3, turn / 3] == 0) //Перевірка на хід на полі
                            {
                                field.turn_field[turn % 3, turn / 3] = 1; //Вставка ходу гравця
                                field.Insert_X_Sign(turn); //Вставка Хрестика
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неправильний хiд"); // Помилка хід не в проміжку або на клітинку яка вже заповненна
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неправильний хiд"); //Помилка, хід не число 
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
                else
                {
                    while (true)//Цикл, що йде поки не будуть виконані всі умови
                    {
                        field.Print_Field();//Виведення поля
                        Console.WriteLine("Хiд " + second_player.user_name+ "\n");
                        turn_s = Console.ReadLine();//Зчитування ходу
                        if (Int32.TryParse(turn_s, out turn))//Перевірка на число
                        {
                            turn = Int32.Parse(turn_s);
                            if (turn <= 8 && turn >= 0 && field.turn_field[turn % 3, turn / 3] == 0)//Перевірка на хід на полі
                            {
                                field.turn_field[turn % 3, turn / 3] = 2; //Вставка ходу опонента
                                field.Insert_O_Sign(turn); //Вставка нулика
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неправильний хiд"); // Помилка хід не в проміжку або на клітинку яка вже заповненна
                                Console.ReadLine();
                                Console.Clear();//Очищення консолі
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неправильний хiд"); //Помилка, хід не число 
                            Console.ReadLine();
                            Console.Clear();//Очищення консолі
                        }
                    }
                }
                if (field.Check_Winner() != 0) //Перевірка на переможця
                {
                    Console.Clear();//Очищення консолі
                    field.Check_Win_Line(); //Вставка переможної лінії
                    field.Print_Field(); //Виведення поля
                    if(field.Check_Winner() == 1) //Перевірка на перемогу гравця
                    {
                        Console.WriteLine("Перемога гравця " + first_player.user_name + "\n");
                        first_player.Win_Game(second_player, rating); //Перемога гравця
                        break;
                    }
                    if (field.Check_Winner() == 2)//Перевірка на перемогу опонента
                    {
                        Console.WriteLine("Перемога гравця " + second_player.user_name + "\n");
                        first_player.Lose_Game(first_player, rating);//Програш гравця
                        break;
                    }

                }
                j++; //Перехід ходу
                j = j % 2; //Перехід ходу
                if(i == 8) //Перевірка на кінець гри
                {
                    Console.Clear(); //Очищення консолі
                    field.Print_Field(); //Виведення поля
                    Console.WriteLine("Нiчия\n");
                    first_player.Draw_Game(second_player, rating); //Нічия гравця
                }
            }
            Console.ReadLine();
            Repeat_Game(); //Виклик методу повтору гри
        }

        void Repeat_Game()
        {
            while(true)//Цикл, що йде поки не будуть виконані всі умови
            {
                Console.Clear();//Очищення консолі
                Console.WriteLine("Ви хочете повторити гру? [Y/n]?\n");
                string answer = Console.ReadLine(); //Чи хоче гравець повторити гру
                if(answer == "Y")
                {
                    field.Clear_Fields(); //Очищення полів
                    break; //Повтор гри
                }
                if (answer == "n")
                {
                    return; //Кінець роботи
                }
                else
                {
                    Console.WriteLine("Некоректна команда\n"); //Помилка
                }

            }
            Registration(); //Виклик реєстрації
        }
    }
}
