using AutoMapper;
using CickToCart.DTOS;
using CickToCart.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CickToCart.Repositories.Account
{
    public class Account : IAccount
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public IConfiguration _configuration { get; }
        public Account(UserManager<AppUser> userManager,
            IConfiguration configuration,
            IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<AppUserReturnDTO> AdminLogin(AppUserLoginDTO userLoginDTO)
        {
            var user = await _userManager.FindByNameAsync(userLoginDTO.Username);
            if (user == null)
                return null;

            if (await _userManager.CheckPasswordAsync(user, userLoginDTO.Password) && user.IsAdmin)
            {
                var token = GenerateToken(user);
                return new AppUserReturnDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    Email = user.Email,
                    Token = token
                };
            }
            else
                return null;
        }

        public async Task<object> UserLogin(AppUserLoginDTO userLoginDTO)
        {
            var user = await _userManager.FindByNameAsync(userLoginDTO.Username);
            if (user == null)
                return null;

            if (await _userManager.CheckPasswordAsync(user, userLoginDTO.Password))
            {

                var token = GenerateToken(user);
                return new AppUserReturnDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    Email = user.Email,
                    Token = token
                };
            }
            else
                return null;
        }

        public async Task<bool> Register(AppUserRegisterDTO user)
        {
            var userToAdd = new AppUser();
            userToAdd.UserName = user.Userame;
            userToAdd.Email = user.Email;
            userToAdd.FirstName = user.FirstName;
            userToAdd.LastName = user.LastName;
            userToAdd.PhoneNumber = user.PhoneNumber;
            userToAdd.Address = user.Address;
            userToAdd.IsActive = user.IsActive;
            userToAdd.IsAdmin = user.IsAdmin;

            var result = await _userManager.CreateAsync(userToAdd, user.Password);
            if (result.Succeeded)
                return true;
            else return false;
        }
        public async Task<IdentityResult> RegisterAbdo(AppUserRegisterDTO2 user)
        {
            var userToAdd = new AppUser();
            userToAdd.UserName = user.UserName;
            userToAdd.Email = user.Email;
            userToAdd.FirstName = user.FirstName;
            userToAdd.LastName = user.LastName;
            userToAdd.PhoneNumber = user.PhoneNumber;
            userToAdd.Address = user.Address;
            userToAdd.IsActive = user.IsActive;
            userToAdd.IsAdmin = user.IsAdmin;

            var result = await _userManager.CreateAsync(userToAdd, user.Password);
            return result;
        }


        //public async Task<AppUserReturnDTO> GetUserData(string userId)
        //{
        //    //var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
        //    var user = HttpContext.Current.User.Identity.GetUserId();

        //    var user = User.Identity.GetUserId();
        //}


        private string GenerateToken(AppUser user)
        {
            var claims = new[]
           {
                new Claim("Id", user.Id.ToString()),
                new Claim("userName", user.UserName.ToString()),
                new Claim("Email", user.Email.ToString()),
                new Claim("PhoneNumber", user.PhoneNumber != null? user.PhoneNumber.ToString() : "0")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSetting:SecritKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }

        public List<UserListDTO> GetUsers()
        {
            var usersList = _userManager.Users.Where(u => u.IsAdmin == false).ToList();
            var newUsersList = _mapper.Map<List<UserListDTO>>(usersList);

            return newUsersList;
        }

        public List<UserListDTO> GetUsersAdmin()
        {
            var usersList = _userManager.Users.Where(u => u.IsAdmin == true).ToList();
            var newUsersList = _mapper.Map<List<UserListDTO>>(usersList);

            return newUsersList;
        }

        public async Task<object> UpdateMyProfile(AppUserUpdate userUpdate)
        {
            var user = await _userManager.FindByIdAsync(userUpdate.Id.ToString());
            if (user != null)
            {
                user.FirstName = userUpdate.FirstName;
                user.LastName = userUpdate.LastName;
                user.Email = userUpdate.Email;
                user.UserName = userUpdate.UserName;
                user.PhoneNumber = userUpdate.PhoneNumber;
                user.Address = userUpdate.Address;
                user.PasswordHash = user.PasswordHash;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    if ((userUpdate.OldPassword != "" || userUpdate.OldPassword != null) && (userUpdate.NewPassword != "" || userUpdate.NewPassword != null))
                    {
                        var changePassResult = await _userManager
                                .ChangePasswordAsync(user, userUpdate.OldPassword, userUpdate.NewPassword);
                        if (changePassResult.Succeeded)
                        {
                            return "Updated successfully";
                        }
                    }
                    return "Updated successfully";
                }
                return "Error in update";
            }
            return "Error in update";
        }

        public async Task<bool> DeleteUsers(string id )
        {
           var user =  _userManager.Users.FirstOrDefault(x => x.Id == id);
            //var newUsersList = _mapper.Map List<<AppUser>>(user);
            //var newUsersList = _mapper.Map<AppUser>(user);
            var user2 =  _userManager.DeleteAsync(user);
            //if (user2.Succeeded)
            //    return true;
            //else
            return false;
        }
    }
}
