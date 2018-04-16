using ContainerManagementSystem.Controllers.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using ContainerManagementSystem.Models.User;

namespace ContainerManagementSystem.Controllers
{
    public class HomeController : SharedControllerBase
    {
        public ActionResult Index()
        {
            List<User> users = new List<User>();

            users = context.Users.ToList();

            //User user = new User();

            //user = new Models.User.User()
            //{
            //    UserId = Guid.NewGuid(),
            //    FirstName = "Atai",
            //    LastName = "Bekenov",
            //    Password = "12345",
            //    Email = "atai@mail.com"
            //};

            //context.Users.Add(user);
            //context.SaveChanges();

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
