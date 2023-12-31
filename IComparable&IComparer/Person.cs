

namespace IComparable
{
    public class Person : IComparable<Person>
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

        #region IComparable Implementation
        public int CompareTo(Person? obj)
        {
            return this.Id.CompareTo(obj.Id);
            // return  1 => this.id > obj.id
            // return  0 => this.id = obj.id
            // return -1 => this.id < obj.id
        } 
        #endregion



    }
}
