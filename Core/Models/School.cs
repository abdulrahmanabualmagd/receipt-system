namespace Core.Models
{
    public class School
    {
        #region Properties
        public int Id { get; set; }
        public string? Name { get; set; } 
        #endregion

        #region Navigation Property
        public virtual ICollection<Student>? Students { get; set; } 
        #endregion
    }
}
