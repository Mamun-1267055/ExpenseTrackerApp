using Microsoft.EntityFrameworkCore;

namespace Work01.Models.DAL
{
    public class ExpenseTrackDbContaxt:DbContext
    {
        public ExpenseTrackDbContaxt(DbContextOptions<ExpenseTrackDbContaxt>options):base(options)  
        {
                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
