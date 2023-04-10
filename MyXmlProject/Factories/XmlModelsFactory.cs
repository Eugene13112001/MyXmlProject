using MyXmlProject.DataBases;
using MyXmlProject.XMLModels;
using MyXmlProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyXmlProject.Factories
{
    public interface XmlModelsFactory
    {
        public ApplicationContext applicationContext { get; set; }

        public  Task<User> CreateUser(XmlUser user);
       

        public  Task<Product> CreateProduct(XmlProduct prod);


        public  Task<Order?> CreateOrder(User user, XmlOrder order);

        public Task<SalesOfOrder> CreateSale(Product prod, Order order, int Count, double Price);



    }

   public class ModelFactory : XmlModelsFactory
    {
        public ApplicationContext applicationContext { get; set; }
        public ModelFactory() {
            this.applicationContext = new ApplicationContext();
        }
        public async Task<User> CreateUser(XmlUser user)
        {
           
            User? use = await this.applicationContext.GetUser(new User { Name = user.Name, Email = user.Email });
            if (use != null)  return use; 
            return await this.applicationContext.AddUser(new User { Name = user.Name, Email = user.Email });
        }

        public async Task<Product> CreateProduct(XmlProduct prod)
        {

            Product? pr = await this.applicationContext.GetProduct(new Product { Name = prod.Name });
            if (pr != null) return pr;
            return await this.applicationContext.AddProduct(new Product { Name = prod.Name });
        }

        public async Task<Order?> CreateOrder(User user, XmlOrder order)
        {
            Order? or = await this.applicationContext.GetOrder(order.Id);
            if (or != null) return null;
            return await this.applicationContext.AddOrder(new Order {Number = order.Id , User = user, 
            Date = order.Date , Sum = order.Sum});
        }
        public async Task<SalesOfOrder> CreateSale(Product prod, Order order, int Count, double Price)
        {
            return await this.applicationContext.AddSale(new SalesOfOrder
            {
                Product = prod,
                Order = order,
                Count = Count,
                Value = Price
            });
        }
    }
}
