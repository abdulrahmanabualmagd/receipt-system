namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Publishers
            Publisher publisher1 = new Publisher("Pub1");
            Publisher publisher2 = new Publisher("Pub2");
            #endregion

            #region Listeners
            Listener listener1 = new Listener("Lis1");
            Listener listener2 = new Listener("Lis2");
            #endregion

            #region Subscribe
            listener1.Subscribe(publisher2);
            listener1.Subscribe(publisher1);
            listener2.Subscribe(publisher1);
            #endregion

            #region Raise Event
            publisher1.RaiseEvent("This is 12/29/2023");
            #endregion

            #region UnSubscribe
            listener1.UnSubscribe(publisher2);
            #endregion
        }
    }
}