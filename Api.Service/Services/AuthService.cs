using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.Auth;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Service.Helpers;
using Api.Service.Security;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IWorkshopRepository _workshopRepository;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public AuthService(
            IAuthRepository authRepository,
            IOptions<AppSettings> appSettings,
            IWorkshopRepository workshopRepository,
            IMapper mapper
        )
        {
            _authRepository = authRepository;
            _appSettings = appSettings.Value;
            _workshopRepository = workshopRepository;
            _mapper = mapper;
        }

        public async Task<AuthDtoLoginResult> Create(AuthDtoCreate dto)
        {
            var auth = _mapper.Map<AuthEntity>(dto);
            var workshop = _mapper.Map<WorkshopEntity>(dto);

            auth.Password = EncryptHelper.HashPassword(auth.Password);

            auth = await _authRepository.InsertAsync(auth);
            workshop.AuthId = auth.Id;

            await _workshopRepository.InsertAsync(workshop);

            return GenerateJwt(auth, workshop);
        }

        public async Task<AuthDtoLoginResult> Login(AuthDtoLogin dto)
        {
            var auth = await _authRepository.SelectByCnpjAsync(dto.Cnpj);

            if (auth == null || !EncryptHelper.Verify(dto.Password, auth.Password))
                throw new UnauthorizedAccessException();

            var workshop = await _workshopRepository.SelectByAuthIdAsync(auth.Id);

            return GenerateJwt(auth, workshop);
        }

        private AuthDtoLoginResult GenerateJwt(AuthEntity auth, WorkshopEntity workshop)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimsConstant.USER_ID, auth.Id.ToString()));
            claims.Add(new Claim(ClaimsConstant.WORKSHOP_ID, workshop.Id.ToString()));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var expireDate = DateTime.UtcNow.AddHours(_appSettings.Expiration);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience,
                Expires = expireDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return new AuthDtoLoginResult {
                AccessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
                Authenticated = true,
                Expiration = expireDate
            };
        }
    }
}
