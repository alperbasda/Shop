﻿using Core.Persistence.Dynamic;
using Core.Persistence.Models;
using Shop.Domain.Enum;

namespace Shop.Domain.RelationalEntities;

public class DiscountCriterion : Entity<Guid>
{
    public Guid DiscountId { get; set; }

    public virtual Discount Discount { get; set; }

    public DiscountAssignType DiscountAssignType { get; set; }

    public FilterOperator FilterOperator { get; set; }

    public string Criterion { get; set; }
}