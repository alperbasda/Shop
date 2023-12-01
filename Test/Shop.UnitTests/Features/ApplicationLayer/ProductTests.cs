using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Shop.Application.Contracts.Repositories;
using Shop.Application.Features.Products.Handlers.Queries.ListByIds;
using Shop.Application.Features.Products.Queries.ListByIds;
using Shop.Domain.RelationalEntities;
using Shop.UnitTests.Base;
using System.Linq.Expressions;

namespace Shop.UnitTests.Features.ApplicationLayer;

public class ProductTests : XUnitBase
{

    private readonly Mock<IProductDal> _dnMock;

    public ProductTests()
    {
        _dnMock = GenerateMock<IProductDal>();
    }

    [Fact]
    public async Task ThrowNotFoundException_When_ListEmpty()
    {
        //Arrange
        var cancellationToken = It.IsAny<CancellationToken>();
        _dnMock
            .Setup(m => m.GetListAsync(It.IsAny<Expression<Func<Product, bool>>>(), null,null,0,10, false, true, cancellationToken))
            .Returns(Task.FromResult<Paginate<Product>>(null))
            .Verifiable();
        var service = GenerateService<ListByIdsProductQueryHandler>();

        //Act
        Task act() => service.Handle(It.IsAny<ListByIdsProductQuery>(), cancellationToken);
        //Assert
        await Assert.ThrowsAsync<NotFoundException>(act);

    }

    [Fact]
    public async Task ReturnListByIdsProductResponse_When_ProductsNotNull()
    {
        //Arrange
        var product = new Paginate<Product>();
        var cancellationToken = It.IsAny<CancellationToken>();
        _dnMock
            .Setup(m => m.GetListAsync(It.IsAny<Expression<Func<Product, bool>>>(), null, null, 0, 10, false, true, cancellationToken))
            .Returns(Task.FromResult(product)!)
            .Verifiable();
        var service = GenerateService<ListByIdsProductQueryHandler>();

        //Act
        var result = await service.Handle(It.IsAny<ListByIdsProductQuery>(), cancellationToken);
        //Assert
        Assert.NotNull(result);
    }
}
