using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Identity.Mvc.Infrastracture.Configurations
{
    public class IdentityServerConfigurations
    {

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            var claims = new List<string>(){
                    ClaimTypes.Email,
                    JwtClaimTypes.Subject,
                    JwtClaimTypes.PreferredUserName,
                    JwtClaimTypes.Name,
                    JwtClaimTypes.Email,
                    JwtClaimTypes.EmailVerified,
                    JwtClaimTypes.Role,
                    JwtClaimTypes.PhoneNumber,
                    JwtClaimTypes.PhoneNumberVerified,
                    JwtClaimTypes.IdentityProvider,
                    JwtClaimTypes.AuthenticationMethod,
                    JwtClaimTypes.AuthenticationTime,
            };

            return new List<ApiScope>(){
                new ApiScope("UserPanel.Angular", "UserPanel.Angular", claims)
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>(){
                new Client
                {
                    ClientId = "UserPanel.Angular",
                    ClientName = "UserPanel.Angular",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris ={ "http://localhost:4200/"},
                    AllowedCorsOrigins = { "http://localhost:4200"},
                    AllowedScopes = {
                        "UserPanel.Angular",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>(){
                new ApiResource("UserPanel.Angular", "UserPanel.Angular"){ Scopes = { "UserPanel.Angular" } },
            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
    }
}
