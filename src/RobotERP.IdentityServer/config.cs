using IdentityServer4.Models;
using IdentityServer4.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotERP.IdentityServer
{
    public class config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                 new ApiResource("api1","My API")
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                     ClientId="client",
                     //no interative user,use the clientid/secret for authentication
                     AllowedGrantTypes=GrantTypes.ClientCredentials,
                     
                     //secret for authentication
                     ClientSecrets=
                    {
                        new Secret("secret".Sha256())
                    },
                    //scopes that client has access to
                    AllowedScopes=
                    {
                        "api1"
                    }
                },
                new Client
                {
                    ClientId="ro.client",
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                     ClientSecrets=
                    {
                        new Secret("secret".Sha256())
                    },
                     AllowedScopes= {"api1"}
                }
            }; 
        }
        public static List<InMemoryUser> GetUsers()
        {
            return new List<InMemoryUser> {
                 new InMemoryUser
                 {
                      Subject="1",
                      Username="alice",
                       Password="password"
                 },
                  new InMemoryUser
                  {
                      Subject="2",
                      Username="bobo",
                      Password="password"
                  }
            };
        }
    }
}
