using SampleApp.Data.Domain;
using SampleApp.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Data
{
    public class SampleAppContext : DbContext 
    {
        public SampleAppContext() : base(ConfigurationManager.ConnectionStrings["sampleappconnection"].ToString())
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //var typesToRegister = from t in Assembly.GetExecutingAssembly().GetTypes()
            //                      where string.IsNullOrWhiteSpace(t.Namespace) &&
            //                            t.BaseType != null &&
            //                            t.BaseType.IsGenericType
            //                      let genericType = t.BaseType.GetGenericTypeDefinition()
            //                      where genericType == typeof(EntityTypeConfiguration<>) || genericType == typeof(ComplexTypeConfiguration<>)
            //                      select t;

            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}
            //...or do it manually below. For example,

            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new CustomerAddressMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new RoleMap());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    }
}
