using System;

namespace triluatsoft.tls.HNH.People
{
    public interface IPerson
    {
        string Name { get; set; }

        string Surname { get; set; }

        DateTime? Birth { get; set; }

        Gender Gender { get; set; }

        string PhoneNumber { get; set; }

        string EmailAddress { get; set; }
    }
}
