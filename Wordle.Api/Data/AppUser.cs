using Microsoft.AspNetCore.Identity;

namespace Wordle.Api.Data
{
    public class AppUser : IdentityUser
    {
        public DateTime DOB { get; set; }
    }
}