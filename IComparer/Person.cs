using System.Collections;

namespace Icomparer

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
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        #endregion

        #region Constructor

        // Default Constructor 
        public Person() : this(0, "N/A") { }

        // Parameterized Constructor
        public Person(int id, string name)
        {
            this._id = id;
            this._name = name;
        }

        // Deep Copy Constructor
        public Person(Person person) : this(person._id, person._name) { }

        // Shallow Copy Method
        public Person clone()
        {
            return this;
        }



        #endregion

    }
}
