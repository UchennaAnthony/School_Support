using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;

namespace SchoolSupport.Model.Translator
{
    public class ProgrammeTranslator : TranslatorBase<Programme, PROGRAMME>
    {
        public override Programme TranslateToModel(PROGRAMME entity)
        {
            try
            {
                Programme programme = null;
                if (entity != null)
                {
                    programme = new Programme();
                    programme.Id = entity.Programme_Id;
                    programme.Name = entity.Programme_Name;
                    programme.Description = entity.Programme_Description;
                    programme.ShortName = entity.Programme_Short_Name;
                    programme.Activated = entity.Activated;
                }

                return programme;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override PROGRAMME TranslateToEntity(Programme programme)
        {
            try
            {
                PROGRAMME entity = null;
                if (programme != null)
                {
                    entity = new PROGRAMME();
                    entity.Programme_Id = programme.Id;
                    entity.Programme_Name = programme.Name;
                    entity.Programme_Description = programme.Description;
                    entity.Programme_Short_Name = programme.ShortName;
                    entity.Activated = programme.Activated;
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
