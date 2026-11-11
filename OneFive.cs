public class OneFive
{
    public static List<object> MoveToEnd(List<object> list)
    {
        if (list != null && list.Count > 1)
        {
            var first = list[0];
            int lastIndex = list.Count - 1;

            for (int i = 0; i < lastIndex; i++)
            {
                list[i] = list[i + 1];
            }
            list[lastIndex] = first;
        }

        return list ?? new List<object>();
    }

    public static LinkedList<object> DeleteFirstAndLast(LinkedList<object> list)
    {
        if (list != null && list.Count > 2)
        {

            list.RemoveFirst();
            list.RemoveLast();
        }

        return list ?? new LinkedList<object>();
    }

    public static void FurnitureFactoryAnalysis(Dictionary<string, HashSet<string>> factoryPurchases, 
        HashSet<string> allCustomers)
    {
        foreach (var factory in factoryPurchases)
        {
            var customers = factory.Value;
            if (customers.SetEquals(allCustomers))
            {
                Console.WriteLine($"Фабрика {factory.Key}: мебель приобреталась всеми покупателями.");
            }
            else if (customers.Count > 0)
            {
                Console.WriteLine($"Фабрика {factory.Key}: мебель приобреталась некоторыми покупателями.");
            }
            else
            {
                Console.WriteLine($"Фабрика {factory.Key}: мебель не приобреталась никем из покупателей.");
            }
        }
    }

    public static void FileWordAnalyzer(string filepath)
    {
        if (!File.Exists(filepath))
        {
            Console.WriteLine($"Файл {filepath} не найден.");
            return;
        }
        var inAllOddWords = new HashSet<char> { 'к', 'п', 'т', 'с', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
        var inAllEvenWords = new HashSet<char> { 'к', 'п', 'т', 'с', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
        var currentWordChars = new HashSet<char>();
        char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '-', '—', '\t', '\r', '\n' };
        int wordCounter = 0;

        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)

            {
                string[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    wordCounter++;
                    string lowerWord = word.ToLower();

                    if (wordCounter % 2 != 0)
                    {
                        var currentCandidates = new List<char>(inAllOddWords);

                        foreach (char c in currentCandidates)
                        {
                            if (!lowerWord.Contains(c))
                            {
                                inAllOddWords.Remove(c);
                            }
                        }
                    }
                    else
                    {
                        var currentCandidates = new List<char>(inAllEvenWords);
                        foreach (char c in currentCandidates)
                        {
                            if (!lowerWord.Contains(c))
                            {
                                inAllEvenWords.Remove(c);
                            }
                        }
                    }
                }
            }
        }
        if (wordCounter == 0)
        {
            Console.WriteLine("В файле нет слов.");
            return;
        }

        if (wordCounter >= 2)
        {
            inAllOddWords.ExceptWith(inAllEvenWords);
        }

        var result = new List<char>(inAllOddWords);
        result.Sort();

        if (result.Count == 0)
        {
            Console.WriteLine("Подходящих букв не найдено.");
        }
        else
        {
            Console.WriteLine("Результат: " + string.Join(", ", result));
        }
    }
}

