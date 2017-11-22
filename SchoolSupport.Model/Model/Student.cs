using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolSupport.Model.Model
{
    public class Student : Person
    {
        public Person Person { get; set; }
        public long? Number { get; set; }

        [Display(Name="Matric Number")]
        public string MatricNumber { get; set; }
        public string ApplicationFormNumber { get; set; }

       [Display(Name = "Hall/Off Campus Address")]
        public string SchoolContactAddress { get; set; }
       public StudentCategory Category { get; set; }
       public School School { get; set; }
       
    }
}
