using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingManagementWebApp.Models;
using System.Web.Security;


namespace BuildingManagementWebApp.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployeeLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeLogin(Employee model)
        {
            using (BuildingManagementDBEntities context = new BuildingManagementDBEntities())
            {
                bool isValidUser = context.Employees.Any(user => user.Email.ToLower() == model.Email.ToLower() && user.Password == model.Password);
                if (isValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false); 
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("", "Invalid email or password !");
                return View();
            }
        }

        public ActionResult EmployeeSignup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult employeeSignup(Employee emp)
        {
            using (BuildingManagementDBEntities context = new
            BuildingManagementDBEntities())
            {
                context.Employees.Add(emp);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult TenantLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TenantLogin(Tenant model)
        {
            using (BuildingManagementDBEntities context = new BuildingManagementDBEntities())
            {
                bool isValidUser = context.Tenants.Any(user => user.Email.ToLower() == model.Email.ToLower() && user.Password == model.Password);
                if (isValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "Tenants");
                }
                ModelState.AddModelError("", "Invalid email or password !");
                return View();
            }
        }

        public ActionResult TenantSignup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TenantSignup(Tenant tenant)
        {
            using (BuildingManagementDBEntities context = new
            BuildingManagementDBEntities())
            {
                context.Tenants.Add(tenant);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
    }
}