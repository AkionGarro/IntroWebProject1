using Microsoft.AspNetCore.Authorization;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace project_web.Models.Roles
{
    [Keyless]
    public class RolesModel
    {

        public string? RoleName { get; set; }

    }
}
