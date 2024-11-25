using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BudgifyAPI.Wallet.Models.DB;

public partial class WalletContext : DbContext
{
    public WalletContext()
    {
    }

    public WalletContext(DbContextOptions<WalletContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Wallet> Wallets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;UserId=postgres;Password=sasa;Database=Wallet");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("wallet");

            entity.Property(e => e.AgreementDays).HasColumnName("agreement_days");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.IdWallet)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id_wallet");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Requisition)
                .HasMaxLength(255)
                .HasColumnName("requisition");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
