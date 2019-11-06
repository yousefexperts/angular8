using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DotNetCoreArchitecture.Database.Inventory
{
    public class ItemEntityConfiguration : IEntityTypeConfiguration<ItemEntity>
    {
        public void Configure(EntityTypeBuilder<ItemEntity> builder)
        {
            builder.ToTable("ItemInventory", "User");

            builder.HasKey(x => x.ItemId);

            builder.Property(x => x.ItemName).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.MaxNum).IsRequired();

            builder.Property(x => x.MinNum).IsRequired();

            //builder.HasMany(x => x.).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
