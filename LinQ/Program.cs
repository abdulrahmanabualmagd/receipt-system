using LinQ;

namespace LinQToObjects
{
    class Program
    {
        static void Main()
        {
            #region Repository
            Data data = new Data();
            #endregion

            #region Method Syntax
            /*
             * - [Deferred Execution]
             * - the expression tree is stored in IEnumerable<Person> until demand
             * - Iterate over IEnumerable Interface to to execute it and get the data
             */
            IEnumerable<Person> Defered = data.list.Where(p => p.Age < 30);

            /*
             * - [Eager Execution]
             * - the entire data is loaded and stored in IEnumerable<Person>
             */
            IEnumerable<Person> Eager = data.list;
            #endregion

            #region SQL-Like Syntax
            // from [item] in [mydata]  where ............... select [item]
            IEnumerable<Person> Sql_like = from person in data.list where person.Age < 25 select person;

            // the cast here because we are selecting anonymous type 'new { item.Name, item.Age }'
            IEnumerable<Person> query1 = (IEnumerable<Person>)(from item in data.list where item.Age > 30 select new { item.Name, item.Age });
            #endregion

            #region Execute the Query IEnumerable<Person>
            foreach (Person item in Defered)
            {
                Console.WriteLine(item);
            }
            #endregion
        }

    }
}