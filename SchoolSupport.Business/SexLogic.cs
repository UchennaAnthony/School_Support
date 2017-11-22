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
    public class SexLogic: BusinessBaseLogic<Sex, SEX>
    {
        public SexLogic()
        {
            base.translator = new SexTranslator();
        }
    }
}
