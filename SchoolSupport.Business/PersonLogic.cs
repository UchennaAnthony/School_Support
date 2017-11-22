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
    public class PersonLogic : BusinessBaseLogic<Person, PERSON>
    {
        public PersonLogic()
        {
            translator = new PersonTranslator();
        }
        public bool Modify(Person person)
        {
            try
            {
                PERSON entity = GetEntityBy(s => s.Person_Id == person.Id);

                if (entity != null)
                {

                    entity.Person_Id = person.Id;
                    if (person.FirstName != null)
                    {
                        entity.First_Name = person.FirstName;
                    }
                    if (person.LastName != null)
                    {
                        entity.Last_Name = person.LastName;
                    }
                    if (person.OtherName != null)
                    {
                        entity.Other_Name = person.OtherName;
                    }
                    if (person.Email != null)
                    {
                        entity.Email = person.Email;
                    }
                    //if (person.DateOfBirth != null)
                    //{
                    //    entity.Date_Of_Birth = person.DateOfBirth;
                    //}
                    if (person.MobilePhone != null)
                    {
                        entity.Mobile_Phone = person.MobilePhone;
                    }
                    if (person.Sex != null)
                    {
                        entity.Sex_Id = person.Sex.Id;
                    }
                    int modifiedRecordCount = Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Person GetBy(long Id)
        {
            try
            {
                Expression<Func<PERSON, bool>> selector = p => p.Person_Id == Id;
                return GetModelBy(selector);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
