using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TaxiShare.API
{
    public class AuthOptions
    {
        public const string ISSUER = "taxi-share-server";
        public const string AUDIENCE = "taxi-share-client";
        const string KEY = "#!HOR!52i9SE2&bvd$$!FOR!$456#128!CE!89!2sad123boy758";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
