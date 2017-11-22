using SchoolSupport.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_Support.Areas.Admin.ViewModels;

namespace School_Support.Areas.Common.Controllers
{
    public class DisplayController : Controller
    {
        // GET: Common/Display
        public ActionResult Index()
        {
            string ticketNumber = (string)TempData["TicketNumber"];
            if (ticketNumber != null)
            {
                SupportViewModel viewModel = new SupportViewModel();
                viewModel.Ticket = new Ticket
                {
                    TicketNumber = ticketNumber
                };
              
                return View(viewModel);
            }
            return View();
        }
    }
}