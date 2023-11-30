using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RelationalEntities;
using Shop.Persistence.Constants;

namespace Shop.Persistence.EntityConfigurations;

public class ProductEntityConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(t => t.Id);

        builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
        builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
        builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
        builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

        builder.Property(w => w.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(w => w.UnitPrice).HasColumnName("UnitPrice").IsRequired();
        builder.Property(w => w.Name).HasColumnName("Name").IsRequired().HasMaxLength(EntityConfigurationConstants.MidLevelMaxLength);

        builder.HasOne(w => w.Category);
    }
}
