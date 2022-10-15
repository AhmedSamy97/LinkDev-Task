using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Models
{
    public class Product
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public int Discount { get; set; }
        [Required(ErrorMessage = "Select category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Categories = null;
        [NotMapped]
        public int Quantity = 1;

    }
}
