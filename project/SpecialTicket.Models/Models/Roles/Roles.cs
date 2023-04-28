using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SpecialTicket.Models.Models.Roles
{
    [Keyless]
    public class RolesModel
    {

        public string? RoleName { get; set; }

    }
}
