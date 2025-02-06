using Microsoft.EntityFrameworkCore;
using MultiStore.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiStore.Order.Persistence.Context
{
    public class OrderContext : DbContext
	{
		override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=...;Database=MultiStoreOrderDb;integrated Security=true;");
		}
		public DbSet<Address> Addresses { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Ordering> Orderings { get; set; }
	}
}
