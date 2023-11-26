using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RentingMovies.Models.DBObjects;

namespace RentingMovies.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
       // public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Renting> Rentings { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Name=DefaultConnection");
        //    }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<AspNetRole>(entity =>
        //    //{
        //    //    entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
        //    //        .IsUnique()
        //    //        .HasFilter("([NormalizedName] IS NOT NULL)");

        //    //    entity.Property(e => e.Name).HasMaxLength(256);

        //    //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
        //    //});

        //    //modelBuilder.Entity<AspNetRoleClaim>(entity =>
        //    //{
        //    //    entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

        //    //    entity.HasOne(d => d.Role)
        //    //        .WithMany(p => p.AspNetRoleClaims)
        //    //        .HasForeignKey(d => d.RoleId);
        //    //});

        //    //modelBuilder.Entity<AspNetUser>(entity =>
        //    //{
        //    //    entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

        //    //    entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
        //    //        .IsUnique()
        //    //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

        //    //    entity.Property(e => e.Email).HasMaxLength(256);

        //    //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

        //    //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

        //    //    entity.Property(e => e.UserName).HasMaxLength(256);

        //    //    entity.HasMany(d => d.Roles)
        //    //        .WithMany(p => p.Users)
        //    //        .UsingEntity<Dictionary<string, object>>(
        //    //            "AspNetUserRole",
        //    //            l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
        //    //            r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
        //    //            j =>
        //    //            {
        //    //                j.HasKey("UserId", "RoleId");

        //    //                j.ToTable("AspNetUserRoles");

        //    //                j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
        //    //            });
        //    //});

        //    //modelBuilder.Entity<AspNetUserClaim>(entity =>
        //    //{
        //    //    entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

        //    //    entity.HasOne(d => d.User)
        //    //        .WithMany(p => p.AspNetUserClaims)
        //    //        .HasForeignKey(d => d.UserId);
        //    //});

        //    //modelBuilder.Entity<AspNetUserLogin>(entity =>
        //    //{
        //    //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

        //    //    entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

        //    //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

        //    //    entity.Property(e => e.ProviderKey).HasMaxLength(128);

        //    //    entity.HasOne(d => d.User)
        //    //        .WithMany(p => p.AspNetUserLogins)
        //    //        .HasForeignKey(d => d.UserId);
        //    //});

        //    //modelBuilder.Entity<AspNetUserToken>(entity =>
        //    //{
        //    //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

        //    //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

        //    //    entity.Property(e => e.Name).HasMaxLength(128);

        //    //    entity.HasOne(d => d.User)
        //    //        .WithMany(p => p.AspNetUserTokens)
        //    //        .HasForeignKey(d => d.UserId);
        //    //});

        //    modelBuilder.Entity<Client>(entity =>
        //    {
        //        entity.HasKey(e => e.IdClient)
        //            .HasName("PK__Clients__C1961B3358C5169C");

        //        entity.Property(e => e.IdClient).ValueGeneratedNever();

        //        entity.Property(e => e.Email)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Name)
        //            .HasMaxLength(500)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Phone)
        //            .HasMaxLength(20)
        //            .IsUnicode(false);
        //    });

        //    modelBuilder.Entity<Movie>(entity =>
        //    {
        //        entity.HasKey(e => e.IdMovie)
        //            .HasName("PK__Movies__DC0DD0ED84A33D3A");

        //        entity.Property(e => e.IdMovie).ValueGeneratedNever();

        //        entity.Property(e => e.Date).HasColumnType("date");

        //        entity.Property(e => e.Name)
        //            .HasMaxLength(500)
        //            .IsUnicode(false);
        //    });

        //    modelBuilder.Entity<Renting>(entity =>
        //    {
        //        entity.HasKey(e => e.IdRenting)
        //            .HasName("PK__Rentings__9F8BD921A58D082E");

        //        entity.Property(e => e.IdRenting).ValueGeneratedNever();

        //        entity.Property(e => e.EndDate).HasColumnType("datetime");

        //        entity.Property(e => e.StartDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.IdClientNavigation)
        //            .WithMany(p => p.Rentings)
        //            .HasForeignKey(d => d.IdClient)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Rentings_Clients");

        //        entity.HasOne(d => d.IdMovieNavigation)
        //            .WithMany(p => p.Rentings)
        //            .HasForeignKey(d => d.IdMovie)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Rentings_Movies");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
