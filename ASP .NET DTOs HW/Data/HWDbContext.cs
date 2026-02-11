using Microsoft.EntityFrameworkCore;
using ASP_.NET_DTOs_HW.Models;

namespace ASP_.NET_DTOs_HW.Data;

public class HWDbContext : DbContext
{
    public HWDbContext(DbContextOptions options) 
        : base(options)
    {}

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceRow> InvoiceRows => Set<InvoiceRow>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(
            customer =>
            {
                customer.HasKey(e => e.Id);
                customer.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
                customer.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);
                customer.Property(e => e.Address)
                .HasMaxLength(500);
                customer.Property(e => e.PhoneNumber)
                .HasMaxLength(20);
                customer.Property(e => e.CreatedAt)
                .IsRequired();
            }
            );

        modelBuilder.Entity<Invoice>(
            invoice =>
            {
                invoice.HasKey(e => e.Id);
                invoice.Property(e => e.CustomerId)
                .IsRequired();
                invoice.Property(e => e.StartDate)
                .IsRequired();
                invoice.Property(e => e.EndDate)
                .IsRequired();
                invoice.Property(e => e.TotalSum)
                .IsRequired()
                .HasPrecision(18, 2);
                invoice.Property(e => e.Status)
                .IsRequired();
                invoice.Property(e => e.CreatedAt)
                .IsRequired();

                invoice.HasMany(i => i.InvoiceRows)
                .WithOne(r => r.Invoice)     
                .HasForeignKey(r => r.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);


                });
        modelBuilder.Entity<InvoiceRow>(
            row =>
            {
                row.HasKey(r => r.Id);
                row.Property(r => r.Service)
                       .IsRequired()
                       .HasMaxLength(200);
                row.Property(r => r.Quantity)
                       .IsRequired()
                       .HasPrecision(18, 2);
                row.Property(r => r.Amount)
                       .IsRequired()
                       .HasPrecision(18, 2);
                row.Property(r => r.Sum)
                        .IsRequired()
                        .HasPrecision(18, 2);

            }
        );
    }
}
