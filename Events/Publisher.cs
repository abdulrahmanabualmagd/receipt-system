using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void MyDelegate(string message);

    internal class Publisher
    {
        

        #region private
        private string _name;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        #endregion

        #region Ctor
        public Publisher(): this ("N/A"){}
        public Publisher(string name)
        {
            _name = name;
        }
        #endregion

        #region Event
        private event MyDelegate? _myEvent;
        #endregion

        #region Event Property
        public event MyDelegate MyEvent
        {
            add
            {
                _myEvent += value;
            }
            remove
            {
                _myEvent -= value;
            }
        }
        #endregion

        #region Fire Event
        public void RaiseEvent(string message)
        {
            _myEvent?.Invoke("message");
        } 
        #endregion
    }
}
