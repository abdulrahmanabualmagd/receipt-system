/*
 *  the main difference between the IQueryable and IEnumerable is that
 *  IQueryable: Execute the query in server side
 *  IEnumerable: Execute the query in client side
 */

using System.Linq;

namespace Yield_Return
{
    class Program
    {
        static void Main()
        {
            /*
             * The entire data won't load because we're using the Yield return to simulate the lazy loading
             * Data will only load one by one sequentially when iterating over is like using foreach
             */

            #region IEnumerable
            /*
             * IEnumerable will execute the query in the client side 
             * the 'Where(x=>x<3)' consition will be executed here
             */
            IEnumerable<int> list = Yield_Return.GenerateNumber().Where(x => x < 3);
            foreach (int item in list) { Console.WriteLine(item); }
            #endregion

            #region IQueryable
            /*
             * IQueryable will execute the query in the server side 
             * the 'Where(x=x<3)' condition will be executed there in the server side
             */
            IQueryable<int> queryable = Yield_Return.GenerateNumber().AsQueryable().Where(x=> x<3); 
            foreach(int item in queryable) { Console.WriteLine(item);}
            #endregion
        }
    }
}