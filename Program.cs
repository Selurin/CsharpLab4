namespace CsharpLab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mylist = new List<object> { "Первый", 2, true, "Третий", 4 };
            Console.WriteLine($"Исходный список: {string.Join(", ", mylist)}");
            var resultList = OneFive.MoveToEnd(mylist);
            Console.WriteLine($"Удален первый элемент: {string.Join(", ", resultList)}\n");

            var myLlist = new LinkedList<object>(["Первый", 2, true, "Третий", 4]);
            Console.WriteLine($"Исходный список: {string.Join(", ", myLlist)}");
            var resultLList = OneFive.DeleteFirstAndLast(myLlist);
            Console.WriteLine($"Удалены первый и последний элементы: {string.Join(", ", resultLList)}\n");

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
                { "Шатура", new HashSet<string> { "Иванов", "Петрова", "Сидоров", "Кузнецова", "Смирнов" } },
                { "Аскона", new HashSet<string>() },
                { "Дятьково", new HashSet<string> { "Петрова", "Сидоров" } },
            };

            OneFive.FurnitureFactoryAnalysis(factoryPurchases, allCustomers);

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

            filepath = "C:\\Users\\alena\\source\\repos\\CsharpLab4\\test_files\\test_multiline_delimiters.txt";
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

        }
    }
}
