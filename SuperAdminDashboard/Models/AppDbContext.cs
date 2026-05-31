namespace SuperAdminDashboard.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Tenants> Tenants { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    public DbSet<Apartment> Apartment { get; set; }
    public DbSet<Wallet> Wallet { get; set; }
}

