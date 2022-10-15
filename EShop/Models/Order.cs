using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Models
{
    public class Order
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal OldPrice { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal ActualPrice { get; set; }
        public int Discount { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
