namespace Collections
{
    class Program
    {
        static void Main()
        {
            #region Arrays
            int[] array = new int[4];
            int[] array1 = new int[] { 1, 3, 5, 6 };
            #endregion

            #region Dictionary
            Dictionary<Product, int> Products = new Dictionary<Product, int>();
            // Dictionary[key] = value;
            #endregion

            #region List
            List<int> list = new List<int>();
            // list[index] = value
            #endregion

            #region HashSet
            // Represents an unordered unique elements
            HashSet<int> hashset = new HashSet<int> { 1, 2, 3, 5};
            #endregion

            #region SortedList
            // Maintians the sort order automatically
            SortedList<string, int> sortedlist = new SortedList<string, int>();
            sortedlist.Add("ahmed", 2);
            sortedlist.Add("khaled", 3);
            #endregion

            #region Queue 
            // FIFO
            // Used in Task Scheduling
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("First");
            queue.Enqueue("Second");
            // Console.WriteLine(queue.Dequeue()); // output: 'First'            
            #endregion

            #region Stack
            Stack<string> stack = new Stack<string>();
            stack.Push("First");
            stack.Push("Second");

            // Console.WriteLine(stack.Pop());  // output: Second
            #endregion


        }
    }
}