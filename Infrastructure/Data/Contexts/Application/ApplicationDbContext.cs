using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.Entities.Application;

namespace Infrastructure.Data.Contexts.Application
{
    public class ApplicationDbContext : DbContext
    {
        #region Ctor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        #endregion

        #region DbSet
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }  
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        #endregion

        #region Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relations
            #region CustomerReceipt
            modelBuilder.Entity<Customer>()
                .HasMany(customer => customer.Receipts)
                .WithOne(recipt => recipt.Customer)
                .HasForeignKey(receipt => receipt.CustomerId);
            #endregion

            #region PaymentReceipt
            modelBuilder.Entity<Payment>()
                .HasOne(payment => payment.Receipt)
                .WithMany(receipt => receipt.Payments)
                .HasForeignKey(payment => payment.ReceiptId);
            #endregion

            #region ItemReceipt
            modelBuilder.Entity<Item>()
                .HasMany(item => item.Receipts)
                .WithMany(receipt => receipt.Items)
                .UsingEntity(junction=> junction.ToTable("ItemReceipt"));
            #endregion

            #region CategoryItem
            modelBuilder.Entity<Category>()
                .HasMany(Category => Category.Items)
                .WithOne(item => item.Category)
                .HasForeignKey(item => item.CategoryId);
            #endregion

        }   
        #endregion
    }
}
