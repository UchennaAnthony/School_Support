using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;

namespace SchoolSupport.Model.Translator
{
    public class DepartmentTranslator : TranslatorBase<Department, DEPARTMENT>
    {
        private FacultyTranslator facultyTranslator;

        public DepartmentTranslator()
        {
            facultyTranslator = new FacultyTranslator();
        }

        public override Department TranslateToModel(DEPARTMENT entity)
        {
            try
            {
                Department department = null;
                if (entity != null)
                {
                    department = new Department();
                    department.Id = entity.Department_Id;
                    department.Name = entity.Department_Name;
                    department.Code = entity.Department_Code;
                    department.Faculty = facultyTranslator.Translate(entity.FACULTY);
                }

                return department;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override DEPARTMENT TranslateToEntity(Department department)
        {
            try
            {
                DEPARTMENT entity = null;
                if (department != null)
                {
                    entity = new DEPARTMENT();
                    entity.Department_Id = department.Id;
                    entity.Department_Name = department.Name;
                    entity.Department_Code = department.Code;
                    entity.Faculty_Id = department.Faculty.Id;
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
