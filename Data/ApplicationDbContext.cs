using Microsoft.EntityFrameworkCore;
using HopNExplore.Models;


namespace HopNExplore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TourPackage> TourPackages { get; set; }
    }
}