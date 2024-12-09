using Duende.IdentityServer.Models;
using Duende.IdentityServer;

namespace sep3.identity;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResources.Address(),
            new IdentityResources.Phone(),
            new IdentityResource("role", "Roles", new List<string> { "role", "admin", "employee.read", "employee.write", "employee.warehouse", "employee.orders", "employee.customeradmin", "customer" }),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("web", "Web Client"),
            new ApiScope("orders", "Orders API"),
            new ApiScope("warehouse", "Warehouse API"),
            new ApiScope("rolescope", "Role Scope", new List<string> { "role", "admin", "employee.read", "employee.write", "employee.warehouse", "employee.orders", "employee.customeradmin", "customer" }),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "m2m.client",
                ClientName = "Client Credentials Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                AllowedScopes = { }
            },

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "interactive",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:44300/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { }
            },
            new Client
            {
                ClientId = "web",
                ClientName = "Web Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("efa6686b-7739-4391-8ae3-60d0b4353843".Sha256()) },
                AllowedScopes = { "web", "orders", "warehouse", IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Address, IdentityServerConstants.StandardScopes.Profile, IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.Phone }
            },
            new Client
            {
                ClientId = "orders",
                ClientName = "Orders Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("c8e2bccb-c2f7-42ea-916d-35c27f1d38f9".Sha256()) },
                AllowedScopes = { "orders", IdentityServerConstants.StandardScopes.Address, IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.Phone }
            },
            new Client
            {
                ClientId = "warehouse",
                ClientName = "Warehouse Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("b43931cb-7e27-4361-84ea-6d0d586c8485".Sha256()) },
                AllowedScopes = { "warehouse" }
            }
        };
}