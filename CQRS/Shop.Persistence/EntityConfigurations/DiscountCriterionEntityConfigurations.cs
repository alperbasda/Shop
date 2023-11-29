using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RelationalEntities;

namespace Shop.Persistence.EntityConfigurations;

public class DiscountCriterionEntityConfigurations : IEntityTypeConfiguration<DiscountCriterion>
{
    public void Configure(EntityTypeBuilder<DiscountCriterion> builder)
    {
        builder.ToTable("DiscountCriteria").HasKey(t => t.Id);

        builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
        builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
        builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
        builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

        builder.Property(w => w.Criterion).HasColumnName("Criterion").IsRequired();
        builder.Property(w => w.DiscountAssignType).HasColumnName("DiscountAssignType").IsRequired();
        builder.Property(w => w.FilterOperator).HasColumnName("FilterOperator").IsRequired();
        builder.Property(w => w.DiscountId).HasColumnName("DiscountId").IsRequired();

        builder.HasOne(w => w.Discount);
    }
}
