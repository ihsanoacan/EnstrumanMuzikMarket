using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
   public class District
    {
        public int ID { get; set; }
        public string DistrictName { get; set; }
        public bool IsActive { get; set; }
        public virtual City City { get; set; }
    }
}
