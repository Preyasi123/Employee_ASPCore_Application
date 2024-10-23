using Employee_ASPCore_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_ASPCore_Application.Controllers
{
    public class EMPAllDetailsController : Controller
    {
        EmployeeDB dbobj = new EmployeeDB();
        public IActionResult AllProfile_page()
        {
            List<Employee> getlist = dbobj.SelectDB();
            return View(getlist);
        }
        //Get action--Details get---pageload
        public IActionResult Edittab(int id)
        {
            Employee resp = dbobj.SelectProfileDB(id);
            return View(resp);
        }
        //post--edit---edit click
        public IActionResult Edittabn(Employee objcls)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = dbobj.UpdateDB(objcls);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            List<Employee> getlist = dbobj.SelectDB();
           
            return View("AllProfile_page", getlist);
        }
        public IActionResult Displaydetails(int id)
        {
            Employee resp = dbobj.SelectProfileDB(id);
            return View(resp);
        }
        public IActionResult Deletetab(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = dbobj.DeleteDB(id);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            List<Employee> getlist = dbobj.SelectDB();

            return View("AllProfile_page", getlist);
        }
    }
}