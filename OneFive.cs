using System;
using System.Collections.Generic;
using System.IO;
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

    public static void FurnitureFactoryAnalysis(
        Dictionary<string, HashSet<string>> factoryCatalog,
        Dictionary<string, Dictionary<string, HashSet<string>>> customerPurchases,
        HashSet<string> allCustomers)
    {
        if (factoryCatalog == null || factoryCatalog.Count == 0)
        {
            Console.WriteLine("Каталог фабрик пуст.");
            return;
        }

        if (allCustomers == null || allCustomers.Count == 0)
        {
            Console.WriteLine("Список покупателей пуст.");
            return;
        }

        foreach (var factoryPair in factoryCatalog)
        {
            string factory = factoryPair.Key;
            HashSet<string> catalog = factoryPair.Value ?? new HashSet<string>();

            var purchasesPerCustomer = new List<HashSet<string>>();
            foreach (string customer in allCustomers)
            {
                HashSet<string> customerBought = new HashSet<string>();
                if (customerPurchases != null &&
                    customerPurchases.ContainsKey(customer) &&
                    customerPurchases[customer] != null &&
                    customerPurchases[customer].ContainsKey(factory) &&
                    customerPurchases[customer][factory] != null)
                {
                    foreach (string item in customerPurchases[customer][factory])
                    {
                        if (catalog.Contains(item))
                        {
                            customerBought.Add(item);
                        }
                    }
                }
                purchasesPerCustomer.Add(customerBought);
            }


            var allPurchased = new HashSet<string>(purchasesPerCustomer[0]);
            for (int i = 1; i < purchasesPerCustomer.Count; i++)
            {
                allPurchased.IntersectWith(purchasesPerCustomer[i]);
            }

            var anyPurchased = new HashSet<string>();
            for (int i = 0; i < purchasesPerCustomer.Count; i++)
            {
                anyPurchased.UnionWith(purchasesPerCustomer[i]);
            }

            var somePurchased = new HashSet<string>(anyPurchased);
            somePurchased.ExceptWith(allPurchased);

            var nonePurchased = new HashSet<string>(catalog);
            nonePurchased.ExceptWith(anyPurchased);


            Console.WriteLine($"\nФабрика \"{factory}\":");
            Console.WriteLine($"  Ассортимент фабрики: {(catalog.Count > 0 ? string.Join(", ", catalog) : "нет")}");
            Console.WriteLine($"  - Приобреталась всеми покупателями: {(allPurchased.Count > 0 ? 
                string.Join(", ", allPurchased) : "нет")}");
            Console.WriteLine($"  - Приобреталась некоторыми покупателями: {(somePurchased.Count > 0 ? 
                string.Join(", ", somePurchased) : "нет")}");
            Console.WriteLine($"  - Не приобреталась никем из покупателей: {(nonePurchased.Count > 0 ? 
                string.Join(", ", nonePurchased) : "нет")}");
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

