using Microsoft.EntityFrameworkCore;
using PersonService.Models;

namespace PersonService.DbContexts;

public class PostgresContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    
    public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }
}