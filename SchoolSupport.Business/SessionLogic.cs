using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SchoolSupport.Data;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;
using SchoolSupport.Model.Translator;


namespace SchoolSupport.Business
{
    public class SessionLogic: BusinessBaseLogic<Session, SESSION>
    {
        public SessionLogic()
        {
            translator = new SessionTranslator();
        }

        public bool Modify(Session session)
        {
            try
            {
                Expression<Func<SESSION, bool>> selector = s => s.Session_Id == session.Id;
                SESSION entity = GetEntityBy(selector);

                if (entity == null)
                {
                    throw new Exception(NoItemFound);
                }

                entity.Session_Name = session.Name;
                entity.Start_Date = session.StartDate;
                entity.End_Time = session.EndDate;

                int modifiedRecordCount = Save();
                if (modifiedRecordCount <= 0)
                {
                    throw new Exception(NoItemModified);
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Session GetCurrentSession()
        {
            try
            {
                Expression<Func<SESSION, bool>> selector = s => s.Activated == true;
                return GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
