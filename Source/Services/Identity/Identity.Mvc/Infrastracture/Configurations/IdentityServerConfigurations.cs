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
                new ApiScope("Ma_Project", "Ma_Project", claims)
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>(){
                new Client
                {
                    ClientId = "Ma_Project",
                    ClientName = "Ma_Project",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris ={ "http://localhost:4200/"},
                    AllowedCorsOrigins = { "http://localhost:4200"},
                    AllowedScopes = {
                        "Ma_Project",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>(){
                new ApiResource("UserPanel", "Ma_Project"){ Scopes = { "Ma_Project" } },
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
