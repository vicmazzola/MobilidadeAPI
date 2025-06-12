using Microsoft.EntityFrameworkCore;
using MobilidadeAPI.Models;
using System.Collections.Generic;

namespace MobilidadeAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Transport> Transports { get; set; }  // Set for Transports model
    }
}
