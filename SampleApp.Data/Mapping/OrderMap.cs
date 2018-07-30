using SampleApp.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Data.Mapping
{
    public partial class OrderMap : EntityTypeConfiguration<Orders>
    {
        public OrderMap()
        {
            this.ToTable("Orders");
            this.HasKey(c => c.OrderId);
            this.Property(c => c.OrderDate).IsRequired();
            this.Property(c => c.IsShiped).IsOptional();
            this.HasRequired(c => c.Customer)
                .WithMany()
                .HasForeignKey(c=>c.CustomerId).WillCascadeOnDelete(true);
        }
        
    }
}
