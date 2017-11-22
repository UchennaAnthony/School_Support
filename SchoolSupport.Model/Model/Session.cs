using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolSupport.Model.Model
{
    public class Session : Setup
    {
        [Display(Name = "Session")]
        public override int Id { get; set; }

        [Display(Name = "Session")]
        public override string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Activated { get; set; }

    }
}
