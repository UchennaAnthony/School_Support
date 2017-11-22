using School_Support.Areas.Common.ViewModels;
using School_Support.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolSupport.Model.Model;
using SchoolSupport.Model.Entity;
using SchoolSupport.Business;
using System.Transactions;
using System.Data.SqlClient;
using System.Data;
//using SchoolSupport.Business.Nk_BusinessLayer;


namespace School_Support.Areas.Common.Controllers
{
    public class TicketController : BaseController
    {
        private TicketViewModel viewModel = null;
        // GET: Common/Ticket
        public ActionResult Index(int id)
        {
            viewModel = new TicketViewModel();
            viewModel.SchoolId = id;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(TicketViewModel viewModel, int id)
        {
            try
            {
                if (viewModel.Student.MatricNumber != null)
                {
                    
                    DataTable myDataTable = GetInfo(viewModel.Student.MatricNumber, id);

                    string matricNumber = myDataTable.Rows[0][0].ToString();
                    string programme = myDataTable.Rows[0][1].ToString();
                    string department = myDataTable.Rows[0][2].ToString();
                    string departmentOption = myDataTable.Rows[0][3].ToString();
                    string level = myDataTable.Rows[0][4].ToString();
                    string session = myDataTable.Rows[0][5].ToString();
                    string lastName = myDataTable.Rows[0][6].ToString();
                    string firstName = myDataTable.Rows[0][7].ToString();
                    string otherName = myDataTable.Rows[0][8].ToString();
                    string sex = myDataTable.Rows[0][9].ToString();
                    string email = myDataTable.Rows[0][10].ToString();
                    string phoneNumber = myDataTable.Rows[0][11].ToString();

                    DepartmentLogic departmentLogic = new DepartmentLogic();
                    DepartmentOptionLogic departmentOptionLogic = new DepartmentOptionLogic();
                    LevelLogic levelLogic = new LevelLogic();
                    SessionLogic sessionLogic = new SessionLogic();
                    SexLogic sexLogic = new SexLogic();
                    ProgrammeLogic programmeLogic = new ProgrammeLogic();
                    PersonLogic personLogic = new PersonLogic();
                    StudentLogic studentLogic = new StudentLogic();
                    StudentLevelLogic studentLevelLogic = new StudentLevelLogic();
                    TicketLogic ticketLogic = new TicketLogic();

                    Programme proName = programmeLogic.GetModelBy(p => p.Programme_Name == programme);
                    Department dept = departmentLogic.GetModelBy(d => d.Department_Name == department);
                    DepartmentOption deptOption = departmentOptionLogic.GetModelBy(o => o.Department_Otion_Name == departmentOption);
                    Level levl = levelLogic.GetModelBy(l => l.Level_Name == level);
                    Session sess = sessionLogic.GetModelBy(s => s.Session_Name == session);
                    Sex sexe = sexLogic.GetModelBy(sx => sx.Sex_Name == sex);
                    using (TransactionScope Scope = new TransactionScope())
                    {
                        Person person = new Person();
                        Sex seX = new Sex();
                        person.FirstName = firstName;
                        person.LastName = lastName;
                        person.OtherName = otherName;
                        person.Sex = sexe;
                        person.Email = email;
                        person.MobilePhone = phoneNumber;

                        Person createdPerson = personLogic.Create(person);
                        if (createdPerson != null && createdPerson.Id > 0)
                        {
                            Student student = new Student();
                            student.Person = createdPerson;
                            student.MatricNumber = matricNumber;
                            Student createdStudent = studentLogic.Create(student);

                            if (createdStudent != null && createdStudent.Id > 0 && createdPerson.Id > 0)
                            {
                                StudentLevel studentLevel = new StudentLevel();
                                studentLevel.person = createdPerson;
                                studentLevel.Student = createdStudent;
                                studentLevel.Department = dept;
                                studentLevel.Programme = proName;
                                studentLevel.DepartmentOption = deptOption;
                                studentLevel.Level = levl;
                                studentLevel.Session = sess;
                                StudentLevel createdstudentLevel = studentLevelLogic.Create(studentLevel);
                                if (createdstudentLevel != null && createdStudent.Id > 0)
                                {
                                    Ticket ticketToSave = new Ticket();
                                    //ticketToSave.Id = viewModel.Ticket.Id;
                                    //ticketToSave.TicketNumber = viewModel.Ticket.TicketNumber;
                                    ticketToSave.PersonId = createdStudent.Id;
                                    ticketToSave.Complain = viewModel.Ticket.Complain;
                                    ticketToSave.TimeSubmitted = DateTime.Now;
                                    Ticket createdTicket = ticketLogic.Create(ticketToSave,id);
                                    TempData["TicketNumber"] = createdTicket.TicketNumber;
                                }
                            }
                            Scope.Complete();
                        }
                        TempData["Msg"] = "Submission Successful";
                        
                        return RedirectToAction("Index", "Display", new { area = "Common"});
                    }
                }
            }
            catch (Exception ex)
            {
                SetMessage("Invalid Matric Number or Your Details are Incomplete.!" + ex.Message, Message.Category.Error); ;
            }
            
            return View(viewModel);
        }
        public DataTable GetInfo(string Matric_Number, int id)
        {
            try
            {
                 DataTable table = new DataTable();

                switch (id)
                {

                    case 1:
                        string connection = "data source=PAVILION\\SQLEXPRESS;initial catalog=Abundance_Nk_Nekede;integrated security=True;";
                        string commandstring = "SELECT st.Matric_Number, p.Programme_Name, d.Department_Name, t.Department_Option_Name, l.Level_Name, s.Session_Name, ps.Last_Name, ps.First_Name, ps.Other_Name, sx.Sex_Name, ps.Email, ps.Mobile_Phone FROM STUDENT_LEVEL sl, STUDENT st, DEPARTMENT d, DEPARTMENT_OPTION t, PROGRAMME p, [LEVEL] l, [SESSION] s, PERSON ps, SEX sx where sl.Person_Id = st.Person_Id AND st.Matric_Number = @Matric_Number AND sl.Programme_Id = p.Programme_Id AND sl.Department_Id = d.Department_Id AND sl.Department_Option_Id = t.Department_Option_Id AND sl.Level_Id = l.Level_Id AND s.Session_Id = sl.Session_Id AND sl.Person_Id = ps.Person_Id AND ps.Sex_Id = sx.Sex_Id";
                        table = OpenConnection(connection, Matric_Number, commandstring);
                        return table;

                    case 2:
                        string connection2 = "data source=PAVILION\\SQLEXPRESS;initial catalog=Virtual_School_COHAba;integrated security=True;";
                        string commandstring2 = "SELECT st.Matric_Number, p.Programme_Name, d.Department_Name, t.Department_Option_Name, l.Level_Name, s.Session_Name, ps.First_Name, ps.Last_Name, ps.Other_Name, sx.Sex_Name, ps.Mobile_Phone, ps.Email FROM STUDENT_LEVEL sl, STUDENT st, DEPARTMENT d, DEPARTMENT_OPTION t, PROGRAMME p, [LEVEL] l, [SESSION] s, PERSON ps, SEX sx where sl.Person_Id = st.Person_Id AND st.Matric_Number = @Matric_Number AND sl.Programme_Id = p.Programme_Id AND sl.Department_Id = d.Department_Id AND sl.Department_Option_Id = t.Department_Option_Id  AND sl.Level_Id = l.Level_Id AND s.Session_Id = sl.Session_Id AND sl.Person_Id = ps.Person_Id AND ps.Sex_Id = sx.Sex_Id";
                        table = OpenConnection(connection2, Matric_Number, commandstring2);
                        return table;
                }
                return table;
            }
            catch (Exception)
            {
                throw;
            }
        }
     public DataTable OpenConnection(string connection, string matric_Number, string commandstring)
        {
            DataTable DataTables = new DataTable(); 
            try
            {
                
                SqlConnection con = new SqlConnection(connection);
                using (var cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = commandstring;
                    cmd.Parameters.Add("@Matric_Number", matric_Number);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "STUDENT_LEVEL");

                    DataTables = ds.Tables["STUDENT_LEVEL"];
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return DataTables;
   }
        public ActionResult ViewReply()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ViewReply(TicketViewModel viewModel)
        {
            try
            {
                PersonLogic personLogic = new PersonLogic();
                StudentLogic studentLogic = new StudentLogic();
                StudentLevelLogic studentLevelLogic = new StudentLevelLogic();
                TicketLogic ticketLogic = new TicketLogic();

                List<Ticket> tickets = ticketLogic.GetModelsBy(p => p.Ticket_Number == viewModel.Ticket.TicketNumber);
                Ticket myTicket = new Ticket();

                if (tickets.Count > 1)
                {
                    TempData["Msg"] = "Ticket Number Is duplicate";
                    return View();
                }
                if (tickets.Count == 0)
                {
                    TempData["Msg"] = "No record Found. Please submit Your Complaint!";
                }
                if (tickets.Count == 1)
                {
                    myTicket = tickets.FirstOrDefault();
                }
                viewModel.Ticket = myTicket;
                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Error Occured" + ex;
            }
            return RedirectToAction("ViewReply");
        }
    }
}
