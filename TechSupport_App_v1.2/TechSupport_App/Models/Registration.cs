using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TechSupport_App.Models
{
    public partial class Registration
    {
        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Key]
        [StringLength(10)]
        public string ProductCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RegistrationDate { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Registrations")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(ProductCode))]
        [InverseProperty(nameof(Product.Registrations))]
        public virtual Product ProductCodeNavigation { get; set; }
    }
}
