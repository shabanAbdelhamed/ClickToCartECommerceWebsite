using CickToCart.Models;
using CickToCart.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CickToCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        IRepository<Cart> cartrepo;
        IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<List<Cart>> Get()
        {
            var List = await cartrepo.GetAllAsync();
            return List.ToList();
        }
        [HttpPost]
        public async Task<IEnumerable<Cart>> Post(Cart cart)
        {
            await cartrepo.AddAsync(cart);
            await _unitOfWork.CommitAsync();
            return await cartrepo.GetAllAsync();
        }


      
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
