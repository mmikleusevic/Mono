using Microsoft.EntityFrameworkCore;
using Mono.SharedLibrary;

namespace Mono.Service.MonoDbContext
{
    public partial class MonoContext : DbContext
    {
        public MonoContext()
        {
        }

        public MonoContext(DbContextOptions<MonoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VehicleMake> VehicleMakes { get; set; }
        public virtual DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //VehicleMake
            modelBuilder.Entity<VehicleMake>()
                .HasMany(e => e.VehicleModels)
                .WithOne(e => e.VehicleMake)
                .HasForeignKey(e => e.MakeId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VehicleMake>()
                .Property(a => a.Abrv).HasMaxLength(50);

            modelBuilder.Entity<VehicleMake>()
                .Property(a => a.Name).HasMaxLength(30);


            //VehicleModel
            modelBuilder.Entity<VehicleModel>()
                .HasOne(e => e.VehicleMake);

            modelBuilder.Entity<VehicleModel>()
                .Property(a => a.Abrv).HasMaxLength(50);

            modelBuilder.Entity<VehicleModel>()
                .Property(a => a.Name).HasMaxLength(30);

            OnModelCreatingPartial(modelBuilder);

            //Dummy Data

            modelBuilder.Entity<VehicleMake>().HasData(
               new VehicleMake
               {
                   Id = 1,
                   Name = "BMW",
                   Abrv = "Bayerische Motoren Werke GmbH"
               },
               new VehicleMake
               {
                   Id = 2,
                   Name = "Porsche",
                   Abrv = "Porsche"
               },
               new VehicleMake
               {
                   Id = 3,
                   Name = "Ferrari",
                   Abrv = "Ferrari"
               }
           );

            modelBuilder.Entity<VehicleModel>().HasData(
               new VehicleModel
               {
                   Id = 1,
                   MakeId = 1,
                   Name = "X5",
                   Abrv = "X5"
               },
               new VehicleModel
               {
                   Id = 2,
                   MakeId = 2,
                   Name = "911 Carrera",
                   Abrv = "911 Carrera"
               },
               new VehicleModel
               {
                   Id = 3,
                   MakeId = 3,
                   Name = "550 Maranello",
                   Abrv = "550 Maranello"
               }
           );
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
