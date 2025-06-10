using Microsoft.AspNetCore.Identity;

namespace Domain.Entity

{
    public class User : IdentityUser
    {
        public String? Avatar { get; set; }
        public bool AccountConfirmed { get; set; }
    }
}
 


