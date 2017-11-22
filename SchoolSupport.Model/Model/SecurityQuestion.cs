using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolSupport.Model.Model
{
    public class SecurityQuestion : Setup
    {
        [Required]
        [Display(Name = "Security Question")]
        public override int Id { get; set; }

        public override string Name { get; set; }
    }
}
