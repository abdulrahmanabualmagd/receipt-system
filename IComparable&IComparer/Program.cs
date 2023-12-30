namespace IComparable
{
    class Program
    {
        static void Main()
        {
            Person p1 = new Person(1, "ahmed");
            Person p2 = new Person(1, "ahmed");

            Console.WriteLine(p1.CompareTo(p2));
            //  1 => p1 > p2
            //  0 => p1 = p2
            // -1 => p1 < p2
        }
    }
}