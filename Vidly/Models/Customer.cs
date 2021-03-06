using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]

        public string Name { get; set; }

        public bool IsiSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }
        [Display(Name = "Menbership Type")]

        public byte MembershipTypeId { get; set; }

        [Display(Name = "Año de Nacimiento")]
        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }

    }
}