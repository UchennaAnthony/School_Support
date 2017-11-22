using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSupport.Model.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public int? TicketSerialNumber { get; set; }
        
        public long PersonId { get; set; }
        public Student Student  { get; set; }
        public string Complain { get; set; }
        public string Reply { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public DateTime? TimeReplied { get; set; }
        public bool Activated { get; set; }
    }
}
