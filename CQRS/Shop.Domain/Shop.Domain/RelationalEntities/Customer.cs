﻿using Core.Persistence.Models;
using Shop.Domain.MongoEntities;

namespace Shop.Domain.RelationalEntities;

public class Customer : Entity<Guid>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<CustomerRoleRelation> CustomerRoles { get; set; }

}
