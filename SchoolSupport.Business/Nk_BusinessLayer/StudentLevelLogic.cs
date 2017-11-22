//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SchoolSupport.Model.Entity;
//using SchoolSupport.Model.Model;
//using SchoolSupport.Model.Translator;
//using System.Linq.Expressions;
//using SchoolSupport.Business.Nk_BusinessLayer;

//namespace SchoolSupport.Business
//{
//    public class NKStudentLevelLogic : Nk_BusinessBaseLogic<STUDENT_LEVEL>
//    {
//        public STUDENT_LEVEL GetBy(long studentId)
//        {
//            try
//            {
//                Expression<Func<STUDENT_LEVEL, bool>> selector = sl => sl.Person_Id == studentId ;
//                List<STUDENT_LEVEL> studentLevels = base.GetModelsBy(selector);

//                if (studentLevels != null && studentLevels.Count > 0)
//                {
//                    return studentLevels.LastOrDefault();
//                }

//                return null;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public STUDENT_LEVEL GetBy(Student student, Session session)
//        {
//            try
//            {
//                Expression<Func<STUDENT_LEVEL, bool>> selector = sl => sl.Person_Id == student.Id && sl.Session_Id == session.Id;
//                return base.GetModelBy(selector);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public List<STUDENT_LEVEL> GetBy(Level level, Programme programme, Department department, Session session)
//        {
//            try
//            {
//                Expression<Func<STUDENT_LEVEL, bool>> selector = sl => sl.Level_Id == level.Id && sl.Programme_Id == programme.Id && sl.Department_Id == department.Id && sl.Session_Id == session.Id;
//                return base.GetModelsBy(selector);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public List<STUDENT_LEVEL> GetBy(Level level, Session session)
//        {
//            try
//            {
//                Expression<Func<STUDENT_LEVEL, bool>> selector = sl => sl.Level_Id == level.Id && sl.Session_Id == session.Id;
//                return base.GetModelsBy(selector);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        ////public bool Modify(StudentLevel student)
//        ////{
//        ////    try
//        ////    {
//        ////        STUDENT_LEVEL model = GetBy(student.Student.Id);
//        ////        Expression<Func<STUDENT_LEVEL, bool>> selector = sl => sl.Level_Id == model.Level.Id && sl.Person_Id == model.Student.Id;
//        ////        STUDENT_LEVEL entity = GetEntityBy(selector);
//        ////        entity.Level_Id = student.Level.Id;
//        ////        if (student.Department != null)
//        ////        {
//        ////            entity.Department_Id = student.Department.Id;
//        ////        }
//        ////        if (student.Programme != null)
//        ////        {
//        ////            entity.Programme_Id = student.Programme.Id;
//        ////        }
//        ////        int modifiedRecordCount = Save();
//        ////        return true;
//        ////    }
//        ////    catch (Exception)
//        ////    {
//        ////        throw;
//        ////    }
//        ////}

//        ////public bool Modify(StudentLevel student, Person person)
//        ////{
//        ////    try
//        ////    {
//        ////        StudentLevel model = GetBy(person.Id);
//        ////        Expression<Func<STUDENT_LEVEL, bool>> selector = sl => sl.Level_Id == model.Level.Id && sl.Person_Id == model.Student.Id && sl.Session_Id == student.Session.Id;
//        ////        STUDENT_LEVEL entity = GetEntityBy(selector);

//        ////        entity.Level_Id = student.Level.Id;
//        ////        entity.Department_Id = student.Department.Id;
//        ////        if (student.DepartmentOption != null)
//        ////        {
//        ////            entity.Department_Option_Id = student.DepartmentOption.Id;
//        ////        }


//        ////        int modifiedRecordCount = Save();

//        ////        return true;
//        ////    }
//        ////    catch (Exception)
//        ////    {
//        ////        throw;
//        ////    }
//        ////}
//        ////public bool Modify(StudentLevel student, long studentLevelId)
//        ////{
//        ////    try
//        ////    {
//        ////        Expression<Func<STUDENT_LEVEL, bool>> selector = sl => sl.Student_Level_Id == studentLevelId && sl.Person_Id == student.Student.Id;
//        ////        STUDENT_LEVEL entity = GetEntityBy(selector);
//        ////        if (student.Level != null)
//        ////        {
//        ////            entity.Level_Id = student.Level.Id;
//        ////        }
//        ////        if (student.Session != null)
//        ////        {
//        ////            entity.Session_Id = student.Session.Id;
//        ////        }
//        ////        if (student.Department != null)
//        ////        {
//        ////            entity.Department_Id = student.Department.Id;
//        ////        }
//        ////        if (student.DepartmentOption != null)
//        ////        {
//        ////            entity.Department_Option_Id = student.DepartmentOption.Id;
//        ////        }
//        ////        if (student.Programme != null)
//        ////        {
//        ////            entity.Programme_Id = student.Programme.Id;
//        ////        }
//        ////        int modifiedRecordCount = Save();
//        ////        return true;
//        ////    }
//        ////    catch (Exception)
//        ////    {
//        ////        throw;
//        ////    }
//        ////}

//    }   
//}
