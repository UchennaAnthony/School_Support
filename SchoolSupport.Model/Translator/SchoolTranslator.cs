using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;


namespace SchoolSupport.Model.Translator
{
    public class SchoolTranslator: TranslatorBase<School, SCHOOL>
    {

        public override School TranslateToModel(SCHOOL entity)
        {
            try
            {
                School model = null;
                if (entity != null)
                {
                    model = new School();
                    model.Id = entity.School_Id;
                    model.SchoolName = entity.School_Name;
                    model.ShortCode = entity.School_Short_Code;
                } 
                return model;
                }
            catch (Exception)
            {
                throw;
            }
        }

        public override SCHOOL TranslateToEntity(School model)
        {
            try
            {
                SCHOOL entity = null;
                if (model != null)
                {
                    entity = new SCHOOL();
                    entity.School_Id = model.Id;
                    entity.School_Name = model.SchoolName;
                    entity.School_Short_Code = model.ShortCode;
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
