using CickToCart.Models;
using CickToCart.Repositories.CartDetailsRepo;
using CickToCart.Repositories.CartRepo;
using CickToCart.Repositories;
using CickToCart.Repositories.ProductsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{

    public class UnitWork : IUnitOfWork
    {

        private readonly ContextDataBase Context;

        public UnitWork(ContextDataBase context,ITagRepo tagRepo,ICategoryRepo categoryRepo)
        {
            Context = context;
            ProductsRepos = new ProductsRepos(context);
            SubCategoryRepo = new SubCategoryRepo(context);
            DiscountRepo = new DiscountRepo(Context);
            product_ColorRepos = new Product_colorRepos(context);
            product_SizeRepos = new Product_SizeRepos(context);
            product_RatingRepos = new Product_RatingRepos(context);
            TagRepo = tagRepo;
            OrderRepo = new OrderRepo(context);
            CartRepo = new Cart_Repo(context);
            CartDetailsRepo = new CartDetails_Repo(context);
            OrderDetailsRepo = new OrderDetailsRepo(context);
            CategoryRepo = categoryRepo;
            ShippingRepo= new ShippingRepo(context);
            PaymentRepo = new PaymentRepo(context);
            ColorRepo = new ColorRebo(context);
            SizeRepo= new SizeRepo(context);
            OrderStatusRepo= new OrderStatusRepo(context);
            StatusRepo= new StatusRepo(context);
        }
        public IProductsRepos ProductsRepos { get; }
        public ISubCategoryRepo SubCategoryRepo { get; }
        public IDiscountRepo DiscountRepo { get; }
        public ITagRepo TagRepo { get; }
        public IOrderRepo OrderRepo { get; }
        public IOrderDetailsRepo OrderDetailsRepo { get; }
        public IColorRepo ColorRepo { get; }
        public ISizeRepo SizeRepo { get; }

        public ICategoryRepo CategoryRepo { get; }
        public IShippingRepo ShippingRepo { get; }
        public IPaymentRepo PaymentRepo { get; }
        public IProduct_colorRepos product_ColorRepos { get; }
        public IProduct_SizeRepos product_SizeRepos { get; }
        public IProduct_RatingRepos product_RatingRepos { get; }

        public ICartRepo CartRepo { get; }

        public ICartDetailsRepo CartDetailsRepo { get; }
        public IStatusRepo StatusRepo { get; }
        public IOrderStatusRepo OrderStatusRepo { get; }

        public async Task<int> CommitAsync() => await Context.SaveChangesAsync();
        public void Dispose() => Context.Dispose();
    }
}
