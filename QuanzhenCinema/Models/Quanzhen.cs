namespace QuanzhenCinema.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Quanzhen : DbContext
    {
        public Quanzhen()
            : base("name=Quanzhen4")
        {
        }

        public virtual DbSet<CATEGORY> CATEGORY { get; set; }
        public virtual DbSet<DISCOUNT> DISCOUNT { get; set; }
        public virtual DbSet<DISPLAY> DISPLAY { get; set; }
        public virtual DbSet<HALL> HALL { get; set; }
        public virtual DbSet<IMAGE> IMAGE { get; set; }
        public virtual DbSet<MEMBER> MEMBER { get; set; }
        public virtual DbSet<MOVIE> MOVIE { get; set; }
        public virtual DbSet<MYORDER> MYORDER { get; set; }
        public virtual DbSet<SCHEDULE> SCHEDULE { get; set; }
        public virtual DbSet<SEAT> SEAT { get; set; }
        public virtual DbSet<SNACK> SNACK { get; set; }
        public virtual DbSet<STAFF> STAFF { get; set; }
        public virtual DbSet<TICKET> TICKET { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORY>()
                .HasMany(e => e.MOVIE)
                .WithMany(e => e.CATEGORY)
                .Map(m => m.ToTable("CATEGORY_MOVIE", "CINEMA_EDITOR").MapLeftKey("CATEGORY_ID").MapRightKey("MOVIE_ID"));

            modelBuilder.Entity<DISCOUNT>()
                .Property(e => e.RATE)
                .HasPrecision(12, 2);

            modelBuilder.Entity<DISCOUNT>()
                .HasMany(e => e.DISPLAY)
                .WithMany(e => e.DISCOUNT)
                .Map(m => m.ToTable("DISCOUNT_DISPLAY", "CINEMA_EDITOR").MapLeftKey("DISCOUNT_ID").MapRightKey("DISPLAY_ID"));

            modelBuilder.Entity<DISPLAY>()
                .HasMany(e => e.SCHEDULE)
                .WithRequired(e => e.DISPLAY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HALL>()
                .HasMany(e => e.SCHEDULE)
                .WithRequired(e => e.HALL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HALL>()
                .HasMany(e => e.SEAT)
                .WithRequired(e => e.HALL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IMAGE>()
                .Property(e => e.IMAGE_PATH)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBER>()
                .Property(e => e.PHONE_NUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIE>()
                .HasMany(e => e.DISPLAY)
                .WithRequired(e => e.MOVIE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MOVIE>()
                .HasMany(e => e.IMAGE)
                .WithRequired(e => e.MOVIE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MYORDER>()
                .HasMany(e => e.TICKET)
                .WithRequired(e => e.MYORDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MYORDER>()
                .HasMany(e => e.SNACK)
                .WithMany(e => e.MYORDER)
                .Map(m => m.ToTable("MYORDER_SNACK", "CINEMA_EDITOR").MapLeftKey("ORDER_ID").MapRightKey("SNACK_ID"));

            modelBuilder.Entity<SCHEDULE>()
                .HasMany(e => e.TICKET)
                .WithRequired(e => e.SCHEDULE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SEAT>()
                .HasMany(e => e.TICKET)
                .WithRequired(e => e.SEAT)
                .HasForeignKey(e => new { e.SEAT_COLUMN_ID, e.SEAT_ROW_ID, e.SEAT_HALL_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.ROLE)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.MYORDER)
                .WithOptional(e => e.STAFF)
                .HasForeignKey(e => e.OPERATOR_ID);
        }
    }
}
