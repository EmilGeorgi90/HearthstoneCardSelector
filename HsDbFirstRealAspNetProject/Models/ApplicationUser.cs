using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HsDbFirstRealAspNetProject.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser, IEquatable<ApplicationUser>
    {
        public bool Equals(ApplicationUser other)
        {
            return this == other;
        }
    }
}
