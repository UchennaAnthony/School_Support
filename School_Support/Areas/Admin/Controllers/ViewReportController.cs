using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolSupport.Business;
using SchoolSupport.Model.Model;
using SchoolSupport.Model.Entity;
using School_Support.Controllers;
using School_Support.Areas.Admin.ViewModels;
using System.IO;
using System.Web.UI;
//using ClosedXML.Excel; 
using System.Web.UI.WebControls;

namespace School_Support.Areas.Admin.Controllers
{
    public class ViewReportController : BaseController
    {
        private SupportViewModel viewModel;
        private Ticket ticket;
        private TicketLogic ticketLogic;
        private School_SupportEntities db = new School_SupportEntities();
        private Student student;
        private StudentLogic studentLogic;
        private StudentLevelLogic studentLevelLogic;

        public ViewReportController()
        {
            viewModel = new SupportViewModel();
            ticketLogic = new TicketLogic();
            ticket = new Ticket();
            student = new Student();
            studentLogic = new StudentLogic();
        }
        public ActionResult Index()
        {
            try
            {
                List<Ticket> ticketList = new List<Ticket>();
                ticketList = ticketLogic.GetAll();
                viewModel.Tickets = ticketList;

                List<Student> studentList = new List<Student>();
                studentList = studentLogic.GetAll();
                viewModel.StudentList = studentList;

                //List<StudentLevel> studentLevelList = new List<StudentLevel>();
                //studentLevelList = studentLevelLogic.GetAll();
                //viewModel.StudentLevelList = studentLevelList;
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Failed" + e;
            }
            return View(viewModel);
        }
        public List<ExportModel> GetMyDataSource()
        {
            List<ExportModel> dataSource = new List<ExportModel>();
            try
            {
                List<Ticket> ticketList = new List<Ticket>();
                ticketList = ticketLogic.GetAll();

                for (int i = 0; i < ticketList.Count; i++)
                {
                    ExportModel model = new ExportModel();
                    model.MatricNumber = ticketList[i].Student.MatricNumber;
                    model.Complain = ticketList[i].Complain;
                    model.Reply = ticketList[i].Reply;
                    model.TicketNumber = ticketList[i].TicketNumber;
                    model.TImesubmitted = ticketList[i].TimeSubmitted;
                    model.TimeReplied = ticketList[i].TimeReplied;

                    dataSource.Add(model);
                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Failed" + e;
            }

            return dataSource;
        }
        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            gv.DataSource = GetMyDataSource();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=SupportReportExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View(viewModel);
        }
    }
}
