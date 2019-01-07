using System.Collections.Generic;

namespace PicoBeer.Domain
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Volume { get; set; }
        public List<RecipeMalt> ListMalt { get; set; }
        public List<RecipeHop> ListHop { get; set; }
        public List<RecipeYeast> ListYeast { get; set; }
    }
}