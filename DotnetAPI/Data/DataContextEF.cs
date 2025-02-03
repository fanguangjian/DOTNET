
using System.Reflection.Emit;
using DotnetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPI.Data
{
    public class DataContextEF : DbContext 
    {
        private readonly IConfiguration _config;
        public DataContextEF(IConfiguration config) 
        {
            _config = config;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSalary> UserSalary { get; set; }
        public virtual DbSet<UserJobInfo> UserJobInfo { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                // dotnet add package Microsoft.EntityFrameworkCore.SqlServer

                optionsBuilder.UseSqlServer(
                    _config.GetConnectionString("DefaultConnectionString"),
                    optionsBuilder => optionsBuilder.EnableRetryOnFailure()
                
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            // dotnet add package Microsoft.EntityFrameworkCore.Relational            
            modelBuilder.HasDefaultSchema("TutorialAppSchema");

            modelBuilder.Entity<User>()
                .ToTable("Users", "TutorialAppSchema")
                .HasKey(e => e.UserId);

            modelBuilder.Entity<UserSalary>()            
                .HasKey(e => e.UserId);

            modelBuilder.Entity<UserJobInfo>()               
                .HasKey(e => e.UserId);

        }

        internal int SavedChanges()
        {
            throw new NotImplementedException();
        }

        public static implicit operator DataContextEF(DataContextDapper v)
        {
            throw new NotImplementedException();
        }
    }
}