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

        }
    }
}
