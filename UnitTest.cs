using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using CsharpLab4;

namespace CsharpLab4Tests
{
    public class UnitTest
    {
        #region Задание 1. Задача 1: Перемещение первого элемента в конец списка (MoveToEnd)

        [Fact]
        public void MoveToEnd_MultipleElements_FirstElementMovedToEnd()
        {
            var list = new List<object> { "Первый", 2, true, "Третий", 4 }; 

            var result = OneFive.MoveToEnd(list); 

            Assert.Equal(5, result.Count); 
            Assert.Equal(2, result[0]); 
            Assert.Equal(true, result[1]); 
            Assert.Equal("Третий", result[2]); 
            Assert.Equal(4, result[3]); 
            Assert.Equal("Первый", result[4]); 
        }

        [Fact]
        public void MoveToEnd_SingleElement_ListRemainsUnchanged()
        {
            var list = new List<object> { 42 }; 

            var result = OneFive.MoveToEnd(list); 

            Assert.Single(result); 
            Assert.Equal(42, result[0]); 
        }

        [Fact]
        public void MoveToEnd_EmptyList_ReturnsEmptyList()
        {
            var list = new List<object>(); 

            var result = OneFive.MoveToEnd(list); 

            Assert.Empty(result); 
        }

        [Fact]
        public void MoveToEnd_NullList_ReturnsEmptyNonNullList()
        {
            var result = OneFive.MoveToEnd(null!); 

            Assert.NotNull(result); 
            Assert.Empty(result); 
        }

        #endregion

        #region Задание 1. Задача 2: Удаление первого и последнего элементов (DeleteFirstAndLast)

        [Fact]
        public void DeleteFirstAndLast_MultipleElements_DeletesFirstAndLast()
        {
            var list = new LinkedList<object>(new object[] { "Первый", 2, true, "Третий", 4 }); 

            var result = OneFive.DeleteFirstAndLast(list); 

            Assert.Equal(3, result.Count); 
            Assert.NotNull(result.First); 
            Assert.NotNull(result.Last); 
            Assert.Equal(2, result.First!.Value); 
            Assert.Equal("Третий", result.Last!.Value); 
        }

        [Fact]
        public void DeleteFirstAndLast_TwoOrFewerElements_ListRemainsUnchanged()
        {
            var listTwo = new LinkedList<object>(new object[] { "A", "B" }); 
            var resultTwo = OneFive.DeleteFirstAndLast(listTwo); 
            Assert.Equal(2, resultTwo.Count); 

            var listOne = new LinkedList<object>(new object[] { "A" }); 
            var resultOne = OneFive.DeleteFirstAndLast(listOne); 
            Assert.Single(resultOne); 
        }

        [Fact]
        public void DeleteFirstAndLast_EmptyList_ReturnsEmpty()
        {
            var list = new LinkedList<object>(); 

            var result = OneFive.DeleteFirstAndLast(list); 

            Assert.Empty(result); 
        }

        [Fact]
        public void DeleteFirstAndLast_NullList_ReturnsEmptyNonNullList()
        {
            var result = OneFive.DeleteFirstAndLast(null!); 

            Assert.NotNull(result); 
            Assert.Empty(result); 
        }

        #endregion

        #region Задание 1. Задача 3: Анализ мебельных фабрик (FurnitureFactoryAnalysis)

        [Fact]
        public void FurnitureFactoryAnalysis_NullOrEmptyCatalog_PrintsCatalogEmptyMessage()
        {
            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FurnitureFactoryAnalysis(null!, new Dictionary<string, Dictionary<string,
                        HashSet<string>>>(), new HashSet<string> { "Иванов" }); 
                    Assert.Contains("Каталог фабрик пуст.", stringWriter.ToString()); 

                    stringWriter.GetStringBuilder().Clear(); 
                    OneFive.FurnitureFactoryAnalysis(new Dictionary<string, HashSet<string>>(), new Dictionary<string,
                        Dictionary<string, HashSet<string>>>(), new HashSet<string> { "Иванов" }); 
                    Assert.Contains("Каталог фабрик пуст.", stringWriter.ToString()); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }
        }

        [Fact]
        public void FurnitureFactoryAnalysis_NullOrEmptyCustomers_PrintsCustomersEmptyMessage()
        {
            var catalog = new Dictionary<string, HashSet<string>> 
            {
                { "Шатура", new HashSet<string> { "Диван" } } 
            };

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FurnitureFactoryAnalysis(catalog, new Dictionary<string, Dictionary<string,
                        HashSet<string>>>(), null!); 
                    Assert.Contains("Список покупателей пуст.", stringWriter.ToString()); 

                    stringWriter.GetStringBuilder().Clear(); 
                    OneFive.FurnitureFactoryAnalysis(catalog, new Dictionary<string, Dictionary<string,
                        HashSet<string>>>(), new HashSet<string>()); 
                    Assert.Contains("Список покупателей пуст.", stringWriter.ToString()); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }
        }

        [Fact]
        public void FurnitureFactoryAnalysis_ClassifiesItemsCorrectly_AllSomeNone()
        {
            var allCustomers = new HashSet<string> { "Иванов", "Петров" }; 
            var catalog = new Dictionary<string, HashSet<string>> 
            {
                { "Шатура", new HashSet<string> { "Диван", "Стол", "Шкаф" } } 
            };

            var purchases = new Dictionary<string, Dictionary<string, HashSet<string>>> 
            {
                {
                    "Иванов", new Dictionary<string, HashSet<string>> 
                    {
                        { "Шатура", new HashSet<string> { "Диван", "Стол" } } 
                    }
                },
                {
                    "Петров", new Dictionary<string, HashSet<string>> 
                    {
                        { "Шатура", new HashSet<string> { "Диван" } } 
                    }
                }
            };

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FurnitureFactoryAnalysis(catalog, purchases, allCustomers); 
                    string output = stringWriter.ToString(); 

                    Assert.Contains("Приобреталась всеми покупателями: Диван", output); 
                    Assert.Contains("Приобреталась некоторыми покупателями: Стол", output); 
                    Assert.Contains("Не приобреталась никем из покупателей: Шкаф", output); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }
        }

        [Fact]
        public void FurnitureFactoryAnalysis_NoPurchases_AllItemsInNoneCategory()
        {
            var allCustomers = new HashSet<string> { "Иванов", "Петров" }; 
            var catalog = new Dictionary<string, HashSet<string>> 
            {
                { "Аскона", new HashSet<string> { "Матрас", "Подушка" } } 
            };
            var purchases = new Dictionary<string, Dictionary<string, HashSet<string>>>(); 

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FurnitureFactoryAnalysis(catalog, purchases, allCustomers); 
                    string output = stringWriter.ToString(); 

                    Assert.Contains("Приобреталась всеми покупателями: нет", output); 
                    Assert.Contains("Приобреталась некоторыми покупателями: нет", output); 
                    Assert.Contains("Не приобреталась никем из покупателей: Матрас", output); 
                    Assert.Contains("Подушка", output); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }
        }

        [Fact]
        public void FurnitureFactoryAnalysis_AllItemsBoughtByAll_AllItemsInAllCategory()
        {
            var allCustomers = new HashSet<string> { "Иванов", "Петров" }; 
            var catalog = new Dictionary<string, HashSet<string>> 
            {
                { "Ангстрем", new HashSet<string> { "Кровать" } } 
            };

            var purchases = new Dictionary<string, Dictionary<string, HashSet<string>>> 
            {
                {
                    "Иванов", new Dictionary<string, HashSet<string>> 
                    {
                        { "Ангстрем", new HashSet<string> { "Кровать" } } 
                    }
                },
                {
                    "Петров", new Dictionary<string, HashSet<string>> 
                    {
                        { "Ангстрем", new HashSet<string> { "Кровать" } } 
                    }
                }
            };

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FurnitureFactoryAnalysis(catalog, purchases, allCustomers); 
                    string output = stringWriter.ToString(); 

                    Assert.Contains("Приобреталась всеми покупателями: Кровать", output); 
                    Assert.Contains("Приобреталась некоторыми покупателями: нет", output); 
                    Assert.Contains("Не приобреталась никем из покупателей: нет", output); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }
        }

        [Fact]
        public void FurnitureFactoryAnalysis_CustomerBoughtItemNotInCatalog_IgnoresUnknownItem()
        {
            var allCustomers = new HashSet<string> { "Иванов" }; 
            var catalog = new Dictionary<string, HashSet<string>> 
            {
                { "Шатура", new HashSet<string> { "Диван" } } 
            };

            var purchases = new Dictionary<string, Dictionary<string, HashSet<string>>> 
            {
                {
                    "Иванов", new Dictionary<string, HashSet<string>> 
                    {
                        { "Шатура", new HashSet<string> { "НесуществующийТовар" } } 
                    }
                }
            };

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FurnitureFactoryAnalysis(catalog, purchases, allCustomers); 
                    string output = stringWriter.ToString(); 

                    Assert.DoesNotContain("НесуществующийТовар", output); 
                    Assert.Contains("Не приобреталась никем из покупателей: Диван", output); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }
        }

        [Fact]
        public void FurnitureFactoryAnalysis_WithTestData_ExecutesWithoutExceptions()
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

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FurnitureFactoryAnalysis(factoryCatalog, customerPurchases, allCustomers); 
                    string output = stringWriter.ToString(); 

                    Assert.Contains("Фабрика \"Шатура\":", output); 
                    Assert.Contains("Фабрика \"Ангстрем\":", output); 
                    Assert.Contains("Фабрика \"Аскона\":", output); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }
        }

        [Fact]
        public void FurnitureFactoryAnalysis_CustomerPurchasesEntryIsNull_HandlesGracefully()
        {
            var allCustomers = new HashSet<string> { "Иванов" }; 
            var catalog = new Dictionary<string, HashSet<string>> 
            {
                { "Шатура", new HashSet<string> { "Диван" } } 
            };
            var purchases = new Dictionary<string, Dictionary<string, HashSet<string>>>(); 
            purchases.Add("Иванов", null!); 

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FurnitureFactoryAnalysis(catalog, purchases, allCustomers); 
                    string output = stringWriter.ToString(); 
                    Assert.Contains("Не приобреталась никем из покупателей: Диван", output); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }
        }

        [Fact]
        public void FurnitureFactoryAnalysis_CustomerFactoryPurchasesIsNull_HandlesGracefully()
        {
            var allCustomers = new HashSet<string> { "Иванов" }; 
            var catalog = new Dictionary<string, HashSet<string>> 
            {
                { "Шатура", new HashSet<string> { "Диван" } } 
            };
            var inner = new Dictionary<string, HashSet<string>>(); 
            inner.Add("Шатура", null!); 
            var purchases = new Dictionary<string, Dictionary<string, HashSet<string>>>(); 
            purchases.Add("Иванов", inner); 

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FurnitureFactoryAnalysis(catalog, purchases, allCustomers); 
                    string output = stringWriter.ToString(); 
                    Assert.Contains("Не приобреталась никем из покупателей: Диван", output); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }
        }

        [Fact]
        public void FurnitureFactoryAnalysis_CatalogEntryIsNull_HandlesGracefully()
        {
            var allCustomers = new HashSet<string> { "Иванов" }; 
            var catalog = new Dictionary<string, HashSet<string>>(); 
            catalog.Add("Шатура", null!); 
            var purchases = new Dictionary<string, Dictionary<string, HashSet<string>>>(); 

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FurnitureFactoryAnalysis(catalog, purchases, allCustomers); 
                    string output = stringWriter.ToString(); 
                    Assert.Contains("Ассортимент фабрики: нет", output); 
                    Assert.Contains("Не приобреталась никем из покупателей: нет", output); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }
        }

        #endregion

        #region Задание 1. Задача 4: Анализ глухих согласных в словах файла (FileWordAnalyzer)

        [Fact]
        public void FileWordAnalyzer_FileNotFound_PrintsNotFoundError()
        {
            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FileWordAnalyzer("non_existing_file_9999.txt"); 
                    string output = stringWriter.ToString(); 
                    Assert.Contains("не найден", output); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }
        }

        [Fact]
        public void FileWordAnalyzer_TemporaryFiles_MatchesExpectedConsoleOutput()
        {
            string basicFile = Path.GetTempFileName(); 
            File.WriteAllText(basicFile, "кот кит ток"); 

            string punctuationFile = Path.GetTempFileName(); 
            File.WriteAllText(punctuationFile, "...,,, !? ---"); 

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FileWordAnalyzer(punctuationFile); 
                    Assert.Contains("В файле нет слов.", stringWriter.ToString()); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }

            if (File.Exists(basicFile)) File.Delete(basicFile); 
            if (File.Exists(punctuationFile)) File.Delete(punctuationFile); 
        }

        [Fact]
        public void FileWordAnalyzer_RealWords_MatchesExpectedOutput()
        {
            string tempFile = Path.GetTempFileName(); 
            File.WriteAllText(tempFile, "котик сом ток"); 

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FileWordAnalyzer(tempFile); 
                    string output = stringWriter.ToString(); 
                    Assert.Contains("Результат: к, т", output); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }

            if (File.Exists(tempFile)) File.Delete(tempFile); 
        }

        [Fact]
        public void FileWordAnalyzer_AllDeafConsonantsInSingleWord_PrintsAllDeafLetters()
        {
            string tempFile = Path.GetTempFileName(); 
            File.WriteAllText(tempFile, "кптсфхцчшщ"); 

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FileWordAnalyzer(tempFile); 
                    string output = stringWriter.ToString(); 
                    Assert.Contains("Результат: к, п, с, т, ф, х, ц, ч, ш, щ", output); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }

            if (File.Exists(tempFile)) File.Delete(tempFile); 
        }

        [Fact]
        public void FileWordAnalyzer_NoMatchingLetters_PrintsNoLettersFound()
        {
            string tempFile = Path.GetTempFileName(); 
            File.WriteAllText(tempFile, "арбуз дыня"); 

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FileWordAnalyzer(tempFile); 
                    string output = stringWriter.ToString(); 
                    Assert.Contains("Подходящих букв не найдено.", output); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }

            if (File.Exists(tempFile)) File.Delete(tempFile); 
        }

        [Fact]
        public void FileWordAnalyzer_EvenAndOddWordCounts_HandlesCorrectly()
        {
            string evenWordsFile = Path.GetTempFileName(); 
            File.WriteAllText(evenWordsFile, "шапка шуба"); 

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FileWordAnalyzer(evenWordsFile); 
                    Assert.Contains("Результат: к, п", stringWriter.ToString()); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }
            if (File.Exists(evenWordsFile)) File.Delete(evenWordsFile); 

            string oddWordsFile = Path.GetTempFileName(); 
            File.WriteAllText(oddWordsFile, "шапка шуба каша"); 

            using (var stringWriter = new StringWriter()) 
            {
                var originalOut = Console.Out; 
                Console.SetOut(stringWriter); 
                try
                {
                    OneFive.FileWordAnalyzer(oddWordsFile); 
                    Assert.Contains("Результат: к", stringWriter.ToString()); 
                }
                finally
                {
                    Console.SetOut(originalOut); 
                }
            }
            if (File.Exists(oddWordsFile)) File.Delete(oddWordsFile); 
        }

        #endregion

        #region Задание 1. Задача 5: Мониторинг и анализ цен на сметану (CreateSourCreamFile, AnalyzeSourCreamPrices)

        [Fact]
        public void CreateSourCreamFile_ValidRecords_CreatesFileWithCorrectHeaderAndLines()
        {
            string tempFile = Path.GetTempFileName(); 
            List<string> sample = new List<string>(); 
            sample.Add("Фирма1 Улица1 15 2500"); 
            sample.Add("Фирма2 Улица2 20 3000"); 

            OneFive.CreateSourCreamFile(tempFile, sample); 

            Assert.True(File.Exists(tempFile)); 
            string[] lines = File.ReadAllLines(tempFile); 
            Assert.Equal(3, lines.Length); 
            Assert.Equal("2", lines[0]); 
            Assert.Equal("Фирма1 Улица1 15 2500", lines[1]); 
            Assert.Equal("Фирма2 Улица2 20 3000", lines[2]); 

            if (File.Exists(tempFile)) File.Delete(tempFile); 
        }

        [Fact]
        public void CreateSourCreamFile_NullOrEmptyRecords_CreatesFileWithZeroCount()
        {
            string tempFileNull = Path.GetTempFileName(); 
            OneFive.CreateSourCreamFile(tempFileNull, null!); 
            string[] linesNull = File.ReadAllLines(tempFileNull); 
            Assert.Single(linesNull); 
            Assert.Equal("0", linesNull[0]); 
            if (File.Exists(tempFileNull)) File.Delete(tempFileNull); 

            string tempFileEmpty = Path.GetTempFileName(); 
            OneFive.CreateSourCreamFile(tempFileEmpty, new List<string>()); 
            string[] linesEmpty = File.ReadAllLines(tempFileEmpty); 
            Assert.Single(linesEmpty); 
            Assert.Equal("0", linesEmpty[0]); 
            if (File.Exists(tempFileEmpty)) File.Delete(tempFileEmpty); 
        }

        [Fact]
        public void AnalyzeSourCreamPrices_CalculatesMinPricesAndStoreCounts()
        {
            string tempFile = Path.GetTempFileName(); 
            List<string> sample = new List<string>(); 
            sample.Add("A B 15 2200"); 
            sample.Add("C D 15 2500"); 
            sample.Add("E F 20 3000"); 
            sample.Add("G H 20 3000"); 
            sample.Add("I J 20 3500"); 
            sample.Add("K L 25 4000"); 
            sample.Add("M N 25 4000"); 
            sample.Add("O P 25 4000"); 

            OneFive.CreateSourCreamFile(tempFile, sample); 

            string result = OneFive.AnalyzeSourCreamPrices(tempFile); 

            Assert.Equal("1 2 3", result); 

            if (File.Exists(tempFile)) File.Delete(tempFile); 
        }

        [Fact]
        public void AnalyzeSourCreamPrices_EmptyFileOrHeaderOnly_ReturnsZeroes()
        {
            string emptyFile = Path.GetTempFileName(); 
            string resultEmpty = OneFive.AnalyzeSourCreamPrices(emptyFile); 
            Assert.Equal("0 0 0", resultEmpty); 
            if (File.Exists(emptyFile)) File.Delete(emptyFile); 

            string headerOnlyFile = Path.GetTempFileName(); 
            File.WriteAllText(headerOnlyFile, "5\n"); 
            string resultHeader = OneFive.AnalyzeSourCreamPrices(headerOnlyFile); 
            Assert.Equal("0 0 0", resultHeader); 
            if (File.Exists(headerOnlyFile)) File.Delete(headerOnlyFile); 
        }

        [Fact]
        public void AnalyzeSourCreamPrices_CorruptedHeaderOrLines_HandlesGracefully()
        {
            string badHeaderFile = Path.GetTempFileName(); 
            File.WriteAllText(badHeaderFile, "not_a_number\nShop Street 15 2500"); 
            string resultBadHeader = OneFive.AnalyzeSourCreamPrices(badHeaderFile); 
            Assert.Equal("0 0 0", resultBadHeader); 
            if (File.Exists(badHeaderFile)) File.Delete(badHeaderFile); 

            string badLinesFile = Path.GetTempFileName(); 
            List<string> corrupted = new List<string>(); 
            corrupted.Add("CorruptedLineWithoutParts"); 
            corrupted.Add("Shop Street not_int 3000"); 
            corrupted.Add("Shop Street 15 not_int"); 
            corrupted.Add("   "); 
            OneFive.CreateSourCreamFile(badLinesFile, corrupted); 
            string resultBadLines = OneFive.AnalyzeSourCreamPrices(badLinesFile); 
            Assert.Equal("0 0 0", resultBadLines); 
            if (File.Exists(badLinesFile)) File.Delete(badLinesFile); 
        }

        #endregion

        #region Задание 2. Задача 1: Класс Time и перегрузка операций

        [Fact]
        public void Time_DefaultConstructor_SetsZero()
        {
            var defaultTime = new Time(); 
            Assert.Equal(0, defaultTime.Hours); 
            Assert.Equal(0, defaultTime.Minutes); 
            Assert.Equal("00:00", defaultTime.ToString()); 
        }

        [Fact]
        public void Time_ParametrizedConstructor_SetsValidValues()
        {
            var time = new Time(14, 45); 
            Assert.Equal(14, time.Hours); 
            Assert.Equal(45, time.Minutes); 
            Assert.Equal("14:45", time.ToString()); 
        }

        [Theory]
        [InlineData(24, 0)] 
        [InlineData(25, 10)] 
        [InlineData(10, 60)] 
        [InlineData(10, 65)] 
        public void Time_ParametrizedConstructor_ThrowsOnOutOfRange(byte hours, byte minutes)
        {
            bool exceptionThrown = false; 
            try
            {
                new Time(hours, minutes); 
            }
            catch (ArgumentOutOfRangeException)
            {
                exceptionThrown = true; 
            }

            Assert.True(exceptionThrown); 
        }

        [Fact]
        public void Time_StringConstructor_ValidFormat_ParsesCorrectly()
        {
            var time = new Time("08:05"); 
            Assert.Equal(8, time.Hours); 
            Assert.Equal(5, time.Minutes); 
            Assert.Equal("08:05", time.ToString()); 
        }

        [Theory]
        [InlineData("")] 
        [InlineData("   ")] 
        [InlineData("abc")] 
        [InlineData("12-30")] 
        [InlineData("25:00")] 
        [InlineData("12:75")] 
        public void Time_StringConstructor_InvalidFormat_ThrowsException(string invalidInput)
        {
            bool exceptionThrown = false; 
            try
            {
                new Time(invalidInput); 
            }
            catch (Exception)
            {
                exceptionThrown = true; 
            }

            Assert.True(exceptionThrown); 
        }

        [Fact]
        public void Time_Subtract_WithoutDayTransition_CalculatesCorrectly()
        {
            var t1 = new Time(15, 30); 
            var t2 = new Time(5, 10); 

            var res = t1.Subtract(t2); 

            Assert.Equal("10:20", res.ToString()); 
        }

        [Fact]
        public void Time_Subtract_WithDayTransition_CalculatesCorrectly()
        {
            var t1 = new Time(2, 15); 
            var t2 = new Time(4, 30); 

            var res = t1.Subtract(t2); 

            Assert.Equal("21:45", res.ToString()); 
        }

        [Fact]
        public void Time_OperatorMinus_BorderTransition_CalculatesCorrectly()
        {
            var midnight = new Time(0, 0); 
            var oneMin = new Time(0, 1); 

            var res = midnight - oneMin; 

            Assert.Equal("23:59", res.ToString()); 
        }

        [Fact]
        public void Time_Subtract_Self_ReturnsZero()
        {
            var t = new Time(15, 30); 

            var res = t - t; 

            Assert.Equal("00:00", res.ToString()); 
        }

        [Fact]
        public void Time_OperatorIncrement_Normal_IncrementsMinute()
        {
            var t = new Time(10, 15); 
            t++; 

            Assert.Equal("10:16", t.ToString()); 
        }

        [Fact]
        public void Time_OperatorIncrement_HourTransition_IncrementsHour()
        {
            var t = new Time(10, 59); 
            t++; 

            Assert.Equal("11:00", t.ToString()); 
        }

        [Fact]
        public void Time_OperatorIncrement_DayTransition_WrapsToMidnight()
        {
            var t = new Time(23, 59); 
            t++; 

            Assert.Equal("00:00", t.ToString()); 
        }

        [Fact]
        public void Time_OperatorDecrement_Normal_DecrementsMinute()
        {
            var t = new Time(10, 16); 
            t--; 

            Assert.Equal("10:15", t.ToString()); 
        }

        [Fact]
        public void Time_OperatorDecrement_HourTransition_DecrementsHour()
        {
            var t = new Time(11, 0); 
            t--; 

            Assert.Equal("10:59", t.ToString()); 
        }

        [Fact]
        public void Time_OperatorDecrement_DayTransition_WrapsTo2359()
        {
            var t = new Time(0, 0); 
            t--; 

            Assert.Equal("23:59", t.ToString()); 
        }

        [Fact]
        public void Time_ImplicitOperatorInt_ReturnsTotalMinutes()
        {
            var t1 = new Time(0, 0); 
            var t2 = new Time(2, 15); 
            var t3 = new Time(23, 59); 

            int min1 = t1; 
            int min2 = t2; 
            int min3 = t3; 

            Assert.Equal(0, min1); 
            Assert.Equal(135, min2); 
            Assert.Equal(1439, min3); 
        }

        [Fact]
        public void Time_ExplicitOperatorBool_ReturnsExpectedValues()
        {
            var bothNonZero = new Time(1, 15); 
            var zeroHours = new Time(0, 15); 
            var zeroMinutes = new Time(1, 0); 
            var bothZero = new Time(0, 0); 

            Assert.True((bool)bothNonZero); 
            Assert.False((bool)zeroHours); 
            Assert.False((bool)zeroMinutes); 
            Assert.False((bool)bothZero); 
        }

        [Fact]
        public void Time_BinaryComparisonOperators_ComparesCorrectly()
        {
            var tSmall = new Time(10, 15); 
            var tBig = new Time(12, 0); 
            var tEqual = new Time(10, 15); 

            Assert.True(tSmall < tBig); 
            Assert.False(tSmall > tBig); 

            Assert.True(tBig > tSmall); 
            Assert.False(tBig < tSmall); 

            Assert.False(tSmall < tEqual); 
            Assert.False(tSmall > tEqual); 
        }

        #endregion
    }
}