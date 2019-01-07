namespace PicoBeer.Domain
{
    public abstract class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set;}
    }
}