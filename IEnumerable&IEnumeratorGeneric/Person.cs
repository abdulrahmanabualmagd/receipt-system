using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableIEnumeratorGeneric
{
    public class Person
    {
        #region Private
        private int _id;
        private string _name; 
        #endregion

        #region Properties
        public int Id
        {
            set { this._id = value; }
            get { return this._id; }
        }
        public string Name
        {
            set { this._name = value; }
            get { return this._name; }
        }
        #endregion

        #region Constructor
        public Person(): this(0, "N/A") { }
        public Person(int id, string name)
        {
            _id = id;
            _name = name;
        }
        public Person(Person person):this(person.Id, person.Name) { }
        #endregion

    }
}
