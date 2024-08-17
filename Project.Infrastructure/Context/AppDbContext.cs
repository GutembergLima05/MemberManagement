using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Infrastructure.EntityConfiguration;

namespace Project.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new MemberConfiguration());
    }
}
