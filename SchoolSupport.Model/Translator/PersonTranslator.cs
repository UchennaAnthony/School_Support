using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;

namespace SchoolSupport.Model.Translator
{
    public class PersonTranslator: TranslatorBase<Person, PERSON>
    {
        private SexTranslator sexTranslator;
        public PersonTranslator()
        {
            sexTranslator = new SexTranslator();
        }
        public override Person TranslateToModel(PERSON entity)
        {
            try
            {
                Person model = null;
                if (entity != null)
                {
                    model = new Person();
                    model.Id = entity.Person_Id;
                    model.FirstName = entity.First_Name;
                    model.LastName = entity.Last_Name;
                    model.OtherName = entity.Other_Name;
                    model.Sex = sexTranslator.Translate(entity.SEX);
                    model.MobilePhone = entity.Mobile_Phone;
                    model.Email = entity.Email;
                    //model.DateOfBirth = entity.Date_Of_Birth;
                    //if (entity.Date_Of_Birth.HasValue)
                    //{
                    //    model.DayOfBirth = new Value() { Id = entity.Date_Of_Birth.Value.Day };
                    //    model.MonthOfBirth = new Value() { Id = entity.Date_Of_Birth.Value.Month };
                    //    model.YearOfBirth = new Value() { Id = entity.Date_Of_Birth.Value.Year };
                    //}
                }
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override PERSON TranslateToEntity(Person model)
        {
            try
            {
                PERSON entity = null;
                if (model != null)
                {
                    entity = new PERSON();
                    entity.Person_Id = model.Id;
                    entity.First_Name = model.FirstName;
                    entity.Last_Name = model.LastName;
                    entity.Other_Name = model.OtherName;
                    entity.Sex_Id = model.Sex.Id;
                    entity.Email = model.Email;
                    entity.Mobile_Phone = model.MobilePhone;
                    //entity.Date_Of_Birth = model.DateOfBirth;
              }
                return entity;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
