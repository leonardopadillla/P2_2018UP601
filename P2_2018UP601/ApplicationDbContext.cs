using Microsoft.EntityFrameworkCore;
using P2_2018UP601.Models;

namespace P2_2018UP601
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CovidCase> CovidCases { get; set; }
    }
}
