using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_Details.Models;
namespace Employee_Details.Controllers
{
    public class HomeController : Controller
    {
        Employee_dbEntities db = new Employee_dbEntities();
        public ActionResult Index()
        {
            var emp = (from x in db.employee_details select x).ToList();                   
            return View(emp);
        }
        [HttpPost]
        public ActionResult Save(IEnumerable<employee_details> empObject)
        {
            try
            {
                foreach(var item in empObject)
                {
                    if(item.pkid == 0)
                    {
                        employee_details newEntry = new employee_details();
                        newEntry.name = item.name;
                        newEntry.salary = item.salary;
                        newEntry.designation = item.designation;
                        newEntry.yearofexp = item.yearofexp;
                        newEntry.joineddate = !string.IsNullOrEmpty(item.joineddate.ToString()) ? Convert.ToDateTime(item.joineddate.ToString()) : (DateTime?)null;
                        db.employee_details.Add(newEntry);
                        db.SaveChanges();
                    }
                    else
                    {
                        employee_details updateEntry = db.employee_details.Where(x=>x.pkid == item.pkid).FirstOrDefault();
                        updateEntry.name = item.name;
                        updateEntry.salary = item.salary;
                        updateEntry.designation = item.designation;
                        updateEntry.yearofexp = item.yearofexp;
                        updateEntry.joineddate = !string.IsNullOrEmpty(item.joineddate.ToString()) ? Convert.ToDateTime(item.joineddate.ToString()) : (DateTime?)null;
                        db.SaveChanges();
                    }
                }
            }
            catch(Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int pkid)
        {
            try
            {
                employee_details delEntry = db.employee_details.Where(x=>x.pkid == pkid).FirstOrDefault();
                if (delEntry != null)
                {
                    db.employee_details.Remove(delEntry);
                    db.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}