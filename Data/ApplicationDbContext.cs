using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using MyInventory.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PanDelivery.Models;

namespace MyInventory.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }
        
        public DbSet<Item> Items { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<PanDelivery.Models.Contact> Contact { get; set; }
    }
}
