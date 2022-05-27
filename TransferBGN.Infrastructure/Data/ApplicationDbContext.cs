namespace TransferBGN.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TransferBGN.Infrastructure.Data.Models;

    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<AccountHolder> AccountHolders { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<FeeType> FeeTypes { get; set; }

        public DbSet<Iban> Ibans { get; set; }

        public DbSet<PaymentOrder> PaymentOrders { get; set; }

        public DbSet<PaymentSystem> PaymentSystems { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


    }
}