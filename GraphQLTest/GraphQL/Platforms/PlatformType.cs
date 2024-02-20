using HotChocolate.Types;
using GraphQLTest.Models;
using GraphQLTest.Data;
using System.Linq;

namespace GraphQLTest.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {

        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software that has a CLI.");
            descriptor
                .Field(p => p.LicenseKey).Ignore();

            descriptor
                .Field(p => p.Commands)
                .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("List of available commands for this platform");
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands([Parent] Platform platform, AppDbContext dbContext)
            {
                Console.WriteLine($"HERE {platform.Name}");
                return dbContext.Commands.Where(c => c.PlatformId == platform.Id);
            }
        }

    }
}
