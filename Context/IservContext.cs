using System;
using System.Collections.Generic;
using ISERV_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ISERV_API.Context;

public partial class IservContext : DbContext
{
    public IservContext()
    {
    }

    public IservContext(DbContextOptions<IservContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EducationalInstitution> EducationalInstitutions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=ISERV;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EducationalInstitution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Employees");

            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
