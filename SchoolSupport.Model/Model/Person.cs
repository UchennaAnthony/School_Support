using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolSupport.Model.Model
{
    public class Person
    {
        //private string name;
        private string fullName;

        public long Id { get; set; }
   
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [Display(Name = "Other Name")]
        public string OtherName { get; set; }
        //[Display(Name = "Name")]
        public string FullName
        {
            get { return LastName + " " + FirstName + " " + OtherName; }
            set { fullName = value; }
        }

        //[Display(Name = "Name")]
        //public string Name
        //{
        //    get { return LastName + " " + FirstName; }
        //    set { name = value; }
        //}
        public Sex Sex { get; set; }

        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mobile Phone")]
        [RegularExpression("^0[0-9]{10}$", ErrorMessage = "Phone number is not valid")]
        public string MobilePhone { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        //[Display(Name = "Date of Birth")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime? DateOfBirth { get; set; }

        //public Value DayOfBirth { get; set; }
        //public Value MonthOfBirth { get; set; }
        //public Value YearOfBirth { get; set; }
    }
}
