using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WeatherAPI
{
    public static class ConfigurationIdentity
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                //SCOPE - Resource to be protected by IDS 
                new ApiResource("ExampleAPI", "ExampleAPI")
                {
                }
            };
        }


        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "Example",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    RequireConsent = false,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes =
                    {
                        "ExampleAPI"
                    },
                    AllowOfflineAccess = true
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    DisplayName="User Role",
                    Description="The application can see your role.",
                    UserClaims = new[]{JwtClaimTypes.Role,ClaimTypes.Role},
                    ShowInDiscoveryDocument = true,
                    Required=true,
                    Emphasize = true
                }
            };
        }
    }
}
