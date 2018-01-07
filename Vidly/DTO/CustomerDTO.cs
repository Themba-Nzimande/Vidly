using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTO
{
    
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fam enter a name please")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDTO MembershipType { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}