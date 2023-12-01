﻿using Microsoft.Data.SqlClient;
using MongoDB.Driver;
using Shop.UnitTests.Base;

namespace Shop.UnitTests.Features.Connections;

public class ConnectionTest : XUnitBase
{
    public ConnectionTest()
    {
        
    }
    [Fact]
    public async Task MsSqlConnection_Alive()
    {
        //Arrange
        var connection = new SqlConnection(base.Configuration["DatabaseOptions:EfConnectionString"]);

        //Act
        await connection.OpenAsync();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT 1";

        var result = await command.ExecuteScalarAsync();

        //Assert
        Assert.Equal(1, result);

        await connection.DisposeAsync();
    }

    [Fact]
    public async Task MongoConnection_Alive()
    {
        //Arrange
        var client = new MongoClient(base.Configuration["DatabaseOptions:MongoConnectionString"]);

        //Act
        var db = client.GetDatabase(base.Configuration["DatabaseOptions:DatabaseName"]);

        //Assert
        Assert.NotNull(db);

    }
}
