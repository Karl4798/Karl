using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACME.Data.ViewModels
{

    // View Model used to define fields for user roles (which users are assigned to which roles)
    public class UserRoleViewModel
    {
        [DisplayName("User ID")]
        public string UserId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool IsSelected { get; set; }

    }
}
