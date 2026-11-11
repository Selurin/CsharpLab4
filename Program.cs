using System;
using System.Collections.Generic;

namespace CsharpLab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice;
            do
            {
                PrintMenu();
                Console.Write("Введите номер задачи (например 1) или номер с буквой \"в\" (например 1в) " +
                    "для ввода пользователем или 0 для выхода: ");
                choice = Console.ReadLine()?.Trim() ?? "";
                switch (choice)
                {
                    case "0":
                        Console.WriteLine("До свидания!");
                        break;

                    case "1":
                        var mylist = new List<object> { "Первый", 2, true, "Третий", 4 };
                        Console.WriteLine($"Исходный список: {string.Join(", ", mylist)}");
                        var resultList = OneFive.MoveToEnd(mylist);
                        Console.WriteLine($"Первый элемент перемещен в конец: {string.Join(", ", resultList)}");
                        break;

                    case "1в":
                        RunTask1User();
                        break;

                    case "2":
                        var myLlist = new LinkedList<object>(new object[] { "Первый", 2, true, "Третий", 4 });
                        Console.WriteLine($"Исходный список: {string.Join(", ", myLlist)}");
                        var resultLList = OneFive.DeleteFirstAndLast(myLlist);
                        Console.WriteLine($"Удалены первый и последний элементы: {string.Join(", ", resultLList)}");
                        break;

                    case "2в":
                        RunTask2User();
                        break;

                    case "3":
                        var allCustomers = new HashSet<string>
                        {
                            "Иванов",
                            "Петрова",
                            "Сидоров",
                            "Кузнецова",
                            "Смирнов"
                        };

                        var factoryCatalog = new Dictionary<string, HashSet<string>>
                        {
                            { "Шатура", new HashSet<string> { "Диван", "Стол", "Шкаф", "Кресло", "Тумба" } },
                            { "Ангстрем", new HashSet<string> { "Кровать", "Комод", "Матрас" } },
                            { "Лазурит", new HashSet<string> { "Стенка", "Полка", "Стеллаж" } },
                            { "Дятьково", new HashSet<string> { "Письменный стол", "Стул", "Пенал" } },
                            { "Столплит", new HashSet<string> { "Кухонный гарнитур", "Табурет" } },
                            { "Аскона", new HashSet<string> { "Ортопедическая подушка", "Одеяло" } }
                        };

                        var customerPurchases = new Dictionary<string, Dictionary<string, HashSet<string>>>
                        {
                            {
                                "Иванов", new Dictionary<string, HashSet<string>>
                                {
                                    { "Шатура", new HashSet<string> { "Диван", "Стол" } },
                                    { "Ангстрем", new HashSet<string> { "Кровать", "Комод" } },
                                    { "Дятьково", new HashSet<string> { "Стул" } }
                                }
                            },
                            {
                                "Петрова", new Dictionary<string, HashSet<string>>
                                {
                                    { "Шатура", new HashSet<string> { "Диван", "Стол", "Кресло" } },
                                    { "Ангстрем", new HashSet<string> { "Кровать", "Комод" } },
                                    { "Дятьково", new HashSet<string> { "Письменный стол", "Стул" } }
                                }
                            },
                            {
                                "Сидоров", new Dictionary<string, HashSet<string>>
                                {
                                    { "Шатура", new HashSet<string> { "Диван", "Шкаф" } },
                                    { "Ангстрем", new HashSet<string> { "Кровать", "Комод" } },
                                    { "Лазурит", new HashSet<string> { "Стенка" } },
                                    { "Дятьково", new HashSet<string> { "Стул" } }
                                }
                            },
                            {
                                "Кузнецова", new Dictionary<string, HashSet<string>>
                                {
                                    { "Шатура", new HashSet<string> { "Диван" } },
                                    { "Ангстрем", new HashSet<string> { "Кровать", "Комод" } },
                                    { "Лазурит", new HashSet<string> { "Полка" } }
                                }
                            },
                            {
                                "Смирнов", new Dictionary<string, HashSet<string>>
                                {
                                    { "Шатура", new HashSet<string> { "Диван", "Стол" } },
                                    { "Ангстрем", new HashSet<string> { "Кровать", "Комод" } }
                                }
                            }
                        };
                        OneFive.FurnitureFactoryAnalysis(factoryCatalog, customerPurchases, allCustomers);
                        break;

                    case "4":
                        var filepath = "C:\\Users\\alena\\source\\repos\\CsharpLab4\\test_files\\test_basic.txt";
                        Console.WriteLine("\n1. Базовый тест (есть и подходящие, и неподходящие буквы)");
                        Console.WriteLine("Ожидаемый результат: к, т");
                        OneFive.FileWordAnalyzer(filepath);

                        filepath = "C:\\Users\\alena\\source\\repos\\CsharpLab4\\test_files\\test_exclude_even.txt";
                        Console.WriteLine("\n2. Тест исключения букв из четных слов");
                        Console.WriteLine("Ожидаемый результат: т");
                        OneFive.FileWordAnalyzer(filepath);

                        filepath = "C:\\Users\\alena\\source\\repos\\CsharpLab4\\test_files\\no_found.txt";
                        Console.WriteLine("\n3. Тест без подходящих букв");
                        Console.WriteLine("Ожидаемый результат: Подходящих букв не найдено.");
                        OneFive.FileWordAnalyzer(filepath);

                        filepath = "C:\\Users\\alena\\source\\repos\\CsharpLab4\\test_files\\" +
                            "test_multiline_delimiters.txt";
                        Console.WriteLine("\n4. Тест многострочного текста и разных разделителей");
                        Console.WriteLine("Ожидаемый результат: к, п, с");
                        OneFive.FileWordAnalyzer(filepath);

                        filepath = "C:\\Users\\alena\\source\\repos\\CsharpLab4\\test_files\\test_single_word.txt";
                        Console.WriteLine("\n5. Пограничный тест: всего одно слово в файле");
                        Console.WriteLine("Ожидаемый результат: к, ч, ш");
                        OneFive.FileWordAnalyzer(filepath);

                        filepath = "C:\\Users\\alena\\source\\repos\\CsharpLab4\\test_files\\test_punctuation_only.txt";
                        Console.WriteLine("\n6. Пограничный тест: только знаки препинания");
                        Console.WriteLine("Ожидаемый результат: В файле нет слов.");
                        OneFive.FileWordAnalyzer(filepath);
                        break;

                    case "4в":
                        RunTask4User();
                        break;

                    case "5в":
                        // Резерв для задачи 5
                        break;

                    case "6":
                        // Резерв для задачи 6
                        break;

                    case "6в":
                        // Резерв для задачи 6в
                        break;

                    case "7":
                        // Резерв для задачи 7
                        break;

                    case "7в":
                        // Резерв для задачи 7в
                        break;

                    default:
                        Console.WriteLine("Неверный выбор! Введите корректный номер задачи");
                        break;
                }
            } while (choice != "0");
        }


        private static void RunTask1User()
        {
            int count = ReadIntInRange("Введите количество элементов списка: ", 1);

            var userList = new List<object>();
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Введите элемент [{i + 1}]: ");
                string item = Console.ReadLine() ?? "";
                userList.Add(item);
            }

            Console.WriteLine($"\nИсходный список: {string.Join(", ", userList)}");
            var resultList = OneFive.MoveToEnd(userList);
            Console.WriteLine($"Первый элемент перемещен в конец: {string.Join(", ", resultList)}");
        }

        private static void RunTask2User()
        {
            int count = ReadIntInRange("Введите количество элементов списка: ", 0);

            var userLList = new LinkedList<object>();
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Введите элемент [{i + 1}]: ");
                string item = Console.ReadLine() ?? "";
                userLList.AddLast(item);
            }

            Console.WriteLine($"\nИсходный список: {string.Join(", ", userLList)}");
            var resultLList = OneFive.DeleteFirstAndLast(userLList);
            Console.WriteLine($"Удалены первый и последний элементы: {string.Join(", ", resultLList)}");
        }

       
        private static void RunTask4User()
        {
            Console.WriteLine("\n--- Задача 4 (ввод пользователя): Анализ глухих согласных в файле ---");
            Console.WriteLine("Обратите внимание, что файлы без пути будут автоматически искаться в папке проекта " +
                "CsharpLab4\\bin\\Release\\net10.0");
            Console.Write("Введите путь к текстовому файлу: ");
            string filepath = Console.ReadLine()?.Trim() ?? "";
            OneFive.FileWordAnalyzer(filepath);
        }


        private static bool TryReadInt(string prompt, out int value)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out value))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Неверное значение! Ожидалось целое число.");
                return false;
            }
        }

        private static int ReadIntInRange(string prompt, int min, int max = int.MaxValue)
        {
            int value;
            while (true)
            {
                if (TryReadInt(prompt, out value))
                {
                    if (value >= min && value <= max)
                    {
                        return value;
                    }

                    if (max == int.MaxValue)
                    {
                        Console.WriteLine($"Число должно быть не меньше {min}.");
                    }
                    else
                    {
                        Console.WriteLine($"Число должно быть в диапазоне от {min} до {max}.");
                    }
                }
            }
        }


        private static void PrintMenu()
        {
            Console.WriteLine("\n============================ Меню задач ============================");
            Console.WriteLine(" 1   - Тест: Перемещение первого элемента в конец списка");
            Console.WriteLine(" 1в  - Ввод пользователя: Перемещение первого элемента в конец списка");
            Console.WriteLine(" 2   - Тест: Удаление первого и последнего элементов");
            Console.WriteLine(" 2в  - Ввод пользователя: Удаление первого и последнего элементов");
            Console.WriteLine(" 3   - Тест: Анализ фабрик мебели (всеми, некоторыми или никем)");
            Console.WriteLine(" 4   - Тесты: Глухие согласные в нечетных и четных словах файла");
            Console.WriteLine(" 4в  - Ввод пользователя: Указать путь к файлу для анализа слов");
            Console.WriteLine(" 0   - Выход из программы");
            Console.WriteLine("====================================================================");
        }
    }
}