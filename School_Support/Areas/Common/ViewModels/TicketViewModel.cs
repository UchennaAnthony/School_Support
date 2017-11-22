using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolSupport.Model.Model;

namespace School_Support.Areas.Common.ViewModels
{
    public class TicketViewModel
    {
        public Person Person { get; set; }
        public Student Student { get; set; }
        public List<Ticket> Tickets { get; set; }
        public Ticket Ticket { get; set; }
        public StudentLevel Level { get; set; }
        public int SchoolId { get; set; }
    }
}