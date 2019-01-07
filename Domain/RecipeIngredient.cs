namespace PicoBeer.Domain
{
    public abstract class RecipeIngredient<T>  : BaseEntity  where T : Ingredient
    {
        public Recipe Recipe { get; set;}
        public T Ingredient { get; set; }
        public double Quantity { get; set;}

    }
}