using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SnapChatUserApi.Models;

namespace SnapChatUserApi.Models;

public partial class SnapChatUserApiContext : DbContext
{
    public SnapChatUserApiContext()
    {
    }

    public SnapChatUserApiContext(DbContextOptions<SnapChatUserApiContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Segment> Segments { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Segment>(entity =>
        {
            entity.ToTable("Segment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.PhoneNo).HasMaxLength(150);
            entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

            entity.HasOne(d => d.Segment).WithMany(p => p.Users)
                .HasForeignKey(d => d.SegmentId)
                .HasConstraintName("FK_User_Segment");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<SnapChatUserApi.Models.Segment> Segment { get; set; } = default!;
}
