using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperInterview.Website.Models
{
    public class OrderIndexViewModel
    {
		public int CustomerOrderId { get; set; }
		public string FirstName { get; set; }
		public int ProductId { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}