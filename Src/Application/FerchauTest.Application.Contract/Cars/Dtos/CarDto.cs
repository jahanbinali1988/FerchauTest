using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerchauTest.Application.Contract.Cars.Dtos
{
	public class CarDto
	{
		public CarDto(long id, string brand, string model)
		{
			Id = id;
			Brand = brand;
			Model = model;
		}
		public long Id { get; init; }
		public string Brand { get; init; }
		public string Model { get; init; }
	}
}
