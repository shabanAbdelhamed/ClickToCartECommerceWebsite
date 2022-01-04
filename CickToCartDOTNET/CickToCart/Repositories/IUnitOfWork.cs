using CickToCart.Models;
using CickToCart.Repositories.CartDetailsRepo;
using CickToCart.Repositories.CartRepo;
using CickToCart.Repositories.ProductsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
        IProductsRepos ProductsRepos { get; }
         ISubCategoryRepo SubCategoryRepo { get; }
        IDiscountRepo DiscountRepo { get; }
        ITagRepo TagRepo { get; }
        IOrderRepo OrderRepo { get; }
        IOrderDetailsRepo OrderDetailsRepo { get; }
        IColorRepo ColorRepo { get; }
        ISizeRepo SizeRepo { get; }
        IProduct_colorRepos product_ColorRepos { get; }
        IProduct_SizeRepos product_SizeRepos { get; }
        IProduct_RatingRepos product_RatingRepos { get; }
        ICategoryRepo CategoryRepo { get; }
        IShippingRepo ShippingRepo { get; }
        IPaymentRepo PaymentRepo { get; }
        ICartRepo CartRepo { get; }
        ICartDetailsRepo CartDetailsRepo { get; }
        IOrderStatusRepo OrderStatusRepo { get; }
        IStatusRepo StatusRepo { get; }
    }
}
