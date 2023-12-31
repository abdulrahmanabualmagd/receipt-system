using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IQueryable_IEnumerable
{
    #region Person Class
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Age}";
        }
    }
    #endregion

    public class ServerSide
    {

        #region Data Assignation
        private List<Person> list = new List<Person>
        {
            #region Data
            new Person { Id = 1, Name = "John", Age = 30 },
            new Person { Id = 2, Name = "Alice", Age = 25 },
            new Person { Id = 3, Name = "Bob", Age = 35 },
            new Person { Id = 4, Name = "Eve", Age = 28 },
            new Person { Id = 5, Name = "Charlie", Age = 32 },
            new Person { Id = 6, Name = "Diana", Age = 27 },
            new Person { Id = 7, Name = "Frank", Age = 40 },
            new Person { Id = 8, Name = "Grace", Age = 22 },
            new Person { Id = 9, Name = "Henry", Age = 31 },
            new Person { Id = 10, Name = "Ivy", Age = 29 },
            new Person { Id = 11, Name = "Jack", Age = 33 },
            new Person { Id = 12, Name = "Lily", Age = 26 },
            new Person { Id = 13, Name = "Mark", Age = 37 },
            new Person { Id = 14, Name = "Nina", Age = 24 },
            new Person { Id = 15, Name = "Oliver", Age = 34 },
            new Person { Id = 16, Name = "Paula", Age = 23 },
            new Person { Id = 17, Name = "Quinn", Age = 38 },
            new Person { Id = 18, Name = "Ryan", Age = 28 },
            new Person { Id = 19, Name = "Samantha", Age = 36 },
            new Person { Id = 20, Name = "Tom", Age = 27 },
            #endregion
        };
        #endregion

        #region GetIEnumerable
        public IEnumerable<Person> GetPeopleIEnumerable()
        {
            return list;
        }
        #endregion

        #region GetIQueryable
        public IQueryable<Person> GetPeopleIQueryable()
        {
            return list.AsQueryable();
        }
        #endregion

    }
}
