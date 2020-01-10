using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoutineApi.Entities;

namespace RoutineApi.DbContexts
{
    public class RoutineDbContext:DbContext
    {
        public RoutineDbContext(DbContextOptions<RoutineDbContext>options):base(options)
        {
            
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Company>()
                .Property(x => x.Introduction).HasMaxLength(500);

            modelBuilder.Entity<Employee>()
                .Property(x => x.EmployeeNo).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Employee>()
                .Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>()
                .Property(x => x.LastName).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.CompanyId)//有外键
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>().HasData(
                new Company()
                {
                    Id = Guid.Parse("25bfbb47-5a04-4fc1-a773-730f57ba51b9"),
                    Name = "Microsoft",
                    Introduction = "Great Company"
                },
                new Company()
                {
                    Id = Guid.Parse("25d75050-c2cf-459e-9787-00eba6ccbd04"),
                    Name = "Google",
                    Introduction = "No Evil Company...."
                },
                new Company()
                {
                    Id = Guid.Parse("bf60c887-c2cf-4316-9787-7aba2d6e88e0"),
                    Name = "Alipapa",
                    Introduction="Fubao Company"
                }
            );
        }
    }

}
