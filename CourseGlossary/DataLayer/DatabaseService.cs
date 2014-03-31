using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ServiceStack;
using ServiceStack.OrmLite;

namespace CourseGlossary.DataLayer
{
    public class DatabaseService
    {
        public static IList<T> GetAll<T>()
        {
            using (IDbConnection db = MvcApplication.DbFactory.OpenDbConnection())
            {
                return db.Select<T>();
            }
        }
        public static IList<T> GetAll<T,TKey>(Func<T,TKey> orderByClause)
        {
            using (IDbConnection db = MvcApplication.DbFactory.OpenDbConnection())
            {
                return db.Select<T>().OrderBy(orderByClause).ToList();
            }
        }
        public static IList<T> GetAll<T>(Func<T, bool> predicate)
        {
            using (IDbConnection db = MvcApplication.DbFactory.OpenDbConnection())
            {
                return db.Select<T>().Where(predicate).ToList();
            }
        }

        public static void Create<T>(T value)
        {
            using (IDbConnection db = MvcApplication.DbFactory.OpenDbConnection())
            {
                db.Insert(value);
            }
        }

        public static T Get<T>(List<int> ids)
        {
            using (IDbConnection db = MvcApplication.DbFactory.OpenDbConnection())
            {
                return db.SelectByIds<T>(ids).FirstOrDefault();
            }
        }

        public static void Update<T>(T value)
        {
            using (IDbConnection db = MvcApplication.DbFactory.OpenDbConnection())
            {
                db.Update(value);
            }
        }
    }
}