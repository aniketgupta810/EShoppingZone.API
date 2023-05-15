using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.API.Models
{
    #region LoginModel
    public class LogInModel
    {
        [Required(ErrorMessage = "Email can not be empty")]
        [Key]
        public string? EmailId { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        public string? Password { get; set; }
    }
    #endregion
}
