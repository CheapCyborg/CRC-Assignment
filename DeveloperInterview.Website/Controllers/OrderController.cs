using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DeveloperInterview.Website.Models;

namespace DeveloperInterview.Website.Controllers
{
    public class OrderController : Controller
    {
		public ActionResult Index()
		{
			var model = new HomeIndexViewModel();
			model.DatabaseSuccess = CanConnectToDb();
			return View(model);
		}
	
		private static bool CanConnectToDb()
        {
            var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            try
            {
                cnn.Open();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
            finally
            {
                if (cnn.State != ConnectionState.Closed)
                    cnn.Close();
            }
        }


		public ActionResult getAllOrders()
		{
			// Connect to Database
			using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
			{
				cnn.Open();

				// Create Command
				using (SqlCommand cmd = new SqlCommand(
					@"SELECT CustomerOrderId, FirstName ,ProductId, [Name], Price
					FROM OrderProduct AS o
					INNER JOIN CustomerOrder co ON co.id = o.CustomerOrderId
					INNER JOIN Product p ON p.Id = o.ProductId
					INNER JOIN Customer c ON c.Id = co.CustomerId
					ORDER BY FirstName"))
				{
					cmd.Connection = cnn;

					// Read from Database
					SqlDataReader reader = cmd.ExecuteReader();
					var orders = new List<OrderIndexViewModel>();
					while (reader.Read())
					{
						var order = new OrderIndexViewModel();
						order.CustomerOrderId = reader.GetInt32(0);
						order.FirstName = reader.GetString(1);
						order.ProductId = reader.GetInt32(2);
						order.Name = reader.GetString(3);
						order.Price = reader.GetDecimal(4);
						orders.Add(order);
					}
					cnn.Close();
					return View(orders);
				}
			}
		}

		public ActionResult CreateOrder()
		{
			var model = new CustomerModel();
			return View(model);
		}
    }

}
