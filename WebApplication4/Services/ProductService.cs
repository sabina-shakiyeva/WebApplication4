using Entities.Entities;

namespace WebApplication4.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>
        {
            new Product{ Id = 1, Name = "Product 1", Price = 10.0 },
            new Product { Id = 2, Name = "Product 2", Price = 20.0 },
            new Product { Id = 3, Name = "Product 3", Price = 30.0 }
        };
        public Product Add(Product product)
        {
            products.Add(product);
            return product;
        }

        public void Delete(int id)
        {
            var item=products.FirstOrDefault(p => p.Id == id);
            if(item!= null)
            {
                products.Remove(item);
            }
        }

        public Product? GetProductById(int productId)
        {
            return products.FirstOrDefault(p => p.Id == productId);
        }

        public IEnumerable<Product> GetProducts(int top = 0)
        {
            return top==0 ? products : (products.Count()>0?products.Take(top):new List<Product>()) ;
        }

        public Product Update(Product product)
        {
            var item=products.FirstOrDefault(p => p.Id == product.Id);
            if (item != null)
            {
                item.Name=product.Name;
                item.Price=product.Price;
            }
            return product;
        }
    }
}
