using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//using AutoMapper;
using Alligator.Application.Contract;
using Alligator.Domain;
using Alligator.Domain.Model;
using Alligator.Persistence.Contract;
using Microsoft.IdentityModel.Tokens;

namespace Alligator.Application
{
    public class UserApplication :IUserApplication
    {
        private IUserRepository userRepository;
        private readonly IResponseModel responseModel;

        public UserApplication(IUserRepository _userRepository, IResponseModel responseModel)
        {
            userRepository = _userRepository;
            this.responseModel = responseModel;
        }

        public async Task<ResponseModel> Create(User User)
        {
            User usr = userRepository.Create(User);
            if (usr == null)
            {
                return responseModel.CreateResponse(HttpStatusCode.Unauthorized, "Check Credentials Again...!");
            }

            var claims = new[] {
                new Claim (JwtRegisteredClaimNames.Sub, User.Email),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ())
            };

            var signitureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyAdvanceSupperKey"));

            var token = new JwtSecurityToken(
                issuer: "http://oec.com",
                audience: "http://oec.com",
                expires: DateTime.UtcNow.AddHours(2),
                claims: claims,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signitureKey, SecurityAlgorithms.HmacSha256)

            );
            return responseModel.CreateResponse(HttpStatusCode.OK,"Welcome",
            new {
                Authenticated = true,
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        public async Task<ResponseModel> Get()
        {
            return responseModel.CreateResponse(HttpStatusCode.OK, "Welcome", userRepository.Get());
        }

        public async Task<ResponseModel> Get(string id)
        {
            return responseModel.CreateResponse(HttpStatusCode.OK, "Welcome", userRepository.Get(id));
        }

        public async Task<ResponseModel> Get(string username,string password)
        {            
            var usr = userRepository.Get(username, password);
            if (usr == null)
            {
                return responseModel.CreateResponse(HttpStatusCode.Unauthorized, "Check Credentials Again...!");
            }

            var claims = new[] {
                new Claim (JwtRegisteredClaimNames.Sub, usr.Email),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ())
            };

            var signitureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyAdvanceSupperKey"));

            var token = new JwtSecurityToken(
                issuer: "http://oec.com",
                audience: "http://oec.com",
                expires: DateTime.UtcNow.AddHours(2),
                claims: claims,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signitureKey, SecurityAlgorithms.HmacSha256)

            );
            return responseModel.CreateResponse(HttpStatusCode.OK, "Welcome",
            new
            {
                Authenticated = true,
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        public async Task<ResponseModel> Remove(User UserIn)
        {
            return responseModel.CreateResponse(HttpStatusCode.OK, "Welcome", userRepository.Remove(UserIn));
        }

        public async Task<ResponseModel> Remove(string id)
        {
            return responseModel.CreateResponse(HttpStatusCode.OK, "Welcome", await Task.FromResult(userRepository.Remove(id)));
        }

        public async Task<ResponseModel> Update(string id, User UserIn)
        {
            return responseModel.CreateResponse(HttpStatusCode.OK, "Welcome", userRepository.Update(id,UserIn));
        }
    }
}
