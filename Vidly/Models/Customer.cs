using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Using statement below gives access to the required thing
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fam enter a name please")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}