using studentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace studentManagementSystem.Controllers
{
    public class loginController : Controller
    {
        regisEntities db = new regisEntities();
        // GET: login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(user objchk)
        {
            if (ModelState.IsValid)
            {
                using (regisEntities db = new regisEntities())
                {

                    var obj = db.users.Where(a => a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["userid"] = obj.id.ToString();
                        Session["username"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ModelState.AddModelError("","The username or password Incorrect");
                    }
                }

            }
           
            return View(objchk);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","login");
        }
    }
}