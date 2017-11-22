using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;

namespace SchoolSupport.Model.Translator
{
    public class SessionTranslator : TranslatorBase<Session, SESSION>
    {
        public override Session TranslateToModel(SESSION sessionEntity)
        {
            try
            {
                Session session = null;
                if (sessionEntity != null)
                {
                    session = new Session();
                    session.Id = sessionEntity.Session_Id;
                    session.Name = sessionEntity.Session_Name;
                    session.StartDate = sessionEntity.Start_Date;
                    session.EndDate = sessionEntity.End_Time;
                    session.Activated = sessionEntity.Activated;
                }

                return session;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override SESSION TranslateToEntity(Session session)
        {
            try
            {
                SESSION sessionEntity = null;
                if (session != null)
                {
                    sessionEntity = new SESSION();
                    sessionEntity.Session_Name = session.Name;
                    sessionEntity.Start_Date = session.StartDate;
                    sessionEntity.End_Time = session.EndDate;
                    sessionEntity.Activated = session.Activated;

                }

                return sessionEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
