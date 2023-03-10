using BookShopping_Project_130.DataAccess.Data;
using BookShopping_Project_130.DataAccess.Repository.IRepository;
using BookShopping_Project_130.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopping_Project_130.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public void Update(Product product)
        {
            var productInDb = _context.Products.FirstOrDefault
                (p => p.Id == product.Id);
            if(productInDb != null)
            {
                if (product.ImageURL != "")
                    productInDb.ImageURL = product.ImageURL;
                productInDb.Title = product.Title;
                productInDb.Discription = product.Discription;
                productInDb.ISBN = product.ISBN;
                productInDb.Author = product.Author;
                productInDb.ListPrice = product.ListPrice;
                productInDb.Price50 = product.Price50;
                productInDb.Price100 = product.Price100;
                productInDb.Price = product.Price;
                productInDb.CategoryId = product.CategoryId;
                productInDb.CoverTypeId = product.CoverTypeId;
            }

        }
    }
}
