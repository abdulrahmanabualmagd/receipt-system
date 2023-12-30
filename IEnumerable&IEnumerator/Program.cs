/*
 * 
 */

using System.Security.Cryptography.X509Certificates;

namespace IEnumerable_IEnumerator
{
    class Program
    {
        static void Main()
        {
            #region Assign Eelements to the Person List
            PList plist = new PList(5);
            plist[0] = new Person(1, "ahmed");
            plist[1] = new Person(4, "ahmed");
            plist[2] = new Person(2, "ahmed");
            #endregion


            #region foreach with Enumerable list(which we created)
            foreach (Person item in plist)
            {
                Console.WriteLine(item.Name);
            } 
            #endregion
        }
    }
}