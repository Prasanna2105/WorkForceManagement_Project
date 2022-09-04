using Microsoft.EntityFrameworkCore;
using WorkForceManagement.Domain;

namespace WorkForceManagement.Web.Models
{
    public class WFMDbContext:DbContext
    {
        #region Constructor
        public WFMDbContext(DbContextOptions options) : base(options)
        {



        }
        #endregion

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Softlock> Softlocks { get; set; }
        public DbSet<Skillmap> Skillmaps { get; set; }



        #region Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureModels(modelBuilder);
        }

        private static void ConfigureModels(ModelBuilder modelBuilder)
        {
            #region Entity: Profile
            modelBuilder.Entity<Profile>().ToTable("Profiles");
            modelBuilder.Entity<Profile>().Property(x => x.profile_name).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            #endregion



            #region Entity: Skills
            modelBuilder.Entity<Skills>().ToTable("Skills");
            modelBuilder.Entity<Skills>().Property(x => x.skillname).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            #endregion



            #region Entity: Employees
            modelBuilder.Entity<Employees>().ToTable("Employees");
            modelBuilder.Entity<Employees>().Property(x => x.employee_name).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.status).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.manager).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.wfm_manager).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.email).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.lockstatus).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.experience).HasColumnType("decimal(5,0)");
            modelBuilder.Entity<Employees>().HasOne(a => a.profile).WithMany(b => b.employees).HasForeignKey(c => c.profile_id);
            #endregion



            #region Entity: Users
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Users>().Property(x => x.username).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Users>().Property(x => x.password).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Users>().Property(x => x.name).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Users>().Property(x => x.role).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Users>().Property(x => x.email).HasColumnType("varchar");
            #endregion



            #region Entity: Softlock
            modelBuilder.Entity<Softlock>().ToTable("Softlock");
            modelBuilder.Entity<Softlock>().Property(x => x.manager).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Softlock>().Property(x => x.reqdate).HasColumnType("datetime");
            modelBuilder.Entity<Softlock>().Property(x => x.status).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Softlock>().Property(x => x.lastupdated).HasColumnType("datetime");
            modelBuilder.Entity<Softlock>().Property(x => x.requestmessage).HasColumnType("varchar");
            modelBuilder.Entity<Softlock>().Property(x => x.wfmremark).HasColumnType("varchar");
            modelBuilder.Entity<Softlock>().Property(x => x.managerstatus).HasMaxLength(30).HasColumnType("varchar").HasDefaultValue("awaiting_approval");
            modelBuilder.Entity<Softlock>().Property(x => x.mgrstatuscomment).HasColumnType("varchar");
            modelBuilder.Entity<Softlock>().Property(x => x.mgrlastupdate).HasColumnType("datetime");
            modelBuilder.Entity<Softlock>().HasOne(a => a.employees).WithMany(b => b.softlocks).HasForeignKey(c => c.employee_id);

            #endregion


            #region Entity: Skillmap
            modelBuilder.Entity<Skillmap>().ToTable("Skillmap");
            modelBuilder.Entity<Skillmap>().HasKey(c => new { c.employee_id, c.skillid });
            modelBuilder.Entity<Skillmap>().HasOne(a => a.employees).WithMany(b => b.skillmaps).HasForeignKey(c => c.employee_id);
            modelBuilder.Entity<Skillmap>().HasOne(a => a.skills).WithMany(b => b.skillmaps).HasForeignKey(c => c.skillid);
            #endregion
        }
        #endregion Configuration
    }
}
