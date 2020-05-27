using System.Collections.Generic;
using System.Linq;
using triluatsoft.tls.EntityFramework;
using triluatsoft.tls.HNH.People;
using triluatsoft.tls.HNH.Phones;

namespace triluatsoft.tls.Migrations.Seed.Tenants.HNH
{
    class InitialPeopleAndPhoneCreator
    {
        private readonly tlsDbContext _context;

        public InitialPeopleAndPhoneCreator(tlsDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var douglas = _context.Persons.FirstOrDefault(p => p.EmailAddress == "douglas.adams@fortytwo.net");
            if (douglas == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Douglas2",
                        Surname = "Adams",
                        EmailAddress = "douglas.adams@fortytwo.net",
                        Phones = new List<Phone>
                                    {
                                    new Phone {Type = PhoneType.Home, Number = "1112242"},
                                    new Phone {Type = PhoneType.Mobile, Number = "2223342"}
                                    }
                    });
            }

            var asimov = _context.Persons.FirstOrDefault(p => p.EmailAddress == "isaac.asimov@foundation.com");
            if (asimov == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Isaac2",
                        Surname = "Asimov",
                        EmailAddress = "isaac.asimov@foundation.com",
                        Phones = new List<Phone>
                                    {
                                    new Phone {Type = PhoneType.Home, Number = "8889977"}
                                    }
                    });
            }
        }
    }
}
