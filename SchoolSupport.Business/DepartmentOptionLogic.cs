using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;
using SchoolSupport.Model.Translator;

namespace SchoolSupport.Business
{
    public class DepartmentOptionLogic : BusinessBaseLogic<DepartmentOption, DEPARTMENT_OPTION>
    {
        public DepartmentOptionLogic()
        {
            translator = new DepartmentOptionTranslator();
        }
        public bool Modify(DepartmentOption option)
        {
            try
            {
                Expression<Func<DEPARTMENT_OPTION, bool>> selector = d => d.Department_Option_Id == option.Id;
                DEPARTMENT_OPTION entity = GetEntityBy(selector);

                if (entity == null)
                {
                    throw new Exception(NoItemFound);
                }

                entity.Department_Otion_Name = option.Name;
                entity.DEPARTMENT.Department_Id = option.Department.Id;

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
