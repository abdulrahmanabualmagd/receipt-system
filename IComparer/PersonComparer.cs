/*
 * Purpose 
 */
using Icomparer;

namespace IComparer
{
    internal class PersonComparer : IComparer<Person>
    {
        #region IComparer Implementation
        public int Compare(Person? x, Person? y)
        {
            return x.Id.CompareTo(y.Id);
        }
        #endregion
    }
}
