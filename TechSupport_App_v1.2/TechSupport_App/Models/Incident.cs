using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TechSupport_App.Models
{
    public partial class Incident
    {
        [Key]
        [Column("IncidentID")]
        public int IncidentId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(10)]
        public string ProductCode { get; set; }
        [Column("TechID")]
        public int? TechId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOpened { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateClosed { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Incidents")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(ProductCode))]
        [InverseProperty(nameof(Product.Incidents))]
        public virtual Product ProductCodeNavigation { get; set; }
        [ForeignKey(nameof(TechId))]
        [InverseProperty(nameof(Technician.Incidents))]
        public virtual Technician Tech { get; set; }
    }
}
