using AutoMapper;
using CickToCart.DTOS;
using CickToCart.Models;
using CickToCart.Repositories;
using CickToCart.Repositories.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CickToCart.Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        private readonly IAccount _account;
        private readonly ContextDataBase _context;

        public OrderDetailsController(IUnitOfWork unitOfWork, IMapper mapper,
            IAccount account, ContextDataBase context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _account = account;
            _context = context;

        }
        public async Task<ActionResult> Details([FromRoute] int id)
        {
            //var comp = _mapper.Map<OrderDetailsViewModels>(await _unitOfWork.OrderDetailsRepo.GetAsync(id));
            var orderDetails = _mapper.Map < IEnumerable < OrderDetailsViewModels >  >(_unitOfWork.OrderDetailsRepo.GetAllProductsFromOrder(id));
            Order Order = await _unitOfWork.OrderRepo.GetAsync(id);
            var User = _context.AppUsers.FirstOrDefault(x => x.Id == Order.UserID);
            OrderStatus OrderStatus =  _unitOfWork.OrderStatusRepo.GetAll().Where(x => x.Order.ID == Order.ID).OrderBy(x => x.ID).LastOrDefault();
            //var OrderStatus = _context.OrdersStatuses.Where(x => x.Order.ID == Order.ID).OrderBy(x=>x.ID).LastOrDefault();
            //var StatusName = _context.Statuses.Where(x => x.ID == OrderStatus.Status.ID).FirstOrDefault();
            ViewBag.User = User;
            ViewBag.Order = Order;
            ViewBag.OrderStatus = OrderStatus;
            //ViewBag.StatusName = StatusName;

            return View(orderDetails);
        }

    }
}
