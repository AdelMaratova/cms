using ContainerManagementSystem.Controllers.Shared;
using ContainerManagementSystem.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContainerManagementSystem.Models.User;

namespace ContainerManagementSystem.Controllers
{
    public class UserController : SharedControllerBase
    {
        //
        // GET: /User/

        public ActionResult MyProfile()
        {
            Guid current_user_id = MySession.CurrentSession.UserId;

            User current_user = context.Users.ToList().Where(x => x.UserId == current_user_id).FirstOrDefault();

            ViewData.Model = current_user;

            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }

        public JsonResult Deleteuser(Guid user_id)
        {
            AjaxResponse returnModel = new AjaxResponse();

            User found_user = context.Users.Where(x => x.UserId == user_id).FirstOrDefault();

            if (found_user != null)
            {
                context.Users.Remove(found_user);
            }

            return Json(returnModel);
        }

        public JsonResult GetUserInfo()
        {
            Guid current_user_id = MySession.CurrentSession.UserId;

            User current_user = context.Users.ToList().Where(x => x.UserId == current_user_id).FirstOrDefault();

            return Json(current_user, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UserCreateUpdate(User user)
        {
            User found_user = context.Users.Where(x => x.UserId == user.UserId).FirstOrDefault();

            if(found_user != null)
            {
                found_user.FirstName = user.FirstName;
                found_user.LastName = user.LastName;
                found_user.Email = user.Email;
                found_user.Password = user.Password;
            }
            else
            {
                found_user = new User();

                found_user.UserId = Guid.NewGuid();
                found_user.FirstName = user.FirstName;
                found_user.LastName = user.LastName;
                found_user.Email = user.Email;
                found_user.Password = user.Password;

                context.Users.Add(found_user);
            }

            context.SaveChanges();

            return Json("");
        }

        public string GetNewGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
