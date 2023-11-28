using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RelationalEntities;

namespace Shop.Persistence.EntityConfigurations;

public class DiscountRoleRelationEntityConfigurations : IEntityTypeConfiguration<DiscountRoleRelation>
{
    public void Configure(EntityTypeBuilder<DiscountRoleRelation> builder)
    {
        builder.ToTable("DiscountRoleRelations").HasKey(t => t.Id);

        builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
        builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
        builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
        builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

        builder.Property(w => w.RoleId).HasColumnName("RoleId").IsRequired();
        builder.Property(w => w.DiscountId).HasColumnName("DiscountId").IsRequired();

        builder.HasOne(w => w.Role).WithMany(w => w.RoleDiscounts).HasForeignKey(w => w.RoleId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(w => w.Discount).WithMany(w => w.DiscountRoles).HasForeignKey(w => w.DiscountId).OnDelete(DeleteBehavior.Restrict);
    }
}
