using Core.Application.Pipelines.Caching;
using Core.Persistence.Models.Responses;
using MediatR;
using Newtonsoft.Json;
using Shop.Application.Base;

namespace Shop.Application.Features.Discounts.Queries.ListDynamic;

public class ListDynamicDiscountQuery : BaseDynamicQuery, IRequest<ListModel<ListDynamicDiscountResponse>>, ICachableRequest
{
    public string CacheKey => $"Discounts_{JsonConvert.SerializeObject(this.DynamicQuery)}_{JsonConvert.SerializeObject(this.PageRequest)}";

    public bool BypassCache => false;

    public string? CacheGroupKey => "";

    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(30);
}
