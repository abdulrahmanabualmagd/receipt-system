namespace Core.Models
{
    public class School : Entity
    {
        public int StudentCount { get; set; } 

        #region Navigation Property
        public virtual ICollection<Student>? Students { get; set; } 
        #endregion
    }
}
