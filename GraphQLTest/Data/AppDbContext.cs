using GraphQLTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTest.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options){

        }

        public DbSet<Platform> Platforms {get;set;}
        public DbSet<Command> Commands {get;set;}


    }
}
