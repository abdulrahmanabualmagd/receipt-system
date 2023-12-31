/*
 * 
 */

namespace IQueryable_IEnumerable
{
    class Program
    {
        static void Main()
        {

            #region Repository
            ServerSide repository = new ServerSide();
            #endregion

            #region IEnumerable
            /*
             * IEnumerable will execute the query in the client side 
             * the 'Where(x=>x<3)' condition will be executed here
             */
            IEnumerable<Person> list = repository.GetPeopleIEnumerable().Where(x => x.Age < 30);
            foreach (Person item in list) { Console.WriteLine(item); }
            #endregion

            #region IQueryable
            /*
             * IQueryable will execute the query in the server side 
             * the 'Where(x=x<3)' condition will be executed there in the server side
             */
            IQueryable<Person> queryable = repository.GetPeopleIQueryable().Where(x => x.Age < 30);
            foreach (Person item in queryable) { Console.WriteLine(item); }
            #endregion
        }
    }
}