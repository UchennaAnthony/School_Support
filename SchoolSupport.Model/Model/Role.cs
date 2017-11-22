using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolSupport.Model.Model
{
    public class Role : BasicSetup
    {
         public override int Id { get; set; }
        public string RoleName { get; set; }
    }
    
}
