using Microsoft.EntityFrameworkCore;
using GraphQLTest.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using GraphQLTest.GraphQL;
using HotChocolate.AspNetCore.Extensions;
using HotChocolate.Types;
using GraphQL.Server.Ui.Voyager;
using GraphQLTest.GraphQL.Platforms;
using GraphQLTest.GraphQL.Commands;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<AppDbContext>(opt => opt.UseSqlServer("Server=localhost,1433;Database=GraphQLTest;User Id=sa;Password=pa55w0rd!;TrustServerCertificate=True"));

//GraphQL stuff
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<PlatformType>()
    .AddType<CommandType>()
    .RegisterDbContext<AppDbContext>()
    .AddProjections();



var app = builder.Build();

//More GraphQL stuff
app.MapGraphQL();

app.UseGraphQLVoyager();

app.Run();
