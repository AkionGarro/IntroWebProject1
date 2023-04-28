using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SpecialTicket.Models.Models
{
    // Add profile data for application users by adding properties to the project_ticketUser class
    public class project_ticketUser : IdentityUser
        
    {
        public virtual ICollection<Compra> Compras { get; } = new List<Compra>();
    }
}
