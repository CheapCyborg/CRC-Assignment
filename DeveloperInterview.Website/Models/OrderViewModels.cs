using System;

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
	public class CustomerModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public DateTime AddedDate { get; set; } = DateTime.Now;
	}
}