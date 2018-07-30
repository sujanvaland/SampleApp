using SampleApp.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Data.Mapping
{
    public partial class RoleMap : EntityTypeConfiguration<Roles>
    {
        public RoleMap()
        {
            this.ToTable("Roles");
            this.HasKey(r => r.RoleId);
            this.Property(r => r.RoleName).IsRequired().HasMaxLength(200);
        }
    }
}
