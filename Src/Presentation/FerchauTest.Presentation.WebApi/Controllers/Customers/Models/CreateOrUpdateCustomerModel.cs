using System;

namespace FerchauTest.Presentation.WebApi.Controllers.Customers.Models
{
	public class CreateOrUpdateCustomerModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
	}
}
