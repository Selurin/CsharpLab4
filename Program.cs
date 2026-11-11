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
                        Console.WriteLine($"Удален первый элемент: {string.Join(", ", resultList)}");
                        break;

                    case "1в":
                        //
                        break;

                    case "2":
                        var myLlist = new LinkedList<object>(["Первый", 2, true, "Третий", 4]);
                        Console.WriteLine($"Исходный список: {string.Join(", ", myLlist)}");
                        var resultLList = OneFive.DeleteFirstAndLast(myLlist);
                        Console.WriteLine($"Удалены первый и последний элементы: {string.Join(", ", resultLList)}");
                        break;

                    case "2в":
                        //
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

                        var factoryPurchases = new Dictionary<string, HashSet<string>>
                        {
                            { "Ангстрем", new HashSet<string> { "Иванов", "Петрова", "Смирнов" } },
                            { "Столплит", new HashSet<string>() },
                            { "Лазурит", new HashSet<string> { "Кузнецова" } },
                            { "Шатура", new HashSet<string> { "Иванов", "Петрова", "Сидоров", "Кузнецова", "Смирнов" }},
                            { "Аскона", new HashSet<string>() },
                            { "Дятьково", new HashSet<string> { "Петрова", "Сидоров" } },
                        };

                        OneFive.FurnitureFactoryAnalysis(factoryPurchases, allCustomers);
                        break;

                    case "3в":
                        //
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
                        //
                        break;

                    case "5в":
                        //
                        break;

                    case "6":
                        //
                        break;

                    case "6в":
                        //
                        break;

                    case "7":
                        //
                        break;

                    case "7в":
                        //
                        break;

                    default:
                        Console.WriteLine("Неверный выбор! Введите корректный номер задачи");
                        break;
                }
            } while (choice != "0");
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\n--- Меню задач ---");
            Console.WriteLine("1 - ...");
            Console.WriteLine("0 - Выход");
            Console.WriteLine("------------------");
        }
    }
}
