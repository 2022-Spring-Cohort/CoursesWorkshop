﻿namespace CoursesWorkshop.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DepartmentCode { get; set; }
        public string Instructor { get; set; }
        public string Building { get; set; }
        public int RoomNumber { get; set; }
    }
}
