using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;  // for NotMapped

namespace Bookstore.Models
{
    public class User : IdentityUser
    {
        [NotMapped]
        public IList<string> RoleNames { get; set; } = null!;
    }
}
