using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSupport.Model.Model
{
    public class School
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public byte? ShortCode{get; set;}
    }
}
