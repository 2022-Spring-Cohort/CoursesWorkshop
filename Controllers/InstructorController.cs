using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoursesWorkshop.Controllers
{
    public class InstructorController : Controller
    {
        private ApplicationContext _context;
        public InstructorController()
        {
            _context = new ApplicationContext();
        }
        public IActionResult Index()
        {
            return View(_context.Instructors.ToList());
        }
    }
}
