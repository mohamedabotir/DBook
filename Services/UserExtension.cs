using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace DBook.Services
{
    public static class UserExtension
    {
        public static string GetUserId(this ClaimsPrincipal user) =>
            user.Claims.FirstOrDefault(e => e.Type== "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
    }
}
