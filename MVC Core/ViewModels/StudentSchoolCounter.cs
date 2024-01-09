namespace MVC_Core.ViewModels
{
    public class StudentSchoolCounter
    {
        #region Private
        private int _studentCount;
        private int _schoolCount;

        #endregion
        
        #region Properties
        public int StudentCount
        {
            get { return _studentCount; }
        }
        public int SchoolCount
        {
            get { return _schoolCount; }
        }
        #endregion

        #region Ctor
        public StudentSchoolCounter(): this(0, 0) { }

        public StudentSchoolCounter(int studentCount, int schoolCount)
        {
            _studentCount = studentCount;
            _schoolCount = schoolCount;
        }
        #endregion
    }
}
