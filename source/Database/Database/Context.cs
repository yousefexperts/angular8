using DotNetCore.EntityFrameworkCore;
using DotNetCoreArchitecture.Database.Tables;
using DotNetCoreArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Database
{
    public sealed class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        /*public Context() { }*/
        public DbSet<CatogriesTable> CatogriesTables { get; set; }

        public DbSet<ItemsInventoryTable> ItemsInventoryTables { get; set; }

        public DbSet<ItemEntity> ItemEntities { get; set; }

        public DbSet<CatogryEntity> CatogryEntities { get; set; }


        public DbSet<HallEntity> HallEntities { get; set; }


        public DbSet<HallReservationEntity> HallReservationEntityies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CatogriesTable>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.Value).IsRequired();
            });

            builder.Entity<ItemEntity>(entity =>
            {
                entity.Property(e => e.CatogryId).IsRequired();
                entity.Property(e => e.CreateDate).IsRequired();
                entity.Property(e => e.ItemName).IsRequired();
                entity.Property(e => e.MaxNum).IsRequired();
                entity.Property(e => e.MinNum).IsRequired();
                entity.Property(e => e.IsExist).IsRequired();
            });

            builder.Entity<ItemsInventoryTable>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.ItemName).IsRequired();
                entity.Property(e => e.MaxNum).IsRequired();
                entity.Property(e => e.MinNum).IsRequired();
            });
            builder.Entity<CatogryEntity>(entity =>
            {
                entity.Property(e => e.CatogryId).IsRequired();
                entity.Property(e => e.Description).IsRequired();
            });

            builder.Entity<HallEntity>(entity =>
            {
                entity.Property(e => e.HallId).IsRequired();
                entity.Property(e => e.HallName).IsRequired();
                entity.Property(e => e.Description).IsRequired();
            });

            builder.Entity<HallReservationEntity>(entity =>
            {
                entity.Property(e => e.ReservationId).IsRequired();
                entity.Property(e => e.HallId).IsRequired();
                entity.Property(e => e.StartDate).IsRequired();
                entity.Property(e => e.EndDate).IsRequired();
                entity.Property(e => e.Notes).IsRequired();

            });

            builder.ApplyConfigurationsFromAssembly();
            builder.Seed();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*optionsBuilder.UseSqlServer("Server=NEWSOFT-TR02;Database=HrModule;User Id=sa; Password=opc@2018;");*/
        }
    }
}
