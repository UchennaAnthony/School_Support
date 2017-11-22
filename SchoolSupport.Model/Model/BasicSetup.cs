using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolSupport.Model.Model
{
    public abstract class BasicSetup : Setup
    {
        public virtual string Description { get; set; }
    }
}
