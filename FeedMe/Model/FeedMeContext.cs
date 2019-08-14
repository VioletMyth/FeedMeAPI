using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FeedMe.Model
{
    public partial class FeedMeContext : DbContext
    {
        public FeedMeContext()
        {
        }

        public FeedMeContext(DbContextOptions<FeedMeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Detail> Detail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:feedme-msaphase2.database.windows.net,1433;Initial Catalog=FeedMeDetailDatabase;Persist Security Info=False;User ID=VioletMyth;Password=Password3625;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Restraunt).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });
        }
    }
}
