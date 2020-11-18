using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TBMMORPG.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "TBMMORPG";
        public const string AUDIENCE = "*.Tbmmorpg.ru";
        const string KEY = "jR<m6z<2J~qQc#m$Ua#.n.HG:fD&wJ";
        public const int LIFETIME = 5;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
