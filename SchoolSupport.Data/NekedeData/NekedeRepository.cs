//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Linq.Expressions;
//using System.Data.Entity;
//using SchoolSupport.Model.Entity;


//namespace SchoolSupport.Data.NekedeData
//{
//    public class NekedeRepository : NekedeIRepository, IDisposable
//    {
//        private bool disposed = false;
//        public Abundance_Nk_NekedeEntities context;

//        public NekedeRepository() : this(new Abundance_Nk_NekedeEntities()) { }

//        public NekedeRepository(Abundance_Nk_NekedeEntities _context)
//        {
//            context = _context;
//        }

//        public long GetCount<E>(Func<E, bool> match) where E : class
//        {
//            try
//            {
//                long count = 0;
//                DbSet<E> es = context.Set<E>();
//                if (es != null && es.LongCount() > 0)
//                {
//                    count = context.Set<E>().LongCount(match);
//                }

//                return count;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public long GetMaxValueBy<E>(Func<E, long> match) where E : class
//        {
//            try
//            {
//                long maximum = 0;
//                DbSet<E> es = context.Set<E>();
//                if (es != null && es.Count() > 0)
//                {
//                    maximum = context.Set<E>().Max(match);
//                }

//                return maximum;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public int GetMaxValueBy<E>(Func<E, int> match) where E : class
//        {
//            try
//            {
//                int maximum = 0;
//                DbSet<E> es = context.Set<E>();
//                if (es != null && es.Count() > 0)
//                {
//                    maximum = context.Set<E>().Max(match);
//                }

//                return maximum;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public ICollection<E> GetAll<E>() where E : class
//        {
//            try
//            {
//                return context.Set<E>().ToList();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public E GetBy<E>(object id) where E : class
//        {
//            try
//            {
//                return context.Set<E>().Find(id);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public E GetSingleBy<E>(Expression<Func<E, bool>> match) where E : class
//        {
//            try
//            {
//                return context.Set<E>().SingleOrDefault(match);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public ICollection<E> FindAll<E>(Expression<Func<E, bool>> match) where E : class
//        {
//            try
//            {
//                return context.Set<E>().Where(match).ToList();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public ICollection<E> GetBy<E>(Expression<Func<E, bool>> filter = null, Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null, string includeProperties = "") where E : class
//        {
//            try
//            {
//                IQueryable<E> query = context.Set<E>();
//                if (filter != null)
//                {
//                    query = query.Where(filter);
//                }

//                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
//                {
//                    query = query.Include(includeProperty);
//                }

//                if (orderBy != null)
//                {
//                    return orderBy(query).ToList();
//                }
//                else
//                {
//                    return query.ToList();
//                }
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public E Add<E>(E e) where E : class
//        {
//            try
//            {
//                E newE = context.Set<E>().Add(e);
//                return newE;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public int Add<E>(ICollection<E> es) where E : class
//        {
//            try
//            {
//                foreach (E e in es)
//                {
//                    context.Set<E>().Add(e);
//                }

//                return es.Count;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//         protected virtual void Dispose(bool disposing)
//        {
//            if (!this.disposed)
//            {
//                if (disposing)
//                {
//                    context.Dispose();
//                }
//            }

//            this.disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//    }
    
//}
