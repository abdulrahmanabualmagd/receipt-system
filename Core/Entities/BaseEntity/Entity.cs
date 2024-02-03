namespace Core.Entities.BaseEntity
{
    public class Entity       // Used as a constraint for generic types. Means that any class must contain these properties in this class
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
