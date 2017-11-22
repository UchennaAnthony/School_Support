using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;
using SchoolSupport.Model.Translator;

namespace SchoolSupport.Business
{
    public class SecurityQuestionLogic : BusinessBaseLogic<SecurityQuestion, SECURITY_QUESTION>
    {
        public SecurityQuestionLogic()
        {
            translator = new SecurityQuestionTranslator();
        }

    }
}
