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
}

