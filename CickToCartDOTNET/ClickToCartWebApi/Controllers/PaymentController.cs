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
    public class PaymentController : ControllerBase
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        public PaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IEnumerable<PaymentViewModel>> GetAll()
        {
            var list = await _unitOfWork.PaymentRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentViewModel>>(list);

        }
        [HttpGet("{id}")]
        // GET<OrderController>/5
        public async Task<PaymentViewModel> GetById(int id)
        {
            var product = _mapper.Map<PaymentViewModel>( await _unitOfWork.PaymentRepo.GetAsync(id));
            return product;
        }
    }
}
