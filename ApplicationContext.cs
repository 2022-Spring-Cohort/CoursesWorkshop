using CoursesWorkshop.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursesWorkshop
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=Courses2022; Trusted_connection=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(new Course() { Id = 1, Name = "Biochemistry", Building = "Museum", DepartmentCode = "BIOC", RoomNumber = 1234, Instructor = "Carlos Lopez" });

            builder.Entity<Course>().HasData(new Course() { Id = 2, Name = "Psychology", Building = "Empire State Building", DepartmentCode = "PSYC", RoomNumber = 205, Instructor = "Gavin Hensley" });

            builder.Entity<Course>().HasData(new Course() { Id = 3, Name = "Calculus", Building = "Sears Tower", DepartmentCode = "MATH", RoomNumber = 8745, Instructor = "Davis Murphy" });
        }
        
    }
}
