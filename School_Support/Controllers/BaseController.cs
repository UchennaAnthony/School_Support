using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SchoolSupport.Business;
using SchoolSupport.Model.Model;

namespace School_Support.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public BaseController()
        {
            //if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    string username = System.Web.HttpContext.Current.User.Identity.Name;

            //    if (username != null)
            //    {
            //        StaffLogic staffLogic = new StaffLogic();
            //        Staff staff = new Staff();
            //        staff = staffLogic.GetBy(username);
            //        if (staff == null)
            //        {
            //            RedirectToAction("Index", "Profile", new { Area = "Admin" });
            //        }
            //    }
            //}
        }
        protected void SetMessage(string message, Message.Category messageType)
        {
            Message msg = new Message(message, (int)messageType);
            TempData["Message"] = msg;
        }
    }
}