using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using triluatsoft.tls.Authorization.Roles;
using triluatsoft.tls.Authorization.Users;
using triluatsoft.tls.Chat;
using triluatsoft.tls.Friendships;
using triluatsoft.tls.MultiTenancy;
using triluatsoft.tls.Storage;

namespace triluatsoft.tls.EntityFramework
{
    /* Constructors of this DbContext is important and each one has it's own use case.
     * - Default constructor is used by EF tooling on design time.
     * - constructor(nameOrConnectionString) is used by ABP on runtime.
     * - constructor(existingConnection) is used by unit tests.
     * - constructor(existingConnection,contextOwnsConnection) can be used by ABP if DbContextEfTransactionStrategy is used.
     * See http://www.aspnetboilerplate.com/Pages/Documents/EntityFramework-Integration for more.
     */

    public class tlsDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }

        public tlsDbContext()
            : base("Default")
        {
            
        }

        public tlsDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public tlsDbContext(DbConnection existingConnection)
           : base(existingConnection, false)
        {

        }

        public tlsDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
