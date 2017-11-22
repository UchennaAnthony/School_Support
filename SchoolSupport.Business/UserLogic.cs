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
    public class UserLogic: BusinessBaseLogic<User, USER>
    {
        public UserLogic()
        {
            translator = new UserTranslator();
        }

        public bool ValidateUser(string Username, string Password)
        {
            try
            {
                Expression<Func<USER, bool>> selector = p => p.User_Name == Username && p.Password == Password;
                User UserDetails = GetModelBy(selector);
                if (UserDetails != null && UserDetails.Password != null)
                {
                    UpdateLastLogin(UserDetails);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public bool UpdateLastLogin(User user)
        {
            try
            {
                Expression<Func<USER, bool>> selector = p => p.User_Name == user.Username && p.Password == user.Password;
                USER userEntity = GetEntityBy(selector);
                if (userEntity == null || userEntity.User_Id <= 0)
                {
                    throw new Exception(NoItemFound);
                }

                userEntity.User_Name = user.Username;
                userEntity.Password = user.Password;
                userEntity.Email = user.Email;
                userEntity.Role_Id = user.Role.Id;
                userEntity.Security_Question_Id = user.SecurityQuestion.Id;
                userEntity.Security_Answer = user.SecurityAnswer;
                userEntity.LastLoginDate = DateTime.Now;
                userEntity.Person_Id = user.Person.Id;

                int modifiedRecordCount = Save();
                if (modifiedRecordCount <= 0)
                {
                    throw new Exception(NoItemModified);
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
        }

        public bool ChangeUserPassword(User user)
        {
            try
            {
                Expression<Func<USER, bool>> selector = p => p.User_Name == user.Username;
                USER userEntity = GetEntityBy(selector);
                if (userEntity == null || userEntity.User_Id <= 0)
                {
                    throw new Exception(NoItemFound);
                }

                userEntity.User_Name = user.Username;
                userEntity.Password = user.Password;
                userEntity.Email = user.Email;
                userEntity.Role_Id = user.Role.Id;
                userEntity.Security_Question_Id = user.SecurityQuestion.Id;
                userEntity.Security_Answer = user.SecurityAnswer;
                userEntity.LastLoginDate = user.LastLoginDate;
                userEntity.Person_Id = user.Person.Id;
                int modifiedRecordCount = Save();
                if (modifiedRecordCount <= 0)
                {
                    throw new Exception(NoItemModified);
                }

                return true;


            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
        }
        public User Update(User model)
        {
            try
            {
                Expression<Func<USER, bool>> selector = a => a.User_Id == model.Id;
                USER entity = GetEntityBy(selector);

                entity.User_Name = model.Username;
                entity.Password = model.Password;
                entity.Email = model.Email;
                if (model.Role != null)
                {
                    entity.Role_Id = model.Role.Id;
                }
                entity.Security_Answer = model.SecurityAnswer;
                if (model.SecurityQuestion != null && model.SecurityQuestion.Id > 0)
                {
                    entity.Security_Question_Id = model.SecurityQuestion.Id;
                }
                entity.Person_Id = model.Person.Id;
                //entity.Person_Id = model.Person.Id;
               
                int modifiedRecordCount = Save();
                if (modifiedRecordCount <= 0)
                {
                    throw new Exception(NoItemModified);
                }

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Modify(User model)
        {
            try
            {
                Expression<Func<USER, bool>> selector = u => u.User_Id == model.Id;
                USER entity = GetEntityBy(selector);
                if (entity == null)
                {
                    throw new Exception(NoItemFound);
                }

                if (model.Password != null)
                {
                    entity.Password = model.Password;
                }

                if (model.Role != null)
                {
                    entity.Role_Id = model.Role.Id;
                }
                entity.Person_Id = model.Person.Id;
               
                int modifiedRecordCount = Save();
                if (modifiedRecordCount <= 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
}
