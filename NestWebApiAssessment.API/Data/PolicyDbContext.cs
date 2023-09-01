using Microsoft.EntityFrameworkCore;
using NestWebApiAssessment.API.Model.Domain;

namespace NestWebApiAssessment.API.Data
{
    public class PolicyDbContext: DbContext
    {
        public PolicyDbContext(DbContextOptions options): base(options)
        {
            
        }

       /* //fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Primary Key for VehicleType
            modelBuilder.Entity<VehicleTypes>().HasKey(vehicleTypes => vehicleTypes.VehicleTypeId);
            //Relation between VehicleTypes and Brands
            modelBuilder.Entity<VehicleTypes>()
                .HasMany(vehicleTypes => vehicleTypes.Brands)
                .WithOne(brands => brands.VehicleTypes)
                .HasForeignKey(brands => brands.VehicleTypeId);


            //Primary Key for Brand
            modelBuilder.Entity<Brands>().HasKey(brands => brands.BrandId);
            //Relation between Brand and VehicleTypes
            modelBuilder.Entity<Brands>()
                .HasOne(brands => brands.VehicleTypes)
                .WithMany(vehicleTypes=> vehicleTypes.Brands)
                .HasForeignKey(brands => brands.VehicleTypeId);


            //Primary Key for Models
            modelBuilder.Entity<Models>().HasKey(models => models.ModelId);
            //Relation between Models and Brands
            modelBuilder.Entity<Models>()
                .HasOne(models => models.Brands)
                .WithMany(brands => brands.Models)
                .HasForeignKey(models => models.BrandId);


        }*/

        //DbSet
        public DbSet<VehicleTypes> Vehicletype { get; set; }
        public DbSet<Brands>  Brand { get; set; }
        public DbSet<Models> Model { get; set; }

    }
}
