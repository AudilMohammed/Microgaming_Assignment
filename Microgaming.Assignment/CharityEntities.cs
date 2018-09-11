namespace Microgaming.Assignment
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CharityEntities : DbContext
    {
        public CharityEntities()
            : base("name=CharityEntities")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<CharityRecord> CharityRecords { get; set; }
        public virtual DbSet<FileDetail> FileDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasOptional(e => e.AspNetUsers1)
                .WithRequired(e => e.AspNetUser1);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.CharityRecords)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CharityRecord>()
                .HasMany(e => e.FileDetails)
                .WithRequired(e => e.CharityRecord)
                .HasForeignKey(e => e.CharityId)
                .WillCascadeOnDelete(false);
        }
    }
}
