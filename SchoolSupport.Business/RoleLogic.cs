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
    public class RoleLogic: BusinessBaseLogic<Role, ROLE>
    {
       
        public bool Modify(Role role)
        {
            try
            {
                Expression<Func<ROLE, bool>> selector = r => r.Role_Id == role.Id;
                ROLE roleEntity = GetEntityBy(selector);
                roleEntity.Role_Name = role.Name;
                

                int rowsAffected = repository.Save();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception(NoItemModified);
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Role role)
        {
            try
            {
                Func<ROLE, bool> selector = r => r.Role_Id == role.Id;
                bool suceeded = base.Delete(selector);

                base.repository.Save();
                return suceeded;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
