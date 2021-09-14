using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TechSupport_App.Models
{
    public partial class Technician
    {
        public Technician()
        {
            Incidents = new HashSet<Incident>();
        }

        [Key]
        [Column("TechID")]
        public int TechId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [InverseProperty(nameof(Incident.Tech))]
        public virtual ICollection<Incident> Incidents { get; set; }
    }
}
