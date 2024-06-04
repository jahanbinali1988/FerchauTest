using FerchauTest.Domain.Tests.Customers;
using FerchauTest.Shared.Shared;
using Moq;
using FerchauTest.Domain.Cars;

namespace FerchauTest.Domain.Tests.Cars
{
	internal class CarBuilder
	{
		internal Mock<IIdGenerator> _idgenerator;
		internal string _brand;
		internal string _model;
		internal int _totalKilometres;

		internal static CarBuilder Instance
		{
			get
			{
				var result = new CarBuilder();

				return result;
			}
		}

		public CarBuilder()
		{
			WithBrand("Benz");
			WithModel("S500");
			WithTotalKilometers(100);

			_idgenerator = new Mock<IIdGenerator>();
			SetIdGenerator(999);
		}
		internal CarBuilder WithBrand(string brand) { _brand = brand; return this; }
		internal CarBuilder WithModel(string model) { _model = model; return this; }
		internal CarBuilder WithTotalKilometers(int totalKilometer) { _totalKilometres = totalKilometer; return this; }
		internal CarBuilder SetIdGenerator(long id)
		{
			_idgenerator.Setup(s => s.GetNewId()).Returns(id);

			return this;
		}
		internal Car Create()
		{
			return Car.Create(_brand, _model, _idgenerator.Object);
		}
	}
}
