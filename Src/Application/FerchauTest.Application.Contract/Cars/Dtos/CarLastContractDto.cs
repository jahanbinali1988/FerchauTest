namespace FerchauTest.Application.Contract.Cars.Dtos
{
	public class CarLastContractDto
	{
        public long Id { get; set; }
        public long CarId { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public DateTimeOffset StartDate { get; set; }
		public DateTimeOffset EndDate { get; set; }
		public bool IsFinished { get; set; }
		public int UsedKilometers { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
	}
}
