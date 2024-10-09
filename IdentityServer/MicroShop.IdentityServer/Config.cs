// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace MicroShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
          new ApiResource("resourceCatalog")
          {
              Scopes = {"CatalogFullPermission","CatalogReadPermission"}
          },
          new ApiResource("resourceDiscount")
          {
              Scopes={"DiscountFullPermission"}
          },
          new ApiResource("resourceOrder")
          {
              Scopes={"OrderFullPermission"}
          }
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations")
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //vistors
            new Client
            {
                ClientId="MicroShopVisitorId",
                ClientName="Micro Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("microshopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission" }
            },
            //manger
            new Client
            {
                ClientId="MicroShopManagerId",
                ClientName="Micro Shop Manager User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("microshopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission" }

            },
            //admin
            new Client
            {
                ClientId="MicroShopAdminId",
                ClientName="Micro Shop Admin User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("microshopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission", IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile},
                AccessTokenLifetime=800
            }
        };
    }
}