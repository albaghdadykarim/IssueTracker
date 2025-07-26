using EntityFramework.Data.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class AuthContext: IdentityDbContext<ApplicationUser> ,IAuthContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
        }
       
    }
    
}
