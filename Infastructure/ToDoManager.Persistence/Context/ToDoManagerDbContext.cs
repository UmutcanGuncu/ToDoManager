using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Persistence.Context;

public class ToDoManagerDbContext : IdentityDbContext<AppUser,AppRole,int>
{
    public ToDoManagerDbContext(DbContextOptions options): base(options)
    {
        
    }
    public DbSet<Checkpoint> Checkpoints { get; set; }
    public DbSet<Server> Servers { get; set; }
}