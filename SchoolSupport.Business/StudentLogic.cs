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
    public class StudentLogic: BusinessBaseLogic<Student, STUDENT>
    {
        private PersonLogic personLogic;
        public StudentLogic()
        {
            personLogic = new PersonLogic();
            translator = new StudentTranslator();
        }

        public Student GetBy(string matricNumber)
        {
            try
            {
                Expression<Func<STUDENT, bool>> selector = s => s.Matric_Number == matricNumber;
                return base.GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Student GetBy(long id)
        {
            try
            {
                Expression<Func<STUDENT, bool>> selector = s => s.Person_Id == id;
                return base.GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(Student student)
        {
            try
            {
                STUDENT entity = GetEntityBy(s => s.Person_Id == student.Person.Id);
                entity.Person_Id = student.Person.Id;
                entity.Student_Number = student.Number;
                entity.Application_Form_Number = student.ApplicationFormNumber;
                entity.Matric_Number = student.MatricNumber;
                entity.School_Contact_Address = student.SchoolContactAddress;
                entity.School_Id = student.School.Id;
              if (student.Category != null && student.Category.Id > 0)
                {
                    entity.Student_Category_Id = student.Category.Id;
                }
                int modifiedRecordCount = Save();
                if (modifiedRecordCount <= 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public override Student Add(Student student)
        //{
        //    try
        //    {
        //        Person person = personLogic.Create(student);
        //        student.Id = person.Id;

        //        Student newStudent = base.Create(student);
        //        if (newStudent != null)
        //        {
        //            newStudent.FullName = person.FullName;
        //        }

        //        return newStudent;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
