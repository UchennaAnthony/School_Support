using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.EnterpriseServices.Internal;
using System.Transactions;
using School_Support.Models;
using School_Support.Controllers;
using SchoolSupport.Model.Model;
using SchoolSupport.Business;
using School_Support.Areas.Admin.ViewModels;
using System.Net;
using SchoolSupport.Model.Entity;

namespace School_Support.Areas.Admin.Controllers
{
    public class SupportController : BaseController
    {
        private SupportViewModel viewModel;
        private TicketLogic ticketLogic;
        private Ticket ticket;
        private Student student;
        private StudentLogic studentLogic;
        private School_SupportEntities db = new School_SupportEntities();
        public SupportController()
        {
            viewModel = new SupportViewModel();
            ticketLogic = new TicketLogic();
            ticket = new Ticket();
            student = new Student();
            studentLogic = new StudentLogic();
        }
        // GET: Admin/Support
        public ActionResult Index()
        {
            try
            {
                 List<Ticket> ticketList = new List<Ticket>();
                ticketList = ticketLogic.GetAll();
                viewModel.Tickets = ticketList;
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Failed" + e;
            }
            return View(viewModel);
        }
        public ActionResult EditTicket(int? id)
        {
            viewModel = null;
            try
            {
                if (id != null)
                {
                    TempData["ticketId"] = id;
                    ticket = ticketLogic.GetModelBy(p => p.Ticket_Id == id);
                    viewModel = new SupportViewModel();
                    viewModel.Ticket = ticket;
                }
                else
                {
                    TempData["Msg"] = "Select a Ticket";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Error Occured"+ ex;
            }
            return View (viewModel);
            }
    [HttpPost]
        public ActionResult EditTicket(SupportViewModel viewModel)
    {
        try
            {
                if (viewModel != null)
                {
                    viewModel.Ticket.Id = (int)TempData["ticketId"];
                    //viewModel.Student.MatricNumber = (string)TempData["matricNo"];
                    ticketLogic.Update(viewModel.Ticket);
                    TempData["Msg"] = "Ticket is Edited Successfully";
                }
                else
                {
                    TempData["Msg"] = "Input is null!";
                    return RedirectToAction("EditTicket");
                }
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Error Occured" + ex;
            }
            return RedirectToAction("Index");
        }
    public ActionResult GetTicketDetailsByDate()
    {
        return View();
    }
        [HttpPost]
    public ActionResult GetTicketDetailsByDate(SupportViewModel viewModel)
    {
        try
        {
            if (viewModel.Ticket.TimeSubmitted != null)
            {
                ticketLogic = new TicketLogic();
                List<Ticket> tickets = ticketLogic.GetModelsBy(t => t.Date_Submitted == viewModel.Ticket.TimeSubmitted);
                Ticket myTicket = new Ticket();
                if (tickets.Count == 0)
                {
                    TempData["Msg"] = "No Complains were submitted on this date.";
                }
                if (tickets.Count >= 1)
                {
                    myTicket = tickets.FirstOrDefault();

                }
                viewModel.Tickets = tickets;
                
                return View(viewModel);
            }
        }
        catch(Exception)
        {
            throw;
        }
        return RedirectToAction("GetTicketDetailsByDate");
    }
        public ActionResult ViewTicketDetails(int? id)
        {
            try
            {
                viewModel = null;
                if (id != null)// && matricNumber != null)
                {
                    StudentLogic studentLogic = new StudentLogic();
                    ticket = ticketLogic.GetModelBy(t => t.Ticket_Id == id);
                    //student = studentLogic.GetModelBy(s => s.Person_Id == ticket.PersonId);
                    viewModel = new SupportViewModel();
                    viewModel.Ticket = ticket;
                    //viewModel.Student = student;
                    return View(viewModel);
                }
                else
                {
                    TempData["Msg"] = "Select a Ticket";
                    return RedirectToAction("EditTicket");
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
        public ActionResult ViewStudentDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ViewStudentDetails(SupportViewModel viewModel)
        {
            try
            {
                StudentLogic studentLogic = new StudentLogic();
                StudentLevelLogic studentLevelLogic = new StudentLevelLogic();
                PersonLogic personLogic = new PersonLogic();
                List<Student> students = studentLogic.GetModelsBy(x => x.Matric_Number == viewModel.Student.MatricNumber);
                Student myStudent = new Student();
                //Person persons = new Person();
                if (students.Count > 1)
                {
                    TempData["Msg"] = "Matric Number is duplicate";
                    return View();
                }
                if (students.Count == 0)
                {
                    Student appliedStudent = studentLogic.GetModelsBy(s => s.Application_Form_Number == viewModel.Student.MatricNumber).LastOrDefault();
                    if (appliedStudent == null)
                    {
                        TempData["Msg"] = "No record found";
                        return View();
                    }

                    else
                    {
                        myStudent = appliedStudent;
                    }
                }
                if (students.Count == 1)
                {
                    myStudent = students.FirstOrDefault();
                }
                viewModel.StudentLevelList = studentLevelLogic.GetModelsBy(s => s.STUDENT.Person_Id == myStudent.Id);
                //viewModel.Persons = personLogic.GetModelsBy(p => p.Person_Id == persons.Id);
                viewModel.Student = myStudent;
                return View(viewModel);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("ViewStudentDetails");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET ticket = db.TICKET.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Admin/Hostel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TICKET ticket = db.TICKET.Find(id);
            db.TICKET.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }  
}