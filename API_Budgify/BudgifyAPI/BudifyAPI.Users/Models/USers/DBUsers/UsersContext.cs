﻿
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BudifyAPI.Users.Models.USers.DBUsers;

public partial class UsersContext : DbContext
{
    public UsersContext()
    {
    }

    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserGroup> UserGroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;UserId=postgres;Password=sasa;Database=Users");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("user_pkey");

            entity.ToTable("user");

            entity.Property(e => e.IdUser)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id_user");
            entity.Property(e => e.AllowWalletWatch)
                .HasDefaultValue(true)
                .HasColumnName("allow_wallet_watch");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Genre).HasColumnName("genre");
            entity.Property(e => e.IdUserGroup).HasColumnName("id_user_group");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsAdmin)
                .HasDefaultValue(false)
                .HasColumnName("is_admin");
            entity.Property(e => e.IsManager)
                .HasDefaultValue(false)
                .HasColumnName("is_manager");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");

            entity.HasOne(d => d.IdUserGroupNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdUserGroup)
                .HasConstraintName("FK");
        });

        modelBuilder.Entity<UserGroup>(entity =>
        {
            entity.HasKey(e => e.IdUserGroup).HasName("user_group_pkey");

            entity.ToTable("user_group");

            entity.Property(e => e.IdUserGroup)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id_user_group");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
