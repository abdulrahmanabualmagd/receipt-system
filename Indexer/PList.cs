/*
 * Indexer like the property used for accessing class elements but indexer used to access 
 * Elements of the instace using array-like syntax
 * 'Person this[int index]' is like a property that dealing with objects from type Person and use 'this' keyword to
 * Indicate the instance name and accept Integer values to access it's elements
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    internal class PList
    {
        #region private
        private Person[] _plist; 
        #endregion

        #region Indexer
        internal Person this[int index]
        {
            get { return _plist[index]; }
            set { _plist[index] = value; }
        }
        #endregion

        #region Ctor
        public PList() : this(5) { }
        public PList(int size)
        {
            _plist = new Person[size];
        }
        #endregion

    }
}
