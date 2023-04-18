using System.Security.Claims;

namespace HospitalAPI.Security
{
    public static class ClaimsPrincipalExtensions
    {
        public static int UserId(this ClaimsPrincipal User)
        {
            return int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
        }
    }
}
