using AutoMapper;
using CickToCart.DTOS;
using CickToCart.Models;
using CickToCart.Repositories;
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
    public class ShippingController : ControllerBase
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;

        public ShippingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

      
        public async Task<IEnumerable<ShippingViewModels>> GetAll()
        {
            var list = _mapper.Map<IEnumerable<ShippingViewModels>>(await _unitOfWork.ShippingRepo.GetAllAsync());
            return list;
        }
        [HttpGet("{id}")]
        // GET<OrderController>/5
        public async Task<ShippingViewModels> GetById(int id)
        {
             var shipping = _mapper.Map<ShippingViewModels>( await _unitOfWork.ShippingRepo.GetAsync(id));
            return shipping;
        }
    }
}
