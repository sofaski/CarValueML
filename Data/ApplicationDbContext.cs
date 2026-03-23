using Microsoft.EntityFrameworkCore;
using CarValueML.Models;

namespace CarValueML.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PredictionHistory> Predictions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}