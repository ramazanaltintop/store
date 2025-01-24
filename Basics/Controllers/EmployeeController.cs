using Basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index1()
        {
            string message = $"Hello World. {DateTime.Now.ToString()}";
            return View("Index1", message);
        }
        public ViewResult Index2()
        {
            var cities = new String[]
            {
                "Ankara",
                "Bursa",
                "Nevsehir"
            };
            return View(cities);
        }
        public IActionResult Index3()
        {
            var list = new List<Employee>()
            {
                new Employee{Id = 1, FirstName = "Kadir", LastName = "XYZ", Age = 25},
                new Employee{Id = 2, FirstName = "Ahmet", LastName = "KLM", Age = 35},
                new Employee{Id = 3, FirstName = "Test", LastName = "JKL", Age = 30}
            };
            return View("Index3", list);
        }
    }
}