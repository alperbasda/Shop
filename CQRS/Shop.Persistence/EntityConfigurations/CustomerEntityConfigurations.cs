using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RelationalEntities;
using Shop.Persistence.Constants;

namespace Shop.Persistence.EntityConfigurations;

public class CustomerEntityConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(t => t.Id);

        builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
        builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
        builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
        builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

        builder.Property(w => w.FirstName).HasColumnName("FirstName").HasMaxLength(EntityConfigurationConstants.MidLevelMaxLength).IsRequired();
        builder.Property(w => w.LastName).HasColumnName("LastName").HasMaxLength(EntityConfigurationConstants.MidLevelMaxLength).IsRequired();
    }
}
