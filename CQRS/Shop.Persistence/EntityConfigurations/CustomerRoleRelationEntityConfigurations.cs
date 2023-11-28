using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RelationalEntities;

namespace Shop.Persistence.EntityConfigurations;

public class CustomerRoleRelationEntityConfigurations : IEntityTypeConfiguration<CustomerRoleRelation>
{
    public void Configure(EntityTypeBuilder<CustomerRoleRelation> builder)
    {
        builder.ToTable("CustomerRoleRelations").HasKey(t => t.Id);

        builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
        builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
        builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
        builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

        builder.Property(w => w.LastValidTime).HasColumnName("LastValidTime");
        builder.Property(w => w.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(w => w.RoleId).HasColumnName("RoleId").IsRequired();

        builder.HasOne(w => w.Role).WithMany(w => w.RoleCustomers).HasForeignKey(w => w.RoleId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(w => w.Customer).WithMany(w => w.CustomerRoles).HasForeignKey(w => w.CustomerId).OnDelete(DeleteBehavior.Restrict);

    }
}
