using CickToCart.DTOS;
using CickToCart.Models;
using CickToCart.Repositories.Account;
using ClickToCartWebApi.APIViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClickToCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAccount _account;
        private readonly ContextDataBase _context;

        public UserController(IAccount account, ContextDataBase context)
        {
            _account = account;
            _context = context;

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(AppUserLoginDTO userLoginDTO)
        {
          //  var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var result = await _account.UserLogin(userLoginDTO);
            if (result == null)
                return Ok(new ResultViewModel() { success = false, message = "Your username or password Not found", data = null });
            return Ok(new ResultViewModel() { success = true, message = "You are logged succesfully", data = result });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(AppUserRegisterDTO2 AppUserRegister)
        {
            Microsoft.AspNetCore.Identity.IdentityResult result = await _account.RegisterAbdo(AppUserRegister);
            //if (!result)
            //    return BadRequest("error in registeration");

            return Ok(result);
        }
        [Authorize]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetUser(string id )
        {
            var result = _context.AppUsers.FirstOrDefault(x => x.Id == id);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("updateProfile")]
        public async Task<ActionResult<ResultViewModel>> UpdateProfile(AppUserUpdate userUpdate)
        {
            if (ModelState.IsValid)
            {
                var result = await _account.UpdateMyProfile(userUpdate);

                if (result.ToString() == "Updated successfully")
                    return Ok(new ResultViewModel { 
                    success=true,
                    message= "Updated successfully"
                    });

                return Ok(new ResultViewModel
                {
                    success = false,
                    message = "Error in update"
                });
            }
            return Ok(new ResultViewModel
            {
                success = false,
                message = "Error in update"
            });
        }
    }
}
