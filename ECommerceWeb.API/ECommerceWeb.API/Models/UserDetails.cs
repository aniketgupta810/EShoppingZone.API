using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ECommerceWeb.API.Models
{
    #region For FirstTimeUsers on my website
    public class UserDetails
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string? Role { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [DataType("varchar(30)")]
        [Required(ErrorMessage = "Your Email Address should not be empty")]
        public string? EmailId { get; set; }

        [Required(ErrorMessage = "Your Mobile number should not be empty")]
        public string? MobileNumber { get; set; }

        [Required]
        public string? AddressInfo { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public string? UserState { get; set; }

        [Required]
        public string? Pincode { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        public string? Password { get; set; }

        [Required]
        public bool IsLogin { get; set; } = false;

    }
    #endregion
}
