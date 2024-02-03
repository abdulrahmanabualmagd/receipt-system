namespace Web.ViewModels
{
    public class Counts
    {
        #region Private
        private int _studentCount;
        private int _schoolCount;
        private int _departmentcount;
        private int _courseCount;
        private int _teacherCount;
        private int _classroomCount;
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
        public int DepartmentCount
        {
            get { return _departmentcount; }
        }
        public int TeacherCount
        {
            get { return _teacherCount; }
        }
        public int CourseCount
        {
            get { return _courseCount; }
        }
        public int ClassroomCount
        {
            get { return _classroomCount; }
        }
        #endregion

        #region Ctor
        public Counts(): this(0, 0, 0, 0, 0, 0) { }

        public Counts(int stNo, int scNo, int depNo, int coNo, int teNo, int clNo)
        {
            _studentCount = stNo;
            _schoolCount = scNo;
            _departmentcount = depNo;
            _courseCount = coNo;
            _teacherCount = teNo;
            _classroomCount = clNo;
        }
        #endregion
    }
}
