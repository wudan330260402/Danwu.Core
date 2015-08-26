using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp
{
    public class DemoDBContext : DbContext
    {
        static DemoDBContext() {
            //Database.SetInitializer<DemoDBContext>(null);
            Database.SetInitializer<DemoDBContext>(new CreateDatabaseIfNotExists<DemoDBContext>());
        }

        public DemoDBContext()
            : base("DemoDB")
        { }

        public DbSet<Person> Person {
            get { return this.Set<Person>(); }
        }
    
    
    }

    public class Person {
        public String ID { get; set; }
        public String UserName { get; set; }
    }
}
