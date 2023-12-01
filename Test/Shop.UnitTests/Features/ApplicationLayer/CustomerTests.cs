using AutoFixture;
using Core.CrossCuttingConcerns.Exceptions.Types;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Shop.Application.Contracts.Repositories;
using Shop.Application.Features.Customers.Handlers.Queries.GetWithRolesById;
using Shop.Application.Features.Customers.Queries.GetWithRolesById;
using Shop.Domain.RelationalEntities;
using Shop.UnitTests.Base;
using System.Linq.Expressions;

namespace Shop.UnitTests.Features.ApplicationLayer;

public class CustomerTests : XUnitBase
{

    private readonly Mock<ICustomerDal> _dnMock;

    public CustomerTests()
    {
        _dnMock = GenerateMock<ICustomerDal>();
    }

    [Fact]
    public async Task ThrowNotFoundException_When_CustomerNull()
    {
        //Arrange
        var cancellationToken = It.IsAny<CancellationToken>();
        _dnMock
            .Setup(m => m.GetAsync(It.IsAny<Expression<Func<Customer, bool>>>(), It.IsAny<Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>>(), false, true, cancellationToken))
            .Returns(Task.FromResult<Customer?>(null))
            .Verifiable();
        var service = GenerateService<GetWithRolesByIdCustomerQueryHandler>();

        //Act
        Task act() => service.Handle(It.IsAny<GetWithRolesByIdCustomerQuery>(), cancellationToken);
        //Assert
        await Assert.ThrowsAsync<NotFoundException>(act);

    }

    [Fact]
    public async Task ReturnGetWithRolesByIdCustomerResponse_When_CustomerNotNull()
    {
        //Arrange
        var customer = new Customer();
        var cancellationToken = It.IsAny<CancellationToken>();
        _dnMock
            .Setup(m => m.GetAsync(It.IsAny<Expression<Func<Customer, bool>>>(), It.IsAny<Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>>(), false, true, cancellationToken))
            .Returns(Task.FromResult(customer)!)
            .Verifiable();
        var service = GenerateService<GetWithRolesByIdCustomerQueryHandler>();

        //Act
        var result = await service.Handle(It.IsAny<GetWithRolesByIdCustomerQuery>(), cancellationToken);
        //Assert
        Assert.NotNull(result);
    }
}
