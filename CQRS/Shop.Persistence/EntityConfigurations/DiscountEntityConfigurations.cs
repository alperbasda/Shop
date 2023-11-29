using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RelationalEntities;
using Shop.Persistence.Constants;

namespace Shop.Persistence.EntityConfigurations;

public class DiscountEntityConfigurations : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable("Discounts").HasKey(t => t.Id);

        builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
        builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
        builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
        builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

        builder.Property(w => w.DiscountUsageType).HasColumnName("DiscountUsageType").IsRequired();
        builder.Property(w => w.Priority).HasColumnName("Priority").IsRequired();
        builder.Property(w => w.Value).HasColumnName("Value").IsRequired();
        builder.Property(w => w.Name).HasColumnName("Name").IsRequired().HasMaxLength(EntityConfigurationConstants.MinLevelMaxLength);
    }
}
