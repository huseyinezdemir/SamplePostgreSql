using Npgsql;
using Opulent.Model.Domain;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;

namespace Opulent.Data
{
    public class OpulentDataContext : DbContext
    {
        public OpulentDataContext(string connectionString)
            : base(new NpgsqlConnection(connectionString), CreateModel(new NpgsqlConnection(connectionString)), true)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies { get; set; }

        private static DbCompiledModel CreateModel(NpgsqlConnection connection)
        {
            var dbModelBuilder = new DbModelBuilder(DbModelBuilderVersion.Latest);

            //dbModelBuilder.Entity<Company>();
            //vs
            //this
            Assembly domainAssembly = typeof(Person).Assembly;
            var entities = domainAssembly.GetTypes().Where(x => x.IsClass && x.BaseType == typeof(BaseEntity));
            foreach (var entity in entities)
            {
                dbModelBuilder.RegisterEntityType(entity);
            }



            var dbModel = dbModelBuilder.Build(connection);


            var compiledModel = dbModel.Compile();

            return compiledModel;

        }

    }
}
