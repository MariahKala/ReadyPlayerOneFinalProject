using Microsoft.AspNetCore.Identity;

namespace ReadyPlayerOne.Models.ViewModel
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; } = null!;
        public IEnumerable<IdentityRole> Roles { get; set; } = null!;

    }
}

