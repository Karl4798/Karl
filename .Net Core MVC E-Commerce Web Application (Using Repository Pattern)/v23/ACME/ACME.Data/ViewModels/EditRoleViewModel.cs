using System.Collections.Generic;
using System.ComponentModel;

namespace ACME.Data.ViewModels
{

    // View Model used to define fields for editing the user roles in the web application
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        [DisplayName("Role ID")]
        public string Id { get; set; }
        [DisplayName("Role Name")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
