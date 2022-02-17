using Microsoft.AspNetCore.Identity;

namespace CoursesWorkshop.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentCode { get; set; }
    }
}
