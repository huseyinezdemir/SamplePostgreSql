using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opulent.Model.Domain
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }

    public class Company : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Person> Persons { get; set; }

    }

    public class BaseEntity
    {
        public int Id { get; set; }
    }
}
