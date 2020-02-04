using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatMashService.DataAccess
{
    public partial class CatMashDBContext : DbContext
    {
        public CatMashDBContext()
        {
        }

        public CatMashDBContext(DbContextOptions<CatMashDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TCat> TCat { get; set; }
        public virtual DbSet<TMatch> TMatch { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TCat>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__T_Cat__6A1C8AFAA6F02431");

                entity.ToTable("T_Cat");

                entity.Property(e => e.CatUrl)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TMatch>(entity =>
            {
                entity.HasKey(e => e.MatcheId)
                    .HasName("PK__T_Match__5CD355D128FB29C1");

                entity.ToTable("T_Match");

                entity.Property(e => e.MatchResult)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.LeftCat)
                    .WithMany(p => p.TMatchLeftCat)
                    .HasForeignKey(d => d.LeftCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_LeftCatId_CatId");

                entity.HasOne(d => d.RightCat)
                    .WithMany(p => p.TMatchRightCat)
                    .HasForeignKey(d => d.RightCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_RightCatId_CatId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
