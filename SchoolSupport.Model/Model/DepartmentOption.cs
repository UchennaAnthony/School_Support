using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolSupport.Model.Model
{
    public class DepartmentOption
    {
        [Display(Name = "Course Option")]
        public int Id { get; set; }

        [Display(Name = "Course Option")]
        public string Name { get; set; }

        [Display(Name = "Course Option Status")]
        public bool Activated { get; set; }
        public Department Department { get; set; }
    }

}
