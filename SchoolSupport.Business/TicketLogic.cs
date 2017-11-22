using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSupport.Data;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;
using SchoolSupport.Model.Translator;
using System.Linq.Expressions;


namespace SchoolSupport.Business
{
    public class TicketLogic:BusinessBaseLogic<Ticket, TICKET>
    {
         public TicketLogic()
        {
            translator = new TicketTranslator();
        }
        public bool Modify(Ticket ticket)
        {
            try
            {
                TICKET entity = GetEntityBy(s => s.Ticket_Id == ticket.Id);

                if (entity != null)
                {

                    entity.Ticket_Id = ticket.Id;
                    entity.Person_Id = ticket.Student.Person.Id;
                    if (ticket.Complain != null)
                    {
                        entity.Complaint = ticket.Complain;
                    }
                    int modifiedRecordCount = Save();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
            public Ticket GetBy(string TicketNumber)
            {
                try
            {
                Expression<Func<TICKET, bool>> selector = p => p.Ticket_Number == TicketNumber;
                Ticket ticket = GetModelBy(selector);
                return ticket;
            }
                catch
                {
                    throw;
                }
        }
            public bool SetTicketNumber(Ticket ticket)
            {
                try
                {
                    Expression<Func<TICKET, bool>> selector = p => p.Ticket_Id == ticket.Id;
                    TICKET entity = base.GetEntityBy(selector);
                    if (entity == null)
                    {
                        throw new Exception(NoItemFound);
                    }
                    entity.Ticket_Serial_Number = ticket.TicketSerialNumber;
                    entity.Ticket_Number = ticket.TicketNumber;
                    int modifiedRecordCount = Save();
                    if (modifiedRecordCount <= 0)
                    {
                        return false;
                    }

                    return true;
                }
                catch
                {
                    throw;
                }
            }
            public Ticket SetNextTicketNumber(Ticket ticket,int id)
            {
                try
                {
                    switch(id)
                    { 
                    case 1:
                    ticket.TicketSerialNumber = ticket.Id;
                    ticket.TicketNumber = "FPNO" + DateTime.Now.ToString("yy") + PaddNumber(ticket.Id, 6);
                    return ticket;

                    case 2:
                    ticket.TicketSerialNumber = ticket.Id;
                    ticket.TicketNumber = "COHA" + DateTime.Now.ToString("yy") + PaddNumber(ticket.Id, 6);
                    return ticket;
                }
                    return ticket;
            }
                catch (Exception)
                {
                    throw;
                }
            }
            public static string PaddNumber(long id, int maxCount)
            {
                try
                {
                    string idInString = id.ToString();
                    string paddNumbers = "";
                    if (idInString.Count() < maxCount)
                    {
                        int zeroCount = maxCount - id.ToString().Count();
                        StringBuilder builder = new StringBuilder();
                        for (int counter = 0; counter < zeroCount; counter++)
                        {
                            builder.Append("0");
                        }

                        builder.Append(id);
                        paddNumbers = builder.ToString();
                        return paddNumbers;
                    }
                    else
                    {
                        paddNumbers = id.ToString();
                    }

                    return paddNumbers;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            public Ticket Create(Ticket ticket,int id)
            {
                try
                {
                    Ticket newTicket = base.Create(ticket);
                    if (newTicket == null || newTicket.Id <= 0)
                    {
                        throw new Exception("Ticket not set!");
                    }
                    newTicket = SetNextTicketNumber(newTicket, id);
                    SetTicketNumber(newTicket);
                    return newTicket;
                }
                catch (Exception)
                {
                    throw;
                }
                
            }

            public Ticket Update(Ticket ticket)
            {
                try
                {
                    Expression<Func<TICKET, bool>> selector = a => a.Ticket_Id == ticket.Id;
                    TICKET entity = GetEntityBy(selector);

                    //entity.Ticket_Number = ticket.TicketNumber;
                    //entity.Complaint = ticket.Complain;
                    //entity.Ticket_Serial_Number = ticket.TicketSerialNumber;
                    //entity.Person_Id = ticket.PersonId;
                    if (ticket.Reply != null)
                    {
                        entity.Reply = ticket.Reply;
                    }
                    //entity.Date_Submitted = DateTime.Now;
                    entity.Date_Replied = DateTime.Now;
                    int modifiedRecordCount = Save();
                    if (modifiedRecordCount <= 0)
                    {
                        throw new Exception(NoItemModified);
                    }

                    return ticket;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            public bool UpdateTimeReplied(Ticket ticket)
            {
                try
                {
                    Expression<Func<TICKET, bool>> selector = p => p.Date_Replied == ticket.TimeReplied && p.Ticket_Number == ticket.TicketNumber;
                    TICKET entity = GetEntityBy(selector);
                    if (entity == null || entity.Ticket_Id <= 0)
                    {
                        throw new Exception(NoItemFound);
                    }

                    entity.Ticket_Number = ticket.TicketNumber;
                    entity.Person_Id = ticket.Student.Person.Id;
                    entity.Complaint = ticket.Complain;
                    entity.Reply = ticket.Reply;
                    entity.Date_Submitted = ticket.TimeSubmitted;
                    entity.Date_Replied = DateTime.Now;
                    int modifiedRecordCount = Save();
                    if (modifiedRecordCount <= 0)
                    {
                        throw new Exception(NoItemModified);
                    }

                    return true;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return false;

            }
            }
 }    

