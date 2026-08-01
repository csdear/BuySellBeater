using BuySellBeater.api.Models;
using Microsoft.EntityFrameworkCore;

namespace BuySellBeater.Api.Persistence
{
    public class BuySellBeaterDBContext : DbContext
    {
        public BuySellBeaterDBContext(DbContextOptions<BuySellBeaterDBContext> options)
            : base(options)
        {
        }

        public DbSet<Make> Makes { get; set; } = null!;
        public DbSet<Model> Models { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Model>()
                .HasOne(m => m.Make)
                .WithMany(m => m.Models)
                .HasForeignKey(m => m.MakeId);

            modelBuilder.Entity<Make>().HasData(
                new Make { Id = 1, Name = "Isuzu" },
                new Make { Id = 2, Name = "Nissan" },
                new Make { Id = 3, Name = "Honda" }
            );

            modelBuilder.Entity<Model>().HasData(
                new Model { Id = 1, Name = "Pup", MakeId = 1 },
                new Model { Id = 2, Name = "Impulse", MakeId = 1 },
                new Model { Id = 3, Name = "Trooper", MakeId = 1 },

                new Model { Id = 4, Name = "Sentra", MakeId = 2 },
                new Model { Id = 5, Name = "300ZX", MakeId = 2 },
                new Model { Id = 6, Name = "XTerra", MakeId = 2 },

                new Model { Id = 7, Name = "CRX", MakeId = 3 },
                new Model { Id = 8, Name = "Civic", MakeId = 3 },
                new Model { Id = 9, Name = "Prelude", MakeId = 3 }
            );
        }
    }
}