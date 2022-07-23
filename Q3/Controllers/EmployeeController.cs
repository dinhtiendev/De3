using Microsoft.AspNetCore.Mvc;
using Q3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Q3.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult List()
        {
            List<Employee> list = new List<Employee>();
            using (var context = new PE_Spr22B5Context())
            {
                list = context.Employees.ToList();
            }
            return View(list);
        }

        public IActionResult Delete(int id)
        {
            using (var context = new PE_Spr22B5Context())
            {
                Employee employee = context.Employees.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("List","Employee");
        }
    }
}
