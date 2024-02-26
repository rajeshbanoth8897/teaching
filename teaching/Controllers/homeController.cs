using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using teaching.Models;

namespace teaching.Controllers
{
    public class homeController : Controller
    {
        teachingEntities1 dc = new teachingEntities1();
        // GET: home
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult teacherlogin(string Username, string Password)
        {

            if (Username == "rajesh" && Password == "india")
            {
                return RedirectToAction("Index");
            }
            else 
                return View();
        }
        public ActionResult teacherlogin()
        {

            return View();
        }
        public ActionResult studentregi()
        {
            return View();
        }

        public ActionResult studentlgn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult studentlgn(studentlgn ob)
        {
            //dc.studentlgns.Add(ob);
            //int i = dc.SaveChanges();
            //if (i > 0)
            //    ViewData["e"] = "record inserted";
            //else
            //    ViewData["e"] = "insertion failed";


            var res = (from t in dc.studentlgns
                       where t.studentid == ob.studentid && t.pwd == ob.pwd
                       select t).Count();
            if (res > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["e"] = "invalid credentials";
            }
            return View();
        }
        [HttpPost]
        public ActionResult studentregi(studentlgn ob)
        {
            dc.studentlgns.Add(ob);
            int i = dc.SaveChanges();
            if (i > 0)
                ViewData["e"] = "record inserted";
            else
                ViewData["e"] = "insertion failed";
            return View();
        }

        public ActionResult pdfrecords()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult pdfrecords(string Name)
        {
            //Name="csharp";
            // Check if the search parameter is provided
            if (!string.IsNullOrEmpty(Name))
            {
                // Try to find the PDF document based on the search query
                var pdfDocument = dc.pdfdocuments.FirstOrDefault(p => p.documentname.Contains(Name));

                if (pdfDocument != null)
                {
                    return View(pdfDocument);
                }
            }

            // If no matching PDF is found or search is not provided, display an error message
            return View();
        }




    }





}

//kkk
//testing1111