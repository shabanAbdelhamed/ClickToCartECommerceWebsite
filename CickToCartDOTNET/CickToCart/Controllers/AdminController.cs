using AutoMapper;
using CickToCart.DTOS;
using CickToCart.Models;
using CickToCart.Models.User;
using CickToCart.Repositories;
using CickToCart.Repositories.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IMapper _mapper;
        private readonly IAccount _account;
        private readonly ContextDataBase _context;
        IUnitOfWork _unitOfWork;
        public AdminController(IUnitOfWork unitOfWork, IAccount account, IMapper mapper, ContextDataBase context)
        {
            _account = account;
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<ActionResult> Dashboard()
        {
            var Sum = _context.orders.Sum(x => x.TotalPrice);
            ViewBag.SumOrders = Sum;
            var Count = _context.orders.Count();
            ViewBag.CountOrders = Count;
            var SumByDate = _context.orders.Where(x => x.CreatedAT == DateTime.Now.Date).Sum(x => x.TotalPrice);
            var CountByDate = _context.orders.Where(x => x.CreatedAT == DateTime.Now.Date).Count();
            ViewBag.SumByDateOrders = SumByDate;
            ViewBag.CountByDateOrders = CountByDate;
            var list = _mapper.Map<IEnumerable<OrderViewModels>>( await _unitOfWork.OrderRepo.GetAllOrdersAsync());

            return View("~/Views/Admin/Dashboard.cshtml", list);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AppUserLoginDTO userLoginDTO)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var result = await _account.AdminLogin(userLoginDTO);
            if (result == null)
                return RedirectToAction("login");

            return View("~/Views/Admin/Dashboard.cshtml", result);
        }
    }
}
