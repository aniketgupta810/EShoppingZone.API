using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceWeb.API.Models
{
    #region Attributes for products
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string? Category { get; set; }

        
        [Required(ErrorMessage = "Prouct name can not be empty")]
        public string? ProductName { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ProductImage { get; set; }
    }
    #endregion
}
