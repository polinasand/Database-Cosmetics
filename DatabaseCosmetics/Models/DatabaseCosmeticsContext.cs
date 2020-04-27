using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCosmetics.Models     
{
    public class DatabaseCosmeticsContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<CosmType> CosmTypes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Finish> Finishes { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public DatabaseCosmeticsContext(DbContextOptions<DatabaseCosmeticsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
