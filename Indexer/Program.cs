/*
    An indexer in C# allows access to elements within this class using array-like syntax. 
    For instance, if we have a class 'Person' and another class 'PList' containing an array of persons ('_plist'), 
    we can access this array using the indexer. 
    The indexer is similar to a property, but it permits indexing the class 
    By adding square brackets '[]' to the instance name.
*/

namespace Indexer
{
    class Program
    {
        static void Main()
        {
            #region Create Object
            PList list = new PList(5); 
            #endregion

            #region Indexer Set Accessor
            list[0] = new Person(0, "Ahmed");
            list[1] = new Person(1, "Yousef");
            list[2] = new Person(2, "Abdo");
            #endregion

            #region Indexer Get Accessor
            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
            Console.WriteLine(list[2]);
            #endregion

        }
    }
}