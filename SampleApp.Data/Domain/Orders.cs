using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Data.Domain
{
    public class Orders 
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsShiped { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
