using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerchauTest.Application.Contract.Customers.Dtos
{
	public class CustomerDto
	{
		public CustomerDto(long id, string firstname, string lastname, string phoneNumber)
		{
			Id = id;
			Firstname = firstname;
			Lastname = lastname;
			PhoneNumber = phoneNumber;
		}
		public long Id { get; init; }
		public string Firstname { get; init; }
		public string Lastname { get; init; }
		public string PhoneNumber { get; init; }
	}
}
