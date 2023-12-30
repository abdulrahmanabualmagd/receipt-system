using IComparer;

namespace Icomparer
{
    class Program
    {
        static void Main()
        {
            Person p1 = new Person(1, "Ahmed");
            Person p2 = new Person(2, "Yousef");

            PersonComparer pcomp = new PersonComparer();

            Console.WriteLine(pcomp.Compare(p1, p2));
            //  1 => p1 > p2
            //  0 => p1 = p2
            // -1 => p1 < p2
        }
    }
}