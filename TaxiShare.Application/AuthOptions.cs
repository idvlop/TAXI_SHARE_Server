using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TaxiShare.Application
{
    public static class AuthOptions
    {
        public static string ISSUER { get; } = "taxi-share-server";
        public static string AUDIENCE { get; } = "taxi-share-client";
        private readonly static string KEY = "#!HOR!52i9SE2&bvd$$!FOR!$456#128!CE!89!2sad123boy758";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
