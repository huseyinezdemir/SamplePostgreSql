using NUnit.Framework;
using Opulent.Data;
using Opulent.Model.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Opulent.Test
{
    public class EfCrudTest : EntityFrameworkTestBase
    {
        [Test]
        public void InsertAndSelect()
        {
            using (var context = new OpulentDataContext(DefaultConnectionString))
            {

                var company = new Company()
                {
                    Name = "Nuevo Software"
                };
                company.Persons = new List<Person>() {
                    new Person {
                        FirstName="Huseyin",
                        LastName="Ozdemir"
                    }
                };

                context.Companies.Add(company);
                context.SaveChanges();
            }

            using (var context = new OpulentDataContext(DefaultConnectionString))
            {

                var company = context.Companies.ToList();
                Assert.AreEqual(company.Count, 1);
            }
        }
    }
}
