using GraphQLTest.Data;
using GraphQLTest.Models;

namespace GraphQLTest.GraphQL.Commands{
    public class CommandType : ObjectType<Command>{
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command line action");

            descriptor
                .Field(c => c.Platform)
                .ResolveWith<Resolvers>(c => c.GetPlatform(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the platform this command is used for.");

        }

        private class Resolvers{
            public Platform GetPlatform([Parent] Command command, AppDbContext dbcontext){
                return dbcontext.Platforms.Where(p => p.Id == command.PlatformId).FirstOrDefault();
            }
        }
    }
}
