using CustomerService_PSR.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CustomerService_PSR.Models
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            //Database.Log = sql => Debug.Write(sql);
            this.Database.CommandTimeout = 120;
            this.Configuration.LazyLoadingEnabled = false;
        }
        public override int SaveChanges()
        {
            Guid? guidUserID = IdentityUtilities.GetUserID(HttpContext.Current.User.Identity);
            string strUserFullName = IdentityUtilities.GetFullName(HttpContext.Current.User.Identity);
            string strUserDomainName = HttpContext.Current.User.Identity.Name;

            MySaveChanges(guidUserID, strUserFullName, strUserDomainName);

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            Guid? guidUserID = IdentityUtilities.GetUserID(HttpContext.Current.User.Identity);
            string strUserFullName = IdentityUtilities.GetFullName(HttpContext.Current.User.Identity);
            string strUserDomainName = HttpContext.Current.User.Identity.Name;

            MySaveChanges(guidUserID, strUserFullName, strUserDomainName);

            return base.SaveChangesAsync();
        }

        private void MySaveChanges(Guid? guidUserID, string strUserFullName, string strUserDomainName)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        {
                            MyInsert(entry, guidUserID, strUserFullName, strUserDomainName);
                            break;
                        }
                    case EntityState.Modified:
                        {
                            MyUpdate(entry, guidUserID, strUserFullName, strUserDomainName);
                            break;
                        }
                    case EntityState.Deleted:
                        {
                            MySoftDelete(entry, guidUserID, strUserFullName, strUserDomainName);
                            break;
                        }
                }
            }
        }

        private void MyInsert(DbEntityEntry entry, Guid? guidUserID, string strUserFullName, string strUserDomainName)
        {
            entry.Property("AdmIsActive").CurrentValue = "Y";
            entry.Property("AdmDateAdded").CurrentValue = DateTime.Now;
            entry.Property("AdmUserAdded").CurrentValue = guidUserID;
            entry.Property("AdmUserAddedFullName").CurrentValue = strUserFullName;
            entry.Property("AdmUserAddedDomainName").CurrentValue = strUserDomainName;

            entry.Property("AdmDateModified").IsModified = false;
            entry.Property("AdmUserModified").IsModified = false;
            entry.Property("AdmUserModifiedFullName").IsModified = false;
            entry.Property("AdmUserModifiedDomainName").IsModified = false;
        }

        private void MyUpdate(DbEntityEntry entry, Guid? guidUserID, string strUserFullName, string strUserDomainName)
        {
            entry.Property("AdmDateAdded").IsModified = false;
            entry.Property("AdmUserAdded").IsModified = false;
            entry.Property("AdmUserAddedFullName").IsModified = false;
            entry.Property("AdmUserAddedDomainName").IsModified = false;

            entry.Property("AdmDateModified").CurrentValue = DateTime.Now;
            entry.Property("AdmUserModified").CurrentValue = guidUserID;
            entry.Property("AdmUserModifiedFullName").CurrentValue = strUserFullName;
            entry.Property("AdmUserModifiedDomainName").CurrentValue = strUserDomainName;
        }

        private void MySoftDelete(DbEntityEntry entry, Guid? guidUserID, string strUserFullName, string strUserDomainName)
        {
            Type entryEntityType = entry.Entity.GetType();

            string tableName = GetTableName(entryEntityType);
            string primaryKeyName = GetPrimaryKeyName(entryEntityType);

            string deletequery =
                string.Format(
                    "UPDATE {0} " +
                    "SET AdmIsActive = 'N', " +
                    "    AdmDateModified = @AdmDateModified, " +
                    "    AdmUserModified = @AdmUserModified, " +
                    "    AdmUserModifiedFullName = @AdmUserModifiedFullName, " +
                    "    AdmUserModifiedDomainName = @AdmUserModifiedDomainName " +
                    "WHERE {1} = @id",
                    tableName, primaryKeyName);

            Database.ExecuteSqlCommand(
                deletequery,
                new SqlParameter("@id", entry.OriginalValues[primaryKeyName]),
                new SqlParameter("@AdmDateModified", DateTime.Now),
                new SqlParameter("@AdmUserModified", guidUserID),
                new SqlParameter("@AdmUserModifiedFullName", strUserFullName),
                new SqlParameter("@AdmUserModifiedDomainName", strUserDomainName));

            //Marking it Unchanged prevents the hard delete
            //entry.State = EntityState.Unchanged;
            //So does setting it to Detached:
            //And that is what EF does when it deletes an item
            //http://msdn.microsoft.com/en-us/data/jj592676.aspx
            entry.State = EntityState.Detached;
        }

        private static Dictionary<Type, EntitySetBase> _mappingCache =
           new Dictionary<Type, EntitySetBase>();

        private EntitySetBase GetEntitySet(Type type)
        {
            if (!_mappingCache.ContainsKey(type))
            {
                ObjectContext octx = ((IObjectContextAdapter)this).ObjectContext;

                string typeName = ObjectContext.GetObjectType(type).Name;

                var es = octx.MetadataWorkspace
                                .GetItemCollection(DataSpace.SSpace)
                                .GetItems<EntityContainer>()
                                .SelectMany(c => c.BaseEntitySets
                                                .Where(e => e.Name == typeName))
                                .FirstOrDefault();

                if (es == null)
                    throw new ArgumentException("Entity type not found in GetTableName", typeName);

                _mappingCache.Add(type, es);
            }

            return _mappingCache[type];
        }

        private string GetTableName(Type type)
        {
            EntitySetBase es = GetEntitySet(type);

            return string.Format("[{0}].[{1}]",
                es.MetadataProperties["Schema"].Value,
                es.MetadataProperties["Table"].Value);
        }

        private string GetPrimaryKeyName(Type type)
        {
            EntitySetBase es = GetEntitySet(type);

            return es.ElementType.KeyMembers[0].Name;
        }
    }
}