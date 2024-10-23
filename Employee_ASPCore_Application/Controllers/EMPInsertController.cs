using Employee_ASPCore_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_ASPCore_Application.Controllers
{
    public class EMPInsertController : Controller
    {
        EmployeeDB dbobj=new EmployeeDB();
        public IActionResult Insert_Load()
        {
            return View();
        }
        public IActionResult Insert_click(Employee objcls)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = dbobj.InsertDB(objcls);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            List<Employee> getlist = dbobj.SelectDB();
            return RedirectToAction("AllProfile_page", "EMPAllDetails");

          //  return View("~/Views/EMPAllDetails/AllProfile_page", getlist);
        }
    }
}
