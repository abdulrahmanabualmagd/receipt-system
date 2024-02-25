namespace Web.ViewModels
{
    public class Counts
    {
        #region Private
        private int _categoryCount;
        private int _itemCount;
        #endregion
        
        #region Properties
        public int CategoryCount
        {
            get { return _categoryCount; }
        }
        public int ItemCount
        {
            get { return _itemCount; }
        }
        #endregion

        #region Ctor
        public Counts(): this(0, 0) { }

        public Counts(int cNo, int iNo)
        {
            _categoryCount = cNo;
            _itemCount = iNo;
        }
        #endregion
    }
}
