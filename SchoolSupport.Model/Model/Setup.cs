using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolSupport.Model.Model
{
    public abstract class Setup
    {
        [Required]

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
    }    
}
