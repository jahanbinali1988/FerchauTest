namespace FerchauTest.Presentation.WebApi.Controllers.Cars.Models
{
	public class ContractHistoryModel
	{
        public long? CustomerId { get; set; }
		public int? PageSize { get; set; } = 10;
		public int? PageCount { get; set; } = 1;
    }
}
