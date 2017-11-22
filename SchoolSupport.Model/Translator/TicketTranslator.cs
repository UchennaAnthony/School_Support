using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;

namespace SchoolSupport.Model.Translator
{
    public class TicketTranslator: TranslatorBase<Ticket, TICKET>
    {
        private StudentTranslator studentTranslator;
        public TicketTranslator()
        {
            studentTranslator = new StudentTranslator();
        }
        public override Ticket TranslateToModel(TICKET entity)
        {
            try
            {
                Ticket model = null;
                if (entity != null)
                {
                    model = new Ticket();
                    model.Id = entity.Ticket_Id;
                    model.TicketNumber = entity.Ticket_Number;
                    model.TicketSerialNumber = entity.Ticket_Serial_Number;
                    model.Student = studentTranslator.Translate(entity.STUDENT);
                    model.Complain = entity.Complaint;
                    model.Reply = entity.Reply;
                    model.TimeSubmitted = entity.Date_Submitted;
                    model.TimeReplied = entity.Date_Replied;
                    model.Activated = entity.Activated;

                }
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override TICKET TranslateToEntity(Ticket model)
        {
            try
            {
                TICKET entity = null;
                if (model != null)
                {
                    entity = new TICKET();
                    //entity.Ticket_Id = model.Id;
                    entity.Ticket_Number = model.TicketNumber;
                    entity.Ticket_Serial_Number = model.TicketSerialNumber;
                    entity.Person_Id = model.PersonId;
                    entity.Complaint = model.Complain;
                    entity.Reply = model.Reply;
                    entity.Date_Submitted = model.TimeSubmitted;
                    entity.Date_Replied = model.TimeReplied;
                    entity.Activated = model.Activated;
                }
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
