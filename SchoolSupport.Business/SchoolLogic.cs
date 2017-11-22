using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSupport.Data;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;
using SchoolSupport.Model.Translator;


namespace SchoolSupport.Business
{
    public class SchoolLogic:BusinessBaseLogic<School, SCHOOL>
    {
        public SchoolLogic()
        {
            translator = new SchoolTranslator();
        }
    }
}
