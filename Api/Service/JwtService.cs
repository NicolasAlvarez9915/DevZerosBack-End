using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Config;
using Api.Modelos;
using Entidad;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service
{
    public class JwtService
    {
        private readonly AppSetting _appSettings;
        public JwtService(IOptions<AppSetting> appSettings)=> _appSettings = appSettings.Value;
        public SessionVista GenerateToken(Usuario usuario)
        {
            // return null if user not found
            if (usuario == null) return null;
            var userResponse = new SessionVista() {
                 Correo = usuario.Correo, 
                 IdPersona = usuario.IdPersona, 
                 Rol = usuario.Rol };
                 
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Contraseña),
                    new Claim(ClaimTypes.Email, usuario.Correo),
                    new Claim(ClaimTypes.NameIdentifier, usuario.IdPersona),
                    new Claim(ClaimTypes.Role, usuario.Rol),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userResponse.Token = tokenHandler.WriteToken(token);
            return userResponse;
        }

    }
}
