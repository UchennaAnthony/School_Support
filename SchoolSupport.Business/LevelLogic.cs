using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSupport.Data;
using SchoolSupport.Model.Entity;
using SchoolSupport.Model.Model;
using SchoolSupport.Model.Translator;
using System.Linq.Expressions;


namespace SchoolSupport.Business
{
    public class LevelLogic : BusinessBaseLogic<Level, LEVEL>
    {
        public LevelLogic()
        {
            translator = new LevelTranslator();
        }
    }
}
