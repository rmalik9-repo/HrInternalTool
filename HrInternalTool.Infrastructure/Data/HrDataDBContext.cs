using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrInternalTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HrInternalTool.Infrastructure.Data
{
    public class HrDataDBContext : DbContext
    {
        public HrDataDBContext(DbContextOptions<HrDataDBContext> options)
            : base(options)
        {
        }
        public DbSet<EmployeesEntity> Employees => Set<EmployeesEntity>();
        public DbSet<PerformanceReviewsEntity> PerformanceReviews => Set<PerformanceReviewsEntity>();
        public DbSet<UsersEntity> Users => Set<UsersEntity>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeesEntity>().HasData(
                new EmployeesEntity
                {
                    Id = 1,
                    Name = "John",
                    Email = "John@abc.com",
                    Department = "IT",
                    DateOfJoining = new DateTime(2022, 12, 30),
                    IsActive = true
                },
                new EmployeesEntity
                {
                    Id = 2,
                    Name = "Chris",
                    Email = "Chris@abc.com",
                    Department = "HR",
                    DateOfJoining = new DateTime(2022, 12, 30),
                    IsActive = true
                },
                new EmployeesEntity
                {
                    Id = 3,
                    Name = "Albert",
                    Email = "Albert@abc.com",
                    Department = "IT",
                    DateOfJoining = new DateTime(2024, 12, 20),
                    IsActive = true
                });
            modelBuilder.Entity<PerformanceReviewsEntity>().HasData(
                new PerformanceReviewsEntity
                {
                    Id = 1,
                    EmployeeId = 1,
                    Reviewer = "John",
                    ReviewDate = new DateTime(2025, 01, 30),
                    Score = 2.5,
                    Comments = "Great work"
                },
                new PerformanceReviewsEntity
                {
                    Id = 2,
                    EmployeeId = 1,
                    Reviewer = "John",
                    ReviewDate = new DateTime(2025, 02, 25),
                    Score = 4,
                    Comments = "Great work"
                },
                new PerformanceReviewsEntity
                {
                    Id = 3,
                    EmployeeId = 2,
                    Reviewer = "Steph",
                    ReviewDate = new DateTime(2025, 01, 30),
                    Score = 2.5,
                    Comments = "Great work"
                },
                new PerformanceReviewsEntity
                {
                    Id = 4,
                    EmployeeId = 2,
                    Reviewer = "Steph",
                    ReviewDate = new DateTime(2025, 01, 30),
                    Score = 3,
                    Comments = "Great work"
                });
        }
    }
}
