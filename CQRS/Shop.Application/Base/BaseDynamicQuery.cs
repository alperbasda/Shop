﻿using Core.Persistence.Dynamic;
using Core.Persistence.Requests;

namespace Shop.Application.Base;

public class BaseDynamicQuery
{
    public DynamicQuery DynamicQuery { get; set; } = new DynamicQuery();

    public PageRequest PageRequest { get; set; } = new PageRequest
    {
        PageIndex = 0,
        PageSize = int.MaxValue
    };
}
