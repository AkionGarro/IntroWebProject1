using System;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace project_web.Models.Roles
{
    public class EditRoles
    {
        public EditRoles()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Role name is required")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }


    }
}
