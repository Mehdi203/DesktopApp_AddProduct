using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TechSupport_App.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Incidents = new HashSet<Incident>();
            Registrations = new HashSet<Registration>();
        }

        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(20)]
        public string City { get; set; }
        [Required]
        [StringLength(2)]
        public string State { get; set; }
        [Required]
        [StringLength(9)]
        public string ZipCode { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        [ForeignKey(nameof(State))]
        [InverseProperty("Customers")]
        public virtual State StateNavigation { get; set; }
        [InverseProperty(nameof(Incident.Customer))]
        public virtual ICollection<Incident> Incidents { get; set; }
        [InverseProperty(nameof(Registration.Customer))]
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
