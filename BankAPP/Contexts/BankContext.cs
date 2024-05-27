using BankAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAPP.Contexts
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        


    }
}
