using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceStore.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EcommerceStore.Data
{
    public class EcommerceStoreContext : IdentityDbContext<AdminUser>
    {
        public EcommerceStoreContext() : base("name =EcommerceStoreContext")
        {

        }
        public static EcommerceStoreContext Create()
        {
            return new EcommerceStoreContext();
        }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Proudct> Proudcts { get; set; }
        public DbSet<ProudctImage> ProudctImages { get; set; }
    }
}
