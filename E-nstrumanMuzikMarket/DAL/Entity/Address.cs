using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
   public class Address
    {
        public int ID { get; set; }
        public string AddressName { get; set; }
        public virtual User User { get; set; }
        public virtual City City { get; set; }
        public virtual District District { get; set; }


    }
}
