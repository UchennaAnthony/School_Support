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
    public class ProgrammeLogic: BusinessBaseLogic<Programme, PROGRAMME>
    {
        public ProgrammeLogic()
        {
            translator = new ProgrammeTranslator();
        }

        public bool Modify(Programme programme)
        {
            try
            {
                Expression<Func<PROGRAMME, bool>> selector = p => p.Programme_Id == programme.Id;
                PROGRAMME entity = GetEntityBy(selector);

                if (entity == null)
                {
                    throw new Exception(NoItemFound);
                }

                entity.Programme_Name = programme.Name;
                entity.Programme_Description = programme.Description;

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

        public List<Programme> GetActivated()
        {
            try
            {
                Expression<Func<PROGRAMME, bool>> selector = p => p.Activated == true;
                List<Programme> programmes = GetModelsBy(selector);

                return programmes;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
