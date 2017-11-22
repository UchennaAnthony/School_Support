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
    public class DepartmentLogic:BusinessBaseLogic<Department, DEPARTMENT>
    {
        public DepartmentLogic()
        {
            translator = new DepartmentTranslator();
        }

        public bool Modify(Department department)
        {
            try
            {
                Expression<Func<DEPARTMENT, bool>> selector = f => f.Department_Id == department.Id;
                DEPARTMENT entity = GetEntityBy(selector);

                if (entity == null)
                {
                    throw new Exception(NoItemFound);
                }

                entity.Department_Name = department.Name;
                entity.Department_Code = department.Code;
                entity.Faculty_Id = department.Faculty.Id;

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
