using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
   public class City
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
        public virtual List<District> Districts { get; set; }

    }
}
