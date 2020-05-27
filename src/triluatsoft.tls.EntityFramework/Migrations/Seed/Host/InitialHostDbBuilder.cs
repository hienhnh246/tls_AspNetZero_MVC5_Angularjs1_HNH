using triluatsoft.tls.EntityFramework;
using triluatsoft.tls.Migrations.Seed.Tenants.HNH;

namespace triluatsoft.tls.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly tlsDbContext _context;

        public InitialHostDbBuilder(tlsDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            new InitialPeopleCreator(_context).Create();
            new InitialPeopleAndPhoneCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
