using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthGateway
{
    public interface ITokenService
    {
        public string GenerateToken(IdentityUser user, IList<string> roles);
    }
}
