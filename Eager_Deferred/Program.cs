using System.Linq;

namespace Eager_Deferred
{
    class Program
    {
        static void Main()
        {

            /*
             * - All Data is loaded 
             */
            #region Eager
            IEnumerable<Person> q1 = Data.list;
            IEnumerable<Person> q4 = Data.list.Select(person => person).ToList();
            #endregion

            /*
             * - Data not loaded
             * - query with expression tree stored until iteratation or using methods to make it eager
             */
            #region MyRegion
            IEnumerable<Person> q2 = Data.list.Select(person => person).Where(person => person.Age < 25);
            #endregion

        }
    }
}