namespace IEnumerableIEnumeratorGeneric
{
    class Program
    {
        static void Main()
        {
            #region Assign Eelements to the Person List
            PList<Person> plist = new PList<Person>(5);
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