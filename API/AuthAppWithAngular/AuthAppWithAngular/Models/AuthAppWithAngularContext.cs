using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AuthAppWithAngular.Models;

public partial class AuthAppWithAngularContext : DbContext
{
    public AuthAppWithAngularContext()
    {
    }

    public AuthAppWithAngularContext(DbContextOptions<AuthAppWithAngularContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserRegister> UserRegisters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    { 
    
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=192.168.1.117,1580;Database=authAppWithAngular;User Id=sa;Password=sit@123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRegister>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__UserRegi__1797D0240765743C");

            entity.ToTable("UserRegister");

            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
