using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
   public class User
    {
		public int ID { get; set; }

		[MaxLength(25)]
		public string Name { get; set; }
		[MaxLength(25)]
		public string Surname { get; set; }
		[MaxLength(25)]
		public string Username { get; set; }

		public string Password { get; set; }//123
		
		public string Email { get; set; }
		[MaxLength(255)]
		
		public string PhoneNumber { get; set; }
		[MaxLength(255)]
		public string ImagePath { get; set; }
		public DateTime? BirthDate { get; set; }
		
		public virtual List<Address> Addresses { get; set; }
		
	}
}
