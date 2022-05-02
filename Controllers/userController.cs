using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.service;

namespace WebApplication1.Controllers
{
    public class userController : Controller
    {
        Userdal ud = new Userdal();
        // GET: user
        public ActionResult List()
        {
            var data = ud.GetUsers();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Usermodel user)
        {
            
            if (ud.Insertusers((user)))
           
            {
                TempData["Insertmsg"] = "<script>alert('saved')</script>";
                return RedirectToAction("list");
            }
            else
            {
                TempData["Inserterrormsg"] = "<script>alert('not saved')<script>";
                return RedirectToAction("list");
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            var data = ud.GetUsers().Find(a => a.id == id);
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var data = ud.GetUsers().Find(a => a.id==id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Usermodel user)
        {

            if (ud.Updateusers((user)))

            {
                TempData["updatemsg"] = "<script>alert('update sucessful')</script>";
                return RedirectToAction("list");
            }
            else
            {
                TempData["updateErrormsg"] = "<script>alert('updatenotsucessful')<script>";
                
            }
            return View();
        }
       // [HttpPost]
        public ActionResult Delete(int id)
        {
            int r = ud.Deleteusers(id);
            if(r>0)

            {
                TempData["deletemsg"] = "<script>alert('deletion sucessful')</script>";
                return RedirectToAction("list");
            }
            else
            {
                TempData["delteErrormsg"] = "<script>alert('deletenotsucessful')<script>";
                return RedirectToAction("list");
            }
            return View();
        }
    }
}