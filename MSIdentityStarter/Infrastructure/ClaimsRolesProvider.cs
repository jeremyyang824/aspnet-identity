﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MSIdentityStarter.Infrastructure
{
    public class ClaimsRolesProvider
    {
        public static IEnumerable<Claim> CreateRolesFromClaims(ClaimsIdentity user)
        {
            List<Claim> claims = new List<Claim>();
            if (user.HasClaim(x => x.Type == ClaimTypes.StateOrProvince && x.Issuer == "RemoteClaims" && x.Value == "DC")
                && user.HasClaim(x => x.Type == ClaimTypes.Role && x.Value == "Employees"))
            {
                //添加角色
                claims.Add(new Claim(ClaimTypes.Role, "DCStaff"));
            }
            return claims;
        }
    }
}