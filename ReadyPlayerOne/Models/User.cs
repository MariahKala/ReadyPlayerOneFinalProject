﻿using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyPlayerOne.Models
{
    public class User : IdentityUser
    {
        [NotMapped]

        public IList<string> RoleNames { get; set; } = null!;

    }
}