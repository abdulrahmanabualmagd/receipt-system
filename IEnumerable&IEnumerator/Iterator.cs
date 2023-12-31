using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable_IEnumerator
{
    public class Iterator : IEnumerator
    {
        #region Private
        private int _index;
        private PList _plist;
        #endregion

        #region Ctor
        public Iterator(PList plist) 
        {
            _plist = plist;
            _index = 0;
        }
        #endregion

        #region IEnumerator Implementation
        object IEnumerator.Current => _plist[_index++];     // Return the Current Value and Add 1 to the index

        public bool MoveNext()
        {
            return _index < _plist.index;                   // Move Condition 
        }

        public void Reset()                                 // Reset the index to Iterate from the begining at the second time
        {
            _index = 0;
        } 
        #endregion
    }
}
