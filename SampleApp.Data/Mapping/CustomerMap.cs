using SampleApp.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Data.Mapping
{
    public partial class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.ToTable("Customer");
            this.HasKey(c => c.CustomerId);
            this.HasMany(c => c.Roles)
                .WithMany()
                .Map(c => c.ToTable("Customer_Roles_Mapping"));
            this.Property(u => u.CustomerName).HasMaxLength(500);
        }
    }
}
