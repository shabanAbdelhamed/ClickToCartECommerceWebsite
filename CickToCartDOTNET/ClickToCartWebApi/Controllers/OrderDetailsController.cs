using AutoMapper;
using CickToCart.DTOS;
using CickToCart.Models;
using CickToCart.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClickToCartWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {

        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        public OrderDetailsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<OrderDetailsController>
        [HttpGet("{id}")]
        public IEnumerable<OrderDetailsViewModels> GetById(int id)
        {
            var list = _unitOfWork.OrderDetailsRepo.GetAllProductsFromOrder(id);

            return _mapper.Map<IEnumerable<OrderDetailsViewModels>>(list);
           
        }
    }
}
