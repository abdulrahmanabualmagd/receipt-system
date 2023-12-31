using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class Listener
    {
        #region Private
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

        public Listener(string name = "N/A")
        {
            Name = name;
        }
        #endregion

        #region Subscription
        public void Subscribe(Publisher publisher)
        {
            Console.WriteLine($"{Name} is Subscribing");
            publisher.MyEvent += HandleEvent;
        }

        public void UnSubscribe(Publisher publisher)
        {
            Console.WriteLine($"{Name} is UnSubscribing");
            publisher.MyEvent -= HandleEvent;
        }
        #endregion

        #region Handle Event
        public void HandleEvent(string message)
        {
            Console.WriteLine($"{Name} received message: {message}");
        } 
        #endregion
    }
}
