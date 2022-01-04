using AutoMapper;
using CickToCart.DTOS;
using CickToCart.Models;
using CickToCart.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        private readonly ContextDataBase _context;
        public OrderController(IUnitOfWork unitOfWork, IMapper mapper, ContextDataBase context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ActionResult> GetAll()
        {            
             var list = _mapper.Map<IEnumerable<OrderViewModels>>(await _unitOfWork.OrderRepo.GetAllOrdersAsync());
             return View("~/Views/Order/GetAll.cshtml", list);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            Order Order = await _unitOfWork.OrderRepo.GetAsync(id);
            OrderDetails OrderDet = await _unitOfWork.OrderDetailsRepo.GetAsync(id);
            if (Order == null)
            {
                return Redirect("/Order/GetAll");
            }
            _unitOfWork.OrderRepo.Remove(Order);
            _unitOfWork.OrderDetailsRepo.Remove(OrderDet);
            await _unitOfWork.CommitAsync();
            return Redirect("/Order/GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStatus([FromRoute] int id)
        {
            Order Order = await _unitOfWork.OrderRepo.GetAsync(id);
            if (Order == null)
            {
                return Redirect("/Order/GetAll");
            }
            ViewBag.Order = Order;
            var result = await _unitOfWork.StatusRepo.GetAllAsync();
            ViewBag.Status = result;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus([FromForm] OrderStatusDTO orderStatus)
        {

            var parsed = _mapper.Map<OrderStatus>(orderStatus);

            Order Order = await  _unitOfWork.OrderRepo.GetAsync(orderStatus.OrderID);
            Status status = await _unitOfWork.StatusRepo.GetAsync(orderStatus.StatusID);
            parsed.Order = Order;
            parsed.Status = status;
            await _unitOfWork.OrderStatusRepo.AddAsync(parsed);
            await _unitOfWork.CommitAsync();
            return Redirect("/Order/GetAll");
        }

        //public async Task<IEnumerable<OrderViewModels>> GetAll()
        //{
        //    ViewBag.list= _mapper.Map<IEnumerable<OrderViewModels>>(await _unitOfWork.OrderRepo.GetAllAsync());
        //    var list = _mapper.Map<IEnumerable<OrderViewModels>>(await _unitOfWork.OrderRepo.GetAllAsync());
        //    return list;
        //}
        //public async Task<OrderViewModels> GetAsync(int id) 
        //{
        //    return _mapper.Map<OrderViewModels>(_unitOfWork.OrderRepo.GetAsync(id));
        //} 

        //public async Task<IEnumerable<Order>> Post(Order order)
        //{
        //    await orderrepo.AddAsync(order);
        //    await _unitOfWork.CommitAsync();
        //    return await orderrepo.GetAllAsync();
        //}
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //public void Delete(int id)
        //{
        //}

        [HttpGet]
        public IActionResult GetOrdersbyUserId(string id)
        {
            var result = _context.AppUsers.FirstOrDefault(x => x.Id == id);
            ViewBag.InfoUsers = result;
            return View(_unitOfWork.OrderRepo.GetOrdersbyUserId(id));
        }


        [HttpGet]
        public IActionResult GetOrdersAll()
        {
            var Sum = _context.orders.Sum(x => x.TotalPrice);
            ViewBag.SumOrders = Sum;
            var Count = _context.orders.Count();
            ViewBag.CountOrders = Sum;
            return View();
        }


        [HttpGet]
        public IActionResult GetOrdersAllByDate()
        {
            var SumByDate = _context.orders.Where(x=>x.CreatedAT==DateTime.Now.Date).Sum(x => x.TotalPrice);           
            ViewBag.SumByDateOrders = SumByDate;
            return View();
        }
    }
}
