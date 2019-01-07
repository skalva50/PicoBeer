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
        


    }
}
