using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.Mvc;
using StudentMangementSystem.Models;

namespace StudentMangementSystem.Controllers
{

    
    public class LoginController : Controller
    {
        private DataManger db = new DataManger();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Table table)
        {
            if (ModelState.IsValid)
            {
                var obj = db.Tables.Where(x => x.email.Equals(table.email) && x.password.Equals(table.password)).FirstOrDefault();
                if (obj != null)
                {
                    FormsAuthentication.SetAuthCookie(obj.email, false);
                    Session["email"] = obj.email.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid credential");
                }
            }
            return View();
        }

            public ActionResult Logout()
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                return View("Index");
            }
    }
}