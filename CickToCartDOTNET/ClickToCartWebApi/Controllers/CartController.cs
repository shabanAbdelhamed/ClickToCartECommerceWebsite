using AutoMapper;
using CickToCart.DTOS;
using CickToCart.Models;
using CickToCart.Repositories;
using ClickToCartWebApi.APIViewModels;
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
    public class CartController : ControllerBase
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        private float getTotalPrice(IEnumerable<CartDetailsViewModel> cart)
        {
            float TotalPrice = 0;
            foreach(var item in cart)
                {
                TotalPrice += item.Price;

            }
            return TotalPrice;
        }
        private void addCartId (IEnumerable<CartDetailsViewModel> cart , int cartId)
        {
           
               foreach (var item in cart)
                {
                    item.cartID = cartId;
                }


        }
        // GET<OrderController>/5
        [HttpGet("{id}")]
        public CartUserViewModel GetFromCart(string id)
        {
           var cart= _unitOfWork.CartRepo.GetCartByUserID(id);
            // CartDetails cartdetails = null;
            CartUserViewModel CartItems = new CartUserViewModel()
            {
                UserID = id,
                CartDetailsItems = new List<CartDetailsViewModel>(),
            };
         if (cart!=null)
            {

                var cartdetails = _unitOfWork.CartDetailsRepo.GetAllProductsInCart(cart.ID);
                CartItems.CartDetailsItems = _mapper.Map<IEnumerable<CartDetailsViewModel>>(cartdetails);
            }
         else
            {
                cart = new Cart() { UserID = id };
                _unitOfWork.CartRepo.AddAsync(cart);
              //  var cartdetails = _unitOfWork.CartDetailsRepo.GetAllProductsInCart(cart.ID);
              //  CartItems.CartDetailsItems = _mapper.Map<IEnumerable<CartDetailsViewModel>>(cartdetails);
            }
         return CartItems;
            
        }
        [HttpGet("{Id}")]
        public CartUserViewModel2 GetFromCartWithProduct(string Id)
        {
            var cart = _unitOfWork.CartRepo.GetCartByUserID(Id);
            // CartDetails cartdetails = null;
            CartUserViewModel2 CartItems = new CartUserViewModel2()
            {
                UserID = Id,
                CartDetailsItems = new List<CartDetailsViewModel2>(),
            };
            if (cart != null)
            {

                var cartdetails = _unitOfWork.CartDetailsRepo.GetAllProductsInCart(cart.ID);
                CartItems.CartDetailsItems = _mapper.Map<List<CartDetailsViewModel2>>(cartdetails);
            }
            else
            {
                cart = new Cart() { UserID = Id };
                _unitOfWork.CartRepo.AddAsync(cart);
                //  var cartdetails = _unitOfWork.CartDetailsRepo.GetAllProductsInCart(cart.ID);
                //  CartItems.CartDetailsItems = _mapper.Map<IEnumerable<CartDetailsViewModel>>(cartdetails);
            }
            return CartItems;

        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(CartUserViewModel data)
        {
            float TotalPrice = getTotalPrice(data.CartDetailsItems);
            Cart cart= cart=_unitOfWork.CartRepo.GetCartByUserID(data.UserID);
            if(cart==null)
            {
                cart = new Cart();
                cart.UserID = data.UserID;
                cart.TotalPrice = TotalPrice;
                await _unitOfWork.CartRepo.AddAsync(cart);
                await _unitOfWork.CommitAsync();
                addCartId(data.CartDetailsItems, cart.ID);
                var parsed = _mapper.Map<List<CartDetails>>(data.CartDetailsItems);
                await _unitOfWork.CartDetailsRepo.AddRangeAsync(parsed);
                await _unitOfWork.CommitAsync();
            }
            else
            {
               
                cart.TotalPrice = TotalPrice;
                
                addCartId(data.CartDetailsItems, cart.ID);
                var parsed = _mapper.Map<IEnumerable<CartDetails>>(data.CartDetailsItems);
                _unitOfWork.CartDetailsRepo.RemoveOldCartDetails(cart.ID);
                await _unitOfWork.CartDetailsRepo.AddRangeAsync(parsed);
                await _unitOfWork.CommitAsync();
                return Ok("Tset");
            }
            // var list = _mapper.Map<IEnumerable<OrderViewModels>>(_unitOfWork.OrderRepo.GetByOrdersbyUserId(id));
            return Ok();
        }

        // POST api/<OrderController>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] OrderViewModels OrderView)
        //{
        //    Cart Cart = _unitOfWork.CartRepo.GetCartByUserID(OrderView.UserID);

        //    var parsed = _mapper.Map<Order>(OrderView);
        //    await _unitOfWork.OrderRepo.AddAsync(parsed);
        //    await _unitOfWork.CommitAsync();

        //    List<OrderDetailsViewModels> AllProductInOrder = new List<OrderDetailsViewModels>();
        //    var ALLProductInCart = _unitOfWork.CartDetailsRepo.GetAllProductsInCart(Cart.ID);
        //    foreach (var item in ALLProductInCart)
        //    {
        //        AllProductInOrder.Add(new OrderDetailsViewModels()
        //        {
        //            orderID = parsed.ID,
        //            ProductID = item.productID,
        //            Price = item.Price,
        //            Quantity = item.Quantity,
        //        });

        //    }
        //    var parsed2 = _mapper.Map<List<OrderDetails>>(AllProductInOrder);
        //    await _unitOfWork.OrderDetailsRepo.AddRangeAsync(parsed2);
        //    await _unitOfWork.CommitAsync();
        //    _unitOfWork.CartRepo.Remove(Cart);
        //    await _unitOfWork.CommitAsync();
        //    return Ok();


        //}



    }
}
