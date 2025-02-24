using ZK___Walker_Advertising.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ZK___Walker_Advertising.Data;

public class LeadContext : DbContext
{
    public LeadContext(DbContextOptions<LeadContext> options)
        : base(options)
    {
    }

    public DbSet<LeadModel> Leads { get; set; } = null!;
}