using System.Linq;
using triluatsoft.tls.EntityFramework;
using triluatsoft.tls.HNH.People;

namespace triluatsoft.tls.Migrations.Seed.Tenants.HNH
{
    public class InitialPeopleCreator
    {
        private readonly tlsDbContext _context;

        public InitialPeopleCreator(tlsDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var douglas = _context.Persons.FirstOrDefault(p => p.EmailAddress == "douglas.adams@fortytwo.com");
            if (douglas == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        TenantId = 1,
                        Name = "Douglas",
                        Surname = "Adams",
                        EmailAddress = "douglas.adams@fortytwo.com"
                    });
            }

            var asimov = _context.Persons.FirstOrDefault(p => p.EmailAddress == "isaac.asimov@foundation.org");
            if (asimov == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        TenantId = 1,
                        Name = "Isaac",
                        Surname = "Asimov",
                        EmailAddress = "isaac.asimov@foundation.org"
                    });
            }
        }
    }
}
