using SampleApp.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Data.Mapping
{
    public partial class CustomerAddressMap : EntityTypeConfiguration<CustomerAddress>
    {
        public CustomerAddressMap()
        {
            this.ToTable("CustomerAddress");
            this.HasKey(c => c.AddressId);
            this.Property(bp => bp.Address1).IsRequired();
            this.Property(bp => bp.Address2).IsRequired().IsMaxLength();
            this.Property(bp => bp.City).IsRequired().HasMaxLength(400);
            this.HasRequired(bp => bp.Customer)
                .WithMany()
                .HasForeignKey(bp => bp.CustomerId).WillCascadeOnDelete(true);
        }
    }
}
