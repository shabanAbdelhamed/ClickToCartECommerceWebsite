using AutoMapper;
using CickToCart.DTOS;
using CickToCart.Models;
using CickToCart.Repositories;
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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

       
        // GET<OrderController>/5
        [HttpGet("{id}")]
        public IEnumerable<OrderViewModels> GetByUserId(string id)
        {
            var list = _mapper.Map<IEnumerable<OrderViewModels>>(_unitOfWork.OrderRepo.GetOrdersbyUserId(id));
            return list;
        }

        [HttpGet("{id}")]
        public OrderStatus GetStatusByUserId(int id)
        {
            OrderStatus OrderStatus = _unitOfWork.OrderStatusRepo.GetAll().Where(x => x.Order.ID == id).OrderBy(x => x.ID).LastOrDefault();
            return OrderStatus;
        }
        // POST api/<OrderController>
        [Authorize]
        [HttpPost]
        public async Task<ResultViewModel> Post([FromBody] OrderViewModels OrderView)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            OrderView.UserID = userId;

            Cart Cart = _unitOfWork.CartRepo.GetCartByUserID(OrderView.UserID);
            if(Cart ==null)
                return new ResultViewModel() { success = false, message = "Can't make order with empty cart" };

            var parsed = _mapper.Map<Order>(OrderView);
            parsed.CreatedAT = DateTime.Now.Date;
            await _unitOfWork.OrderRepo.AddAsync(parsed);
            await _unitOfWork.CommitAsync();
            List<OrderDetailsViewModels> AllProductInOrder = new List<OrderDetailsViewModels>();
            var ALLProductInCart = _unitOfWork.CartDetailsRepo.GetAllProductsInCart(Cart.ID);
            
                foreach (var item in ALLProductInCart)
                {
                    AllProductInOrder.Add(new OrderDetailsViewModels()
                    {
                        orderID = parsed.ID,
                        ProductID = item.productID,
                        Price = item.Price,
                        Quantity = item.Quantity,
                    });
                Product prd = await _unitOfWork.ProductsRepos.GetAsync(item.productID);
                prd.Qunatity -= item.Quantity;
                await _unitOfWork.ProductsRepos.Update(prd);
                await _unitOfWork.CommitAsync();

            }
            var parse= _mapper.Map<OrderViewModels>(parsed);

        var parsed2 = _mapper.Map<List<OrderDetails>>(AllProductInOrder);
         
                await _unitOfWork.OrderDetailsRepo.AddRangeAsync(parsed2);
                await _unitOfWork.CommitAsync();
             _unitOfWork.CartRepo.Remove(Cart);
            await _unitOfWork.CommitAsync();
            // return Ok(new ResultViewModel() { success=true,data=parsed,message="Thank you for your order"});

           
                return (new ResultViewModel() { success = true, data = parse.ID, message = "Thank you for your order" });
            // return Ok();
        }
    }


    }

