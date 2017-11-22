using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;

namespace SchoolSupport.Model.Translator
{
    public class RoleTranslator : TranslatorBase<Role, ROLE>
    {
      public override Role TranslateToModel(ROLE roleEntity)
        {
            try
            {
                Role role = null;
                if (roleEntity != null)
                {
                    role = new Role();
                    role.Id = roleEntity.Role_Id;
                    role.Name = roleEntity.Role_Name;
                     }

                return role;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override ROLE TranslateToEntity(Role role)
        {
            try
            {
                ROLE roleEntity = null;
                if (role != null)
                {
                    roleEntity = new ROLE();
                    roleEntity.Role_Id = role.Id;
                    roleEntity.Role_Name = role.Name;
                }

                return roleEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
