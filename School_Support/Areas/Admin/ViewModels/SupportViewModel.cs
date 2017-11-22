using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms.VisualStyles;
using SchoolSupport.Model.Model;
using School_Support.Models;

namespace School_Support.Areas.Admin.ViewModels
{
    public class SupportViewModel
    {
        public Ticket Ticket { get; set; }
        public List<Ticket> Tickets { get; set; }
        public Student Student { get; set; }
        public List<Student> StudentList { get; set; }
        public StudentLevel StudentLevel { get; set; }
        public List<StudentLevel> StudentLevelList { get; set; }
        public Person Person { get; set; }
        public List<Person> Persons { get; set; }
        public Level Level { get; set; }
        public Session Session { get; set; }
        public Programme Programme { get; set; }
        public Department Department { get; set; }
        public DepartmentOption DepartmentOption { get; set; }
        public Sex Sex { get; set; }
    }
}