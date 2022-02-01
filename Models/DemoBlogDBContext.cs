using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationsDemoExperion.Models
{
    public partial class DemoBlogDBContext : DbContext
    {
        public DemoBlogDBContext()
        {
        }

        public DemoBlogDBContext(DbContextOptions<DemoBlogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Post> Post { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= BIDHUM\\SQLEXPRESS; Initial Catalog= DemoBlogDB; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Category__D830D477C888D18B");

                entity.Property(e => e.CId).HasColumnName("cId");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Slug)
                    .HasColumnName("slug")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__Post__DD36D56211E3185F");

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.Property(e => e.CId).HasColumnName("cId");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("FK__Post__cId__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
