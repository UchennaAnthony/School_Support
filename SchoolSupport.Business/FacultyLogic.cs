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
    public class FacultyLogic : BusinessBaseLogic<Faculty, FACULTY>
    {
        public FacultyLogic()
        {
            translator = new FacultyTranslator();
        }

        public bool Modify(Faculty faculty)
        {
            try
            {
                Expression<Func<FACULTY, bool>> selector = f => f.Faculty_Id == faculty.Id;
                FACULTY entity = GetEntityBy(selector);

                if (entity == null)
                {
                    throw new Exception(NoItemFound);
                }

                entity.Faculty_Name = faculty.Name;
                entity.Faculty_Description = faculty.Description;

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
    }
}
