using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;

namespace SchoolSupport.Model.Translator
{
    public class UserTranslator:TranslatorBase<User, USER>
    {
         private RoleTranslator roleTranslator;
        private SecurityQuestionTranslator securityQuestionTranslator;
        private PersonTranslator personTranslator;
        public UserTranslator()
        {
            roleTranslator = new RoleTranslator();
            securityQuestionTranslator = new SecurityQuestionTranslator();
            personTranslator = new PersonTranslator();
        }

        public override User TranslateToModel(USER entity)
        {
            try
            {
                User model = null;
                if (entity != null)
                {
                    model = new User();
                    model.Id = entity.User_Id;
                    model.Username = entity.User_Name;
                    model.Password = entity.Password;
                    model.Email = entity.Email;
                    model.SecurityQuestion = securityQuestionTranslator.Translate(entity.SECURITY_QUESTION);
                    model.SecurityAnswer = entity.Security_Answer;
                    model.Role = roleTranslator.Translate(entity.ROLE);
                    model.LastLoginDate = entity.LastLoginDate;
                    model.Person = personTranslator.Translate(entity.PERSON);
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override USER TranslateToEntity(User model)
        {
            try
            {
                USER entity = null;
                if (model != null)
                {
                    entity = new USER();
                    entity.User_Id = model.Id;
                    entity.User_Name = model.Username;
                    entity.Password = model.Password;
                    entity.Email = model.Email;
                    entity.Security_Question_Id = model.SecurityQuestion.Id;
                    entity.Security_Answer = model.SecurityAnswer;
                    entity.Role_Id = model.Role.Id;
                    entity.LastLoginDate = model.LastLoginDate;
                    entity.Person_Id = model.Person.Id;
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
