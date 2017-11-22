using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;

namespace SchoolSupport.Model.Translator
{
   public class StudentTranslator: TranslatorBase<Student, STUDENT>
    {
       private StudentCategoryTranslator studentCategoryTranslator;
       private SchoolTranslator schoolTranslator;
       private PersonTranslator personTranslator;
       public StudentTranslator()
        {
           studentCategoryTranslator = new StudentCategoryTranslator();
           schoolTranslator = new SchoolTranslator();
           personTranslator = new PersonTranslator();
       }
       public override Student TranslateToModel(STUDENT studentEntity)
        {
            try
            {
                Student student = null;
                if (studentEntity != null)
                {
                    student = new Student();
                    student.Person = new Person();
                    student.Id = studentEntity.Person_Id;
                    student.Number = studentEntity.Student_Number;
                    student.MatricNumber = studentEntity.Matric_Number;
                    student.ApplicationFormNumber = studentEntity.Application_Form_Number;
                    student.SchoolContactAddress = studentEntity.School_Contact_Address;
                    student.Category = studentCategoryTranslator.TranslateToModel(studentEntity.STUDENT_CATEGORY);
                    student.School = schoolTranslator.TranslateToModel(studentEntity.SCHOOL);
                    if (studentEntity.PERSON != null)
                    {
                        student.LastName = studentEntity.PERSON.Last_Name;
                        student.FirstName = studentEntity.PERSON.First_Name;
                        student.OtherName = studentEntity.PERSON.Other_Name;
                        student.Email = studentEntity.PERSON.Email;
                        student.MobilePhone = studentEntity.PERSON.Mobile_Phone;
                    }
                }

                return student;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override STUDENT TranslateToEntity(Student student)
        {
            try
            {
                STUDENT studentEntity = null;
                if (student != null)
                {
                    studentEntity = new STUDENT();
                    studentEntity.Person_Id = student.Person.Id;
                    if (student.Category != null)
                    {
                        studentEntity.Student_Category_Id = student.Category.Id; 
                    }
                   
                    studentEntity.Student_Number = student.Number;
                    studentEntity.Matric_Number = student.MatricNumber;
                    studentEntity.School_Contact_Address = student.SchoolContactAddress;
                    //studentEntity.School_Id = student.School.Id;
                    studentEntity.Application_Form_Number = student.ApplicationFormNumber;
                }

                return studentEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
