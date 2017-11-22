using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSupport.Model.Model
{
    public class ExportModel
    {
        public string TicketNumber { get; set; }
        public string MatricNumber { get; set; }
        public string Complain { get; set; }
        public string Reply { get; set; }
        public DateTime TImesubmitted { get; set; }
        public DateTime? TimeReplied { get; set; }

    }
}
