using System;
using System.Diagnostics.Metrics;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace consoleApp1
{
    public class Programm
    {
        static void SearchToIndex(ref string[][] Authors, string value, ref string[] array)
        {
            var flag = false;
            for (int i = 0; i < Authors.Length; i++)
            {
                for (int j = 0; j < Authors[Authors.Length - 1].Length; j++)
                {
                    if (Authors[i][j].ToLower() == (value.ToLower()))
                    {
                        Console.Write($"Книга {value.ToLower()} находится в авторе - {array[i]} ");
                        flag = true;
                        break;
                    }
                }
            }
            if (!flag)
            {
                Console.WriteLine("Увы такого у нас нет!");
            }

        }
        static void AllBooks(ref string[][] Authors, ref string[] array)
        {

            for (int i = 0; i < Authors.Length; i++)
            {
                Console.Write($"Автор, {array[i]}, содержит: ");

                for (int j = 0; j < Authors[i].Length; j++)
                {
                    Console.Write( Authors[i][j] + ", ", j == (Authors[i].Length - 1));
                }
                Console.WriteLine();

            }
        }
        static void InsertBooks(ref string[] Authors, string value, int index)
        {
            string[] newBooks = new string[Authors.Length + 1];
            newBooks[index] = value;

            for (int i = 0; i < index; i++)
                newBooks[i] = Authors[i];
            for (int i = index; i < Authors.Length; i++)
            {
                newBooks[i + 1] = Authors[i];
            }
            Authors = newBooks;
        }
        static void Insert(ref string[] array, string value, int index, ref string[][] Authors)
        {

            string[] newArray = new string[array.Length + 1];
            newArray[index] = value;
            string[][] AuthorsNew = new string[Authors.Length + 1][];
            AuthorsNew[index] = new string[1] { "Тут пока ничего нет, добавьте любую!" };

            for (int i = 0; i < index; i++)
            {
                newArray[i] = array[i];
                AuthorsNew[i] = Authors[i];
            }
            for (int i = index; i < array.Length; i++)
            {
                newArray[i + 1] = array[i];
                AuthorsNew[i + 1] = Authors[i];
            }
            Authors = AuthorsNew;

            array = newArray;
        }
        static void RemoveAt(ref string[] array, int index, ref string[][] Authors)
        {
            string[] newArray = new string[array.Length - 1];
            string[][] AuthorsNew = new string[Authors.Length - 1][];
            
            for (int i = 0; i < index; i++)
            {
                newArray[i] = array[i];
                AuthorsNew[i] = Authors[i];

            }
            for (int i = index + 1; i < array.Length; i++)
            {
                newArray[i - 1] = array[i];
                AuthorsNew[i - 1] = Authors[i];
            }
            Authors = AuthorsNew;
            array = newArray;
        }
        static void RemoveBooks(ref string[] Authors, int index)
        {
            string[] newBooks = new string[Authors.Length - 1];
            for (int i = 0; i < index; i++)
                newBooks[i] = Authors[i];
            for (int i = index + 1; i < Authors.Length; i++)
            {
                newBooks[i - 1] = Authors[i];
            }
            Authors = newBooks;
        }
        static void Replace(ref string[] array, string value, int index)
        {
            string[] newArray = new string[array.Length - 1];
            for (int i = 0; i < index; i++)
                newArray[i] = array[i];
            for (int i = index + 1; i < array.Length; i++)
            {
                newArray[i - 1] = array[i];
            }
            array = newArray;
            string[] newArray1 = new string[array.Length + 1];
            newArray1[index] = value;

            for (int i = 0; i < index; i++)
                newArray1[i] = array[i];
            for (int i = index; i < array.Length; i++)
            {
                newArray1[i + 1] = array[i];
            }
            array = newArray1;
        }
        static void ReplaceBooks(ref string[] Authors, string value, int index)
        {
            string[] newBooks = new string[Authors.Length - 1];
            for (int i = 0; i < index; i++)
                newBooks[i] = Authors[i];
            for (int i = index + 1; i < Authors.Length; i++)
            {
                newBooks[i - 1] = Authors[i];
            }
            Authors = newBooks;
            string[] newBooks1 = new string[Authors.Length + 1];
            newBooks1[index] = value;

            for (int i = 0; i < index; i++)
                newBooks1[i] = Authors[i];
            for (int i = index; i < Authors.Length; i++)
            {
                newBooks1[i + 1] = Authors[i];
            }
            Authors = newBooks1;
        }
        static async Task Main(string[] args)
        {
            bool isOpen;
            Console.SetCursorPosition(0, 5);
            string[] myArray = { "Пушкин", "Гоголь", "Толстой", "Ремарк" };
            string[][] BooksOfAuthors = new string[myArray.Length][];
            BooksOfAuthors[0] = new string[3] { "Сказка о царе Салтане", "Сказка о рыбаке и рыбке", "Сказка о мертвой царевне" };
            BooksOfAuthors[1] = new string[3] { "Тарас Бульба", "Портрет", "Вий" };
            BooksOfAuthors[2] = new string[3] { "Война и мир", "Детство", "Анна Каренина" };
            BooksOfAuthors[3] = new string[3] { "Три товарища", "На западном фронте без перемен", "Ночь в Лиссабоне" };




            while (isOpen = true)
            {
                Console.SetCursorPosition(0, 26);
                Console.WriteLine("\nВесь список авторов:\n");
                for (int i = 0; i < myArray.Length; i++)
                {

                    Console.Write(myArray[i] + " ");
                }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Выберите дейсвие: 1 - удалить автора, 2 - добавить автора, 3 - заменить автора," +
                    " 4 - показать книги автора, 5 - поиск по книгам, 6 - показать всех авторов и их книги, 7 - выйти из программы ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Какого автора вы хотите удалить?");
                        int deleteIndex = Convert.ToInt32(Console.ReadLine());
                        RemoveAt(ref myArray, deleteIndex - 1, ref BooksOfAuthors);
                        break;
                    case "2":
                        Console.WriteLine("Какого автора вы хотите добавить?");
                        string userInputValue = Console.ReadLine();
                        var flag = false;
                        for (int i = 0; i < myArray.Length; i++)
                        {
                            
                            if (myArray[i].ToLower() != (userInputValue.ToLower()))
                            {
                                Console.WriteLine("Какой индекс у этого автора?");
                                int userInputIndex = Convert.ToInt32(Console.ReadLine());
                                Insert(ref myArray, userInputValue, userInputIndex - 1, ref BooksOfAuthors);
                                flag = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Этот автор есть в списке!");
                                break;
                            }

                        }
                        break;
                        
                    case "3":
                        Console.WriteLine("На какого автора вы хотите заменить?");
                        string replaceName = Console.ReadLine();
                        Console.WriteLine("Какой индекс у заменяемого автора?");
                        int replaceIndex = Convert.ToInt32(Console.ReadLine());
                        Replace(ref myArray, replaceName, replaceIndex - 1);
                        break;
                    case "4":
                        Console.WriteLine("Укажите индекс автора");
                        int indexName = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < BooksOfAuthors.Length; i++)
                        {
                            Console.Write($"{myArray[indexName - 1]}, содержит эти книги: ", i);
                            for (int j = 0; j < BooksOfAuthors[indexName - 1].Length; j++)
                            {
                                Console.Write(BooksOfAuthors[indexName - 1][j] + ", ", j == (BooksOfAuthors[indexName - 1].Length - 1));
                            }
                            Console.SetCursorPosition(0, 10);
                            Console.WriteLine("Нажмите 1 - для выхода, 2 - удаления книги, 3 - замена книги, 4 - добавление книги");
                            string inputUser = Console.ReadLine();
                            switch (inputUser)
                            {
                                case "1":
                                    break;



                                case "2":
                                    Console.WriteLine("Какую книгу вы хотите удалить?");
                                    int deleteIndexNew = Convert.ToInt32(Console.ReadLine());
                                    RemoveBooks(ref BooksOfAuthors[indexName - 1], deleteIndexNew - 1);
                                    Console.WriteLine("\nИдет удаление книги.");
                                    await Task.Delay(2000);
                                    Console.WriteLine("\nИдет удаление книги..");
                                    await Task.Delay(1500);
                                    Console.WriteLine("\nИдет удаление книги...");
                                    Console.WriteLine("\nКниги удалена, нажмите любую клавишу, чтобы обновить страницу автора");
                                    //for (int k = 0; k < Authors[nameIndex - 1].Length; k++)
                                    //{
                                    //    Console.Write(Authors[nameIndex - 1][k], k == (Authors[nameIndex - 1].Length - 1));
                                    //}

                                    break;
                                case "3":
                                    Console.WriteLine("На какого автора вы хотите заменить?");
                                    string replaceNameNew = Console.ReadLine();
                                    Console.WriteLine("Какой индекс у заменяемого автора?");
                                    int replaceIndexNew = Convert.ToInt32(Console.ReadLine());
                                    ReplaceBooks(ref BooksOfAuthors[indexName - 1], replaceNameNew, replaceIndexNew - 1);
                                    for (int k = 0; k < BooksOfAuthors[indexName - 1].Length; k++)
                                    {
                                        Console.Write(BooksOfAuthors[indexName - 1][k], k == (BooksOfAuthors[indexName - 1].Length - 1));
                                    }

                                    break;
                                case "4":
                                    Console.WriteLine("Какого автора вы хотите добавить?");
                                    string userInputCount1New = Console.ReadLine();
                                    Console.WriteLine("Какой индекс у этого имени?");
                                    int userInputCount2New = Convert.ToInt32(Console.ReadLine());
                                    InsertBooks(ref BooksOfAuthors[indexName - 1], userInputCount1New, userInputCount2New - 1);
                                    break;
                                default:
                                    Console.WriteLine("Введена неверная команда, попробуйте еще раз!");
                                    break;



                            }
                            if (inputUser == "1")
                            {
                                break;
                            }
                            Console.ReadKey();
                            Console.Clear();




                        }
                        break;


                    case "5":
                        Console.Write("Введите книгу для поиска: ");
                        string userBooksSearch = Console.ReadLine();
                        SearchToIndex(ref BooksOfAuthors, userBooksSearch, ref myArray);
                        break;
                    case "6":
                        AllBooks(ref BooksOfAuthors, ref myArray);
                        break;
                    case "7":
                        isOpen = false;
                        break;

                    default:
                        Console.WriteLine("Введена неверная команда, попробуйте еще раз!");
                        break;
                }
                if (isOpen == true)
                {
                    Console.WriteLine("Нажмите любую клавиши, чтобы продолжить!");
                }
                else
                {
                    Environment.Exit(0);
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}