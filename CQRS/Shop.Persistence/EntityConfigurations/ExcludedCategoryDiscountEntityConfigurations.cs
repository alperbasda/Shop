using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RelationalEntities;

namespace Shop.Persistence.EntityConfigurations;

public class ExcludedCategoryDiscountEntityConfigurations : IEntityTypeConfiguration<ExcludedCategoryDiscount>
{
    public void Configure(EntityTypeBuilder<ExcludedCategoryDiscount> builder)
    {
        builder.ToTable("ExcludedCategoryDiscounts").HasKey(t => t.Id);

        builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
        builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
        builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
        builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

        builder.Property(w => w.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(w => w.DiscountId).HasColumnName("DiscountId").IsRequired();

        builder.HasOne(w => w.Category).WithMany(w => w.ExcludedCategoryDiscounts).HasForeignKey(w => w.CategoryId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(w => w.Discount).WithMany(w => w.ExcludedCategoryDiscounts).HasForeignKey(w => w.DiscountId).OnDelete(DeleteBehavior.Restrict);
    }
}
