using GraphQLTest.Data;
using GraphQLTest.Models;

namespace GraphQLTest.GraphQL{
    public class Query {


        public IQueryable<Platform> GetPlatform( AppDbContext context){
            return context.Platforms;
        }

        public IQueryable<Command> GetCommands(AppDbContext context){
            return context.Commands;
        }
    }
}
