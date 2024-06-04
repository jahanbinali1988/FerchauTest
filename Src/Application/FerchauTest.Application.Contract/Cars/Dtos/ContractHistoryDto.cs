using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerchauTest.Application.Contract.Cars.Dtos
{
	public class ReportDto
	{
        public int TotalRentedCars { get; set; }
        public List<CustomerHistoryDto> CustomerHistory { get; set; }
    }
	public class CustomerHistoryDto
	{
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CustomerContractHistoryDto> Contracts { get; set; }
    }
    public class CustomerContractHistoryDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public long ContractId { get; set; }
        public int CarUsageKilometer { get; set; }
        public int UsedKilometerDuringContract { get; set; }
    }
}
