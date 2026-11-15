using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static string[] students = { "Robb", "Eddard", "John", "Arya", "Sansa" };
        static int[] ages = { 17, 38, 16, 13, 15 };
        static double[] grades = { 85.5, 72.0, 91.5, 68.0, 77.1 };
        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("Students System");
                Console.WriteLine("1. Показать всех студентов");
                Console.WriteLine("2. Найти студента по имени");
                Console.WriteLine("3. Найти студента по возрасту");
                Console.WriteLine("4. Проверить средний балл");
                Console.WriteLine("5. Проверить свершеннолетие");
                Console.WriteLine("6. Очистить меню");
                Console.WriteLine("0. Выход");
                Console.WriteLine("Выберите пункт меню: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ShowStudents();
                            break;

                        case 2:
                            Console.WriteLine("Введите имя студента для поиска: ");
                            string searchName = Console.ReadLine();
                            FindStudents(searchName);
                            break;

                        case 3:
                            Console.WriteLine("Введите возраст для поиска: ");
                            if(int.TryParse(Console.ReadLine(), out int searhcAge))
                            {
                                FindStudents(searhcAge);
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод возраста.");
                            }
                            break;

                        case 4:
                            double avgGrade = GetAverageGrade();
                            Console.WriteLine($"\nСредни балл всех студентов: {avgGrade:F2}");
                            break;

                        case 5:
                            CheckAdultMenu();
                            break;

                        case 6:
                            Console.Clear();
                            break;

                        case 0:
                            Console.WriteLine("Выход из программы.");
                            break;

                        default:
                            Console.WriteLine("Неверный выбор, попробуйте снова.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Введите число!!!");
                }

            } while (choice != 0);
              }
        static void ShowStudents()
        {
            Console.WriteLine("\nСписок студентов: ");
            for(int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"{i + 1}. Имя: {students[i]}, Возраст: {ages[i]}, Средний бал: {grades[i]}");
            }
        }
        static void FindStudents(string name)
        {
            bool found = false;
            Console.WriteLine($"\nРезультаты поиска по имени: \"{name}\"");
            for(int i = 0; i < students.Length; i++)
            {
                if (string.Equals(students[i], name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Найден студент: Имя: {students[i]}, Возраст: {ages[i]}, Средний балл: {grades[i]}");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Студент с таким именем не найден.");
            }

        }
        static void FindStudents(int age)
        {
            bool found = false;
            Console.WriteLine($"\nРезультаты поиска по возрасту {age}: ");

            for(int i = 0; i < ages.Length; i++)
            {
                if (ages[i] == age)
                {
                    Console.WriteLine($"Найден студент: Имя: {students[i]}, Возраст: {ages[i]}, Средний балл: {grades[i]}");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Студенты с таким возрастом не найдены.");
            }
        }
        static double GetAverageGrade()
        {
            if (grades.Length == 0) return 0;

            double sum = 0;
            foreach (double grade in grades)
            {
                sum += grade;
            }
            return sum / grades.Length;
        }

        static bool IsAdult(int age)
        {
            return age >= 18;
        }
        
        static void CheckAdultMenu()
        {
            Console.WriteLine($"\nПроверка совершеннолетия студента: ");
            for (int i = 0; i < students.Length; i++)
            {
                bool adult = IsAdult(ages[i]);
                string status = adult ? "Совершеннолетний" : "Несовершеннолетний";
                Console.WriteLine($"- {students[i]} ({ages[i]} лет): {status}");
            }
        }
    }
}
