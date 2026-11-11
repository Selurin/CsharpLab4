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
                        RunTask1Tests();
                        break;

                    case "1в":
                        RunTask1User();
                        break;

                    case "2":
                        RunTask2Tests();
                        break;

                    case "2в":
                        RunTask2User();
                        break;

                    case "3":
                        RunTask3Tests();
                        break;

                    case "4":
                        RunTask4Tests();
                        break;

                    case "4в":
                        RunTask4User();
                        break;

                    case "5в":
                        // Резерв для задачи 5
                        break;

                    case "6":
                        RunTask6Tests();
                        break;

                    case "6в":
                        RunTask6User();
                        break;

                    case "7":
                        RunTask7Tests();
                        break;

                    case "7в":
                        RunTask7User();
                        break;

                    default:
                        Console.WriteLine("Неверный выбор! Введите корректный номер задачи");
                        break;
                }
            } while (choice != "0");
        }

        private static void RunTask1Tests()
        {
            var mylist = new List<object> { "Первый", 2, true, "Третий", 4 };
            Console.WriteLine($"Исходный список: {string.Join(", ", mylist)}");
            var resultList = OneFive.MoveToEnd(mylist);
            Console.WriteLine($"Первый элемент перемещен в конец: {string.Join(", ", resultList)}");
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

        private static void RunTask2Tests()
        {
            var myLlist = new LinkedList<object>(new object[] { "Первый", 2, true, "Третий", 4 });
            Console.WriteLine($"Исходный список: {string.Join(", ", myLlist)}");
            var resultLList = OneFive.DeleteFirstAndLast(myLlist);
            Console.WriteLine($"Удалены первый и последний элементы: {string.Join(", ", resultLList)}");
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

        private static void RunTask3Tests()
        {
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
        }

        private static void RunTask4Tests()
        {
            var filepath = "C:\\Users\\alena\\source\\repos\\CsharpLab4\\test_files\\test_basic.txt";
            Console.WriteLine("\nБазовый тест (есть и подходящие, и неподходящие буквы)");
            Console.WriteLine("Ожидаемый результат: к, т");
            OneFive.FileWordAnalyzer(filepath);

        }

        private static void RunTask4User()
        {
            Console.WriteLine("\n--- Задача 4 (ввод пользователя): Анализ глухих согласных в файле ---");
            Console.WriteLine("Обратите внимание, что файлы без полного указанного пути (например, 'test.txt') " +
                "будут автоматически искаться в папке проекта CsharpLab4\\bin\\Release\\net10.0");
            Console.Write("Введите путь к текстовому файлу: ");
            string filepath = Console.ReadLine()?.Trim() ?? "";
            OneFive.FileWordAnalyzer(filepath);
        }

        private static void RunTask6Tests()
        {
            Console.WriteLine("\n6. Тестирование вычитания времени:");

            var t1 = new Time(15, 30);
            var t2 = new Time(5, 10);
            var res1 = t1.Subtract(t2);
            Console.WriteLine($"   Без перехода в пред. сутки: {t1} - {t2} = {res1} (ожидается 10:20)");

            var t3 = new Time(2, 15);
            var t4 = new Time(4, 30);
            var res2 = t3.Subtract(t4);
            Console.WriteLine($"   С переходом в пред. сутки:  {t3} - {t4} = {res2} (ожидается 21:45)");
        }

        private static void RunTask6User()
        {
            Console.WriteLine("\n--- Задача 6 (ввод пользователя): Вычитание времени Time ---");

            Time time1 = ReadTimeFromUser("уменьшаемого (T1)");
            Time time2 = ReadTimeFromUser("вычитаемого (T2)");

            Console.WriteLine($"\nВведенное время T1: {time1}");
            Console.WriteLine($"Введенное время T2: {time2}");

            Time result = time1.Subtract(time2);

            Console.WriteLine($"\nРезультат вычитания (T1 - T2): {result}");

            if (time1.Hours < time2.Hours || (time1.Hours == time2.Hours && time1.Minutes < time2.Minutes))
            {
                Console.WriteLine("Примечание: произошел переход в предыдущие сутки.");
            }
        }

        private static void RunTask7Tests()
        {
            var t1 = new Time(23, 59);
            Console.WriteLine($"Исходное время t1: {t1}");
            t1++;
            Console.WriteLine($"t1++ (переход через полночь): {t1}");

            var t2 = new Time(0, 0);
            Console.WriteLine($"\nИсходное время t2: {t2}");
            t2--;
            Console.WriteLine($"t2-- (переход в предыдущие сутки): {t2}");

            var t3 = new Time(2, 30);
            int totalMin = t3;
            Console.WriteLine($"\nНеявное приведение к int: {t3} -> {totalMin} мин.");

            Console.WriteLine("\nЯвное приведение к bool (true, если часы и минуты не равны 0):");
            Console.WriteLine($"  (bool)new Time(2, 30) = {(bool)new Time(2, 30)}");
            Console.WriteLine($"  (bool)new Time(0, 30) = {(bool)new Time(0, 30)}");
            Console.WriteLine($"  (bool)new Time(2, 0)  = {(bool)new Time(2, 0)}");

            var a = new Time(10, 15);
            var b = new Time(12, 0);
            Console.WriteLine($"\nБинарные сравнения {a} и {b}:");
            Console.WriteLine($"  {a} < {b} : {a < b}");
            Console.WriteLine($"  {a} > {b} : {a > b}");
        }

        private static void RunTask7User()
        {
            Console.WriteLine("1 - Унарные операции и приведение типов (++, --, int, bool)");
            Console.WriteLine("2 - Бинарные операции сравнения (<, >)");
            int choice = ReadIntInRange("Выберите тип операций (1 или 2): ", 1, 2);

            if (choice == 1)
            {
                Time t = ReadTimeFromUser("для выполнения унарных операций");
                Console.WriteLine($"\nИсходное время: {t}");

                Time tInc = new Time(t.Hours, t.Minutes);
                tInc++;
                Console.WriteLine($"Операция ++ (добавлена минута): {tInc}");

                Time tDec = new Time(t.Hours, t.Minutes);
                tDec--;
                Console.WriteLine($"Операция -- (вычтена минута):   {tDec}");

                int minutes = t;
                Console.WriteLine($"Неявное приведение к int:        {minutes} мин.");

                bool hasNonZero = (bool)t;
                Console.WriteLine($"Явное приведение к bool:         {hasNonZero} (часы и минуты не равны 0)");
            }
            else
            {
                Time t1 = ReadTimeFromUser("T1");
                Time t2 = ReadTimeFromUser("T2");

                Console.WriteLine($"\nВведенное время T1: {t1} ({(int)t1} мин.)");
                Console.WriteLine($"Введенное время T2: {t2} ({(int)t2} мин.)");

                Console.WriteLine($"Результат T1 < T2: {t1 < t2}");
                Console.WriteLine($"Результат T1 > T2: {t1 > t2}");
            }
        }



        private static Time ReadTimeFromUser(string timeRoleName)
        {
            Console.WriteLine($"\nСпособ ввода для {timeRoleName}:");
            Console.WriteLine("1 - Ввести часы и минуты раздельно (числа)");
            Console.WriteLine("2 - Ввести время строкой в формате 'HH:mm'");
            int choice = ReadIntInRange("Выберите вариант (1 или 2): ", 1, 2);

            if (choice == 1)
            {
                byte hours = (byte)ReadIntInRange("  Введите часы (0-23): ", 0, 23);
                byte minutes = (byte)ReadIntInRange("  Введите минуты (0-59): ", 0, 59);
                return new Time(hours, minutes);
            }
            else
            {
                while (true)
                {
                    Console.Write("  Введите время в формате 'HH:mm': ");
                    string input = Console.ReadLine()?.Trim() ?? "";
                    try
                    {
                        return new Time(input);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"  Некорректный ввод: {ex.Message} Попробуйте снова.");
                    }
                }
            }
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
            Console.WriteLine(" 3   - Тест: Анализ фабрик мебели");
            Console.WriteLine(" 4   - Тесты: Глухие согласные в нечетных и четных словах файла");
            Console.WriteLine(" 4в  - Ввод пользователя: Указать путь к файлу для анализа слов");
            Console.WriteLine(" 6   - Тест: Класс Time (Тестирование вычитания времени)");
            Console.WriteLine(" 6в  - Ввод пользователя: Создание объектов Time и их вычитание");
            Console.WriteLine(" 7   - Тест: Операции класса Time");
            Console.WriteLine(" 7в  - Ввод пользователя: Операции с Time");
            Console.WriteLine(" 0   - Выход из программы");
            Console.WriteLine("====================================================================");
        }
    }
}