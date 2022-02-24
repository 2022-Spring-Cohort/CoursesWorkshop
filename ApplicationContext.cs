﻿using CoursesWorkshop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoursesWorkshop
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<CourseStudent> CourseStudents { get; set; }

        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=Courses2022; Trusted_connection=True");
                builder.UseLazyLoadingProxies();
            }
            
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Instructor>().HasData(new Instructor() { Id = 1, FirstName = "Carlos", LastName = "Lopez", Department = "BIOC", Email = "blah@blah.gov" });
            builder.Entity<Instructor>().HasData(new Instructor() { Id = 2, FirstName = "Gavin", LastName = "Hensley", Department = "PSYC", Email = "gav@blah.gov" });
            builder.Entity<Instructor>().HasData(new Instructor() { Id = 3, FirstName = "Davis", LastName = "Murphy", Department = "MATH", Email = "great@blah.gov" });
            
            builder.Entity<Course>().HasData(new Course() { Id = 1, Name = "Biochemistry", Building = "Museum", DepartmentCode = "BIOC", RoomNumber = 1234, InstructorId = 1 });
            builder.Entity<Course>().HasData(new Course() { Id = 2, Name = "Psychology", Building = "Empire State Building", DepartmentCode = "PSYC", RoomNumber = 205, InstructorId = 2 });
            builder.Entity<Course>().HasData(new Course() { Id = 3, Name = "Calculus", Building = "Sears Tower", DepartmentCode = "MATH", RoomNumber = 8745, InstructorId = 3 });

            builder.Entity<Student>().HasData(new Student() { Id = 1, FirstName = "Darius", LastName = "Hammond", Email = "darius@blah.gov", AcademicStanding = "5th Year" });
            builder.Entity<Student>().HasData(new Student() { Id = 2, FirstName = "Rimma", LastName = "Girsheva", Email = "rimma@blah.gov", AcademicStanding = "Senior" });

            base.OnModelCreating(builder);
        }
        
    }
}
