using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using PicoBeer.Domain;

namespace PicoBeer.Dal
{
    public partial class PicoBeerContext : DbContext
    {
        public PicoBeerContext()
        {
        }

        public PicoBeerContext(DbContextOptions<PicoBeerContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Malt> Malt { get; set; }
        public virtual DbSet<Hop> Hop { get; set; }
        public virtual DbSet<Yeast> Yeast { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<RecipeMalt> RecipeMalt { get; set; }
        public virtual DbSet<RecipeHop> RecipeHop { get; set; }
        public virtual DbSet<RecipeYeast> RecipeYeast { get; set; }
        


    }
}
