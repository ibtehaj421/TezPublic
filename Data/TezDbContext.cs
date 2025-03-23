using Microsoft.EntityFrameworkCore;
using TEZ.Models;


namespace TEZ.DbContext 
{
    public class TezDbContext : Microsoft.EntityFrameworkCore.DbContext {
        public TezDbContext(DbContextOptions<TezDbContext> options) : base(options) {}

        //DbSets for Users
        public DbSet<UserBase> UserBases { get; set; }  // Optional (abstract, no table)
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Driver> Drivers { get; set; }


        //Organizations
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<CorpAdmin> CorpAdmins { get; set; }
        public DbSet<EduAdmin> EduAdmins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =============================
            // USER HIERARCHY CONFIGURATION
            // =============================
            
            // Map UserBase hierarchy with TPT
            modelBuilder.Entity<UserBase>()
                .UseTptMappingStrategy();

            modelBuilder.Entity<UserBase>()
                .Property(u => u.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<UserBase>()
                .Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<UserBase>()
                .Property(u => u.Password)
                .IsRequired();

            // Individual user entities configuration

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Pass)
                      .HasColumnName("Pass")
                      .HasMaxLength(30);
                
                entity.Property(u => u.Role)
                      .HasConversion<string>();
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(a => a.AdminId)
                      .HasColumnName("AdminId")
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(a => a.OrgId)
                      .HasColumnName("OrgId")
                      .IsRequired();
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(d => d.Level)
                      .HasColumnName("Level")
                      .IsRequired();

                entity.Property(d => d.OrgId)
                      .HasColumnName("OrgId");
            });


            // =============================
            // ORGANIZATION HIERARCHY CONFIGURATION
            // =============================

            modelBuilder.Entity<Organization>()
                .ToTable("Organizations")
                .HasDiscriminator<string>("Role")
                .HasValue<CorpAdmin>("CORP_ADMIN")
                .HasValue<EduAdmin>("EDU_ADMIN");

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.Property(o => o.Name)
                      .HasMaxLength(50)
                      .IsRequired();
                      
                entity.Property(o => o.Password)
                      .IsRequired();
            });

            modelBuilder.Entity<CorpAdmin>(entity =>
            {
                entity.Property(c => c.Company)
                    .HasMaxLength(50)
                    .HasColumnName("Company")
                    .IsRequired(false);  
            });

            modelBuilder.Entity<EduAdmin>(entity =>
            {
                entity.Property(e => e.Institute)
                    .HasMaxLength(50)
                    .HasColumnName("Institute")
                    .IsRequired(false);
            });
        }
    }
}