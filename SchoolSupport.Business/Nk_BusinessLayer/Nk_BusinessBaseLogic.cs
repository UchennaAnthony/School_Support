//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Linq.Expressions;
//using SchoolSupport.Model.Entity;
//using SchoolSupport.Data;
//using SchoolSupport.Data.NekedeData;

//namespace SchoolSupport.Business.Nk_BusinessLayer
//{
//    public abstract class Nk_BusinessBaseLogic<E> : IDisposable where E : class
//    {
//        //protected TranslatorBase<T, E> translator;
//        protected IRepository repository = new Repository();

//        protected Abundance_Nk_NekedeEntities context;

//        protected const string ArgumentNullException = "Null object argument. Please contact your system administrator";
//        protected const string UpdateException = "Operation failed due to update errors!";
//        protected const string NoItemModified = "No Changes made!";
//        protected const string NoItemFound = "No Changes found to modified!";
//        protected const string NoItemRemoved = "No item deleted!";
//        protected const string ErrowDuringProccesing = "Error Occurred During Processing.";

//        public virtual E GetModelBy(Expression<Func<E, bool>> selector = null)
//        {
//            try
//            {
//                E entity = repository.GetSingleBy(selector);
//                return(entity);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public virtual List<E> GetModelsBy(Expression<Func<E, bool>> selector = null, Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null, string includeProperties = "")
//        {
//            try
//            {
//                List<E> entity = repository.GetBy(selector, orderBy, includeProperties).ToList();
//                return (entity);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public virtual E GetEntityBy(Expression<Func<E, bool>> selector)
//        {
//            try
//            {
//                return repository.GetSingleBy(selector);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public virtual List<E> GetEntitiesBy(Expression<Func<E, bool>> selector = null, Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null, string includeProperties = "")
//        {
//            try
//            {
//                return repository.GetBy(selector, orderBy, includeProperties).ToList();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public virtual List<E> GetAll()
//        {
//            try
//            {
//                List<E> entities = repository.GetAll<E>().ToList();
//                return (entities);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

 
//        ////public bool Delete(Expression<Func<E, bool>> selector)
//        ////{
//        ////    try
//        ////    {
//        ////        repository.Delete(selector);
//        ////        return Save() > 0 ? true : false;
//        ////    }
//        ////    catch (Exception)
//        ////    {
//        ////        throw;
//        ////    }
//        ////}

//        ////public bool Delete(object id)
//        ////{
//        ////    try
//        ////    {
//        ////        repository.Delete(id);
//        ////        return Save() > 0 ? true : false;
//        ////    }
//        ////    catch (Exception)
//        ////    {
//        ////        throw;
//        ////    }
//        ////}

//        ////public int Save()
//        ////{
//        ////    return repository.Save();
//        ////}

//        ////public void Dispose()
//        ////{
//        ////    Dispose(true);
//        ////    GC.SuppressFinalize(this);
//        ////}

//        protected virtual void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                if (repository != null)
//                {
//                    repository.Dispose();
//                    repository = null;
//                }
//            }
//        }

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
