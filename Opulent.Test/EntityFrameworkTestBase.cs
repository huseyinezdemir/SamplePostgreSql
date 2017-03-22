using NUnit.Framework;
using Opulent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opulent.Test
{

    public class EntityFrameworkTestBase
    {
        public virtual string DefaultConnectionString => "Server=localhost;User ID=postgres;Password=1234;Database=opulent";


        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            using (var context = new OpulentDataContext(DefaultConnectionString))
            {
                if (context.Database.Exists())
                    context.Database.Delete();//We delete to be 100% schema is synced
                context.Database.Create();
            }
        }
        [SetUp]
        public void SetUp()
        {
            using (var context = new OpulentDataContext(DefaultConnectionString))
            {
                context.Companies.RemoveRange(context.Companies);
                context.Persons.RemoveRange(context.Persons);
                context.SaveChanges();
            }
        }

    }
}
