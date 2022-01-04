using CickToCart.DTOS;
using CickToCart.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CickToCart.Repositories.Account
{
    public interface IAccount
    {
        Task<AppUserReturnDTO> AdminLogin(AppUserLoginDTO userLoginDTO);
        Task<object> UserLogin(AppUserLoginDTO userLoginDTO);
        Task<bool> Register(AppUserRegisterDTO user);
        Task<IdentityResult> RegisterAbdo(AppUserRegisterDTO2 user);
        List<UserListDTO> GetUsers();
        List<UserListDTO> GetUsersAdmin();
        Task<object> UpdateMyProfile(AppUserUpdate userUpdate);
        Task<bool> DeleteUsers(string id );
    }
}
