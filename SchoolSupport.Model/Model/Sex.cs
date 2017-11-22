using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolSupport.Model.Model
{
    public class Sex
    {
        [Required]
        [Display(Name = "Sex")]
        public int Id { get; set; }

        [Display(Name = "Sex")]
        public string Name { get; set; }
    }

}
