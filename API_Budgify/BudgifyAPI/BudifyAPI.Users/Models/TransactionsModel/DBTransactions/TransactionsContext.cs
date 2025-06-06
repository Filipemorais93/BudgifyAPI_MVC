﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BudifyAPI.Users.Models.TransactionsModel.DBTransactions;

public partial class TransactionsContext : DbContext
{
    public TransactionsContext()
    {
    }

    public TransactionsContext(DbContextOptions<TransactionsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Reocurring> Reocurrings { get; set; }

    public virtual DbSet<Subcategory> Subcategories { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionGroup> TransactionGroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;UserId=postgres;Password=sasa;Database=Transactions");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Category>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("category");

            entity.Property(e => e.IdCategory)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id_category");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Reocurring>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("reocurring");

            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.DayOfWeek).HasColumnName("day_of_week");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdReocurring)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id_reocurring");
            entity.Property(e => e.IdSubcategory).HasColumnName("id_subcategory");
            entity.Property(e => e.IdWallet).HasColumnName("id_wallet");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsMonthly)
                .HasDefaultValue(false)
                .HasColumnName("is_monthly");
            entity.Property(e => e.IsWeekly)
                .HasDefaultValue(false)
                .HasColumnName("is_weekly");
            entity.Property(e => e.IsYearly)
                .HasDefaultValue(false)
                .HasColumnName("is_yearly");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
        });

        modelBuilder.Entity<Subcategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("subcategory");

            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdSubcategory)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id_subcategory");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("transactions");

            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdReocurring).HasColumnName("id_reocurring");
            entity.Property(e => e.IdSubcategory).HasColumnName("id_subcategory");
            entity.Property(e => e.IdTransaction)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id_transaction");
            entity.Property(e => e.IdTransactionGroup).HasColumnName("id_transaction_group");
            entity.Property(e => e.IdWallet).HasColumnName("id_wallet");
            entity.Property(e => e.IsPlanned)
                .HasDefaultValue(false)
                .HasColumnName("is_planned");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitue).HasColumnName("longitue");
        });

        modelBuilder.Entity<TransactionGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("transaction_group");

            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("end_date");
            entity.Property(e => e.IdTransactionGroup)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id_transaction_group");
            entity.Property(e => e.PlannedAmount).HasColumnName("planned_amount");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("start_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
