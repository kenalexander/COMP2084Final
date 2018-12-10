namespace F2018Travel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ExamModel : DbContext
    {
        public ExamModel()
            : base("name=DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false; //this is line to be added re: https://stackoverflow.com/questions/19467673/entity-framework-self-referencing-loop-detected#30203455

        }

        public virtual DbSet<Destination> Destinations { get; set; }
        public virtual DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Destination>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Destination>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Destination>()
                .Property(e => e.Photo)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.Region1)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Destinations)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);
        }
    }
}
