using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using marketplace.Data.UnitOfWorkPattern;
using marketplace.DTO.Catalog.Product;
using marketplace.DTO.Common;
using Microsoft.Extensions.Configuration;
using marketplace.Utilities.Const;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using marketplace.Services.Common;
using System;
using marketplace.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using marketplace.DTO.Catalog.Category;
using Microsoft.Extensions.Logging;
using marketplace.Utilities.Common;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace marketplace.Services.SystemManager.Auth
{
    public class JWTService : BaseService<JWTService>, IJWTService
    {
        public JWTService(IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<JWTService> logger) : base(configuration, unitOfWork, env, logger)
        {

        }

        public ClaimsPrincipal ValidateToken(string jwtToken)
        {
            // IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();
            validationParameters.ValidateLifetime = true;
            validationParameters.ValidAudience = _configuration[ConfigKeyConst.TOKENS_ISSUER];
            validationParameters.ValidIssuer = _configuration[ConfigKeyConst.TOKENS_ISSUER];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[ConfigKeyConst.TOKENS_KEY]));

            ClaimsPrincipal principal = null;

            principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }
    }
}