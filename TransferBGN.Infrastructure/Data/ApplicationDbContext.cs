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
        
        public DbSet<Currency> Currencies { get; set; }

        public DbSet<PaymentOrder> PaymentOrders { get; set; }

        public DbSet<PaymentSystem> PaymentSystems { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .Entity<PaymentOrder>()
               .HasOne(a => a.OrderingAccount)
               .WithMany(o => o.OrderingAccountPaymentOrders)
               .HasForeignKey(k => k.OrderingAccountId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<PaymentOrder>()
                .HasOne(b => b.OrderingBank)
                .WithMany(o => o.OrderingBankPaymentOrders)
                .HasForeignKey(k => k.OrderingBankId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<PaymentOrder>()
                .HasOne(h => h.OrderingAccountHolder)
                .WithMany(p => p.OrderingAccountHolderPaymentOrders)
                .HasForeignKey(k => k.OrderingAccountHolderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<PaymentOrder>()
               .HasOne(b => b.BeneficiaryBank)
               .WithMany(o => o.BeneficiaryBankPaymentOrders)
               .HasForeignKey(k => k.BeneficiaryBankId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<PaymentOrder>()
                .HasOne(a => a.BeneficiaryAccount)
                .WithMany(o => o.BeneficiaryAccountPaymentOrders)
                .HasForeignKey(k => k.BeneficiaryAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<PaymentOrder>()
                .HasOne(h => h.BeneficiaryAccountHolder)
                .WithMany(p => p.BeneficiaryAccountHolderPaymentOrders)
                .HasForeignKey(k => k.BeneficiaryAccountHolderId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .Entity<Iban>()
            //    .Property(i => i.Balance)
            //    .HasPrecision(10, 3);

            builder
                .Entity<PaymentOrder>()
                .Property(p => p.Amount)
                .HasPrecision(10, 3);

            base.OnModelCreating(builder);
        }
    }
}