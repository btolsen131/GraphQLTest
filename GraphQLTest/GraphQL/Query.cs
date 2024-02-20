using GraphQLTest.Data;
using GraphQLTest.Models;

namespace GraphQLTest.GraphQL{
    public class Query {

        [UseProjection]
        public IQueryable<Platform> GetPlatform([Service] AppDbContext context){
            return context.Platforms;
        }

        [UseProjection]
        public IQueryable<Command> GetCommands(AppDbContext context){
            return context.Commands;
        }
    }
}
