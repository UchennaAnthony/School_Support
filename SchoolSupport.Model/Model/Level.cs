using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolSupport.Model.Model
{
    public class Level : BasicSetup
    {
        [Display(Name = "Level")]
        public override int Id { get; set; }

        [Display(Name = "Level")]
        public override string Name { get; set; }
    }
}
