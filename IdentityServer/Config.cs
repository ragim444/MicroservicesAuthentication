using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[] {
            //new Client
            //    {
            //        ClientId="movieClient",
            //        AllowedGrantTypes=GrantTypes.ClientCredentials,
            //        ClientSecrets = {
            //            new Secret("secret".Sha256())
            //        },
            //        AllowedScopes={ "movieAPI" }
            //    },
            new Client
                {
                    ClientId="movies_mvc_client",
                    ClientName = "Movies MVC Webb App",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RequirePkce = false,
                    AllowRememberConsent = false,
                    RedirectUris = new List<string>(){"https://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = new List<string>(){"https://localhost:5002/signout-callback-oidc" },
                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes= new List<string>()
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Email,
                        "movieAPI",
                        "roles"
                    }
                },
            new Client
                {
                    ClientId = "interactive.public",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris =           { "http://localhost:4200/signin-callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:4200/" },
                    AllowedCorsOrigins =     { "http://localhost:4200" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api"
                    }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
           new ApiScope[] {
               new ApiScope("movieAPI","Movie API"),
               new ApiScope("api","MyApi")
           };

        public static IEnumerable<ApiResource> ApiResources =>
       new ApiResource[] { };

        public static IEnumerable<IdentityResource> IdentityResources =>
       new IdentityResource[]
       {
           new IdentityResources.OpenId(),
           new IdentityResources.Profile(),
           new IdentityResources.Address(),
           new IdentityResources.Email(),
           new IdentityResource(
               "roles",
               "Your role",
               new List<string>(){ "role"})
           };

    };

    //public static List<TestUser> TestUsers
    //{
    //    get
    //    {
    //        var address = new
    //        {
    //            street_address = "Mira",
    //            locality = "Moscow",
    //            postal_code = 69118,
    //            country = "Russia"
    //        };

    //        return new List<TestUser>
    //        {
    //             new TestUser
    //                     {
    //                         SubjectId = "EE9E99BC-3A79-4CB3-8995-D10319FD99AA",
    //                         Username = "ragim",
    //                         Password = "ragim",
    //                         Claims = new List<Claim>
    //                            {
    //                                new Claim(JwtClaimTypes.GivenName, "ragim"),
    //                                new Claim(JwtClaimTypes.FamilyName, "rakhmatulaev"),
    //                                new Claim(JwtClaimTypes.Email, "ragim444@yandex.ru"),
    //                                new Claim(JwtClaimTypes.EmailVerified,"true", ClaimValueTypes.Boolean),
    //                                new Claim(JwtClaimTypes.WebSite,"http://ragim.com")
    //                                //new Claim(JwtClaimTypes.Address,JsonSerializer.Serialize(address)),
    //                            }
    //                     }
    //        };
    //    }
    //    set { }
    //}
}