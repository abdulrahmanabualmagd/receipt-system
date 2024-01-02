using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable_IEnumerator
{
    public class PList : IEnumerable
    {
        #region private
        private Person[] _plist;
        public int index;
        #endregion

        #region Ctor
        public PList() : this(5) { }
        public PList(int size)
        {
            _plist = new Person[size];
        }
        #endregion

        #region Indexer
        internal Person this[int index]
        {
            // Unlike the indexer project, we will add a counter for counting the array length while filling
            get { return _plist[index]; }
            set 
            { 
                _plist[index] = value; 
                this.index++; 
            }
        }
        #endregion

        #region IEnumerable Implementation
        public IEnumerator GetEnumerator()
        {
            // Method expect to return an IEnumerator interface or an object that implements the IEnumerator interface.
            return new Iterator(this);      
        } 
        #endregion
    }
}
