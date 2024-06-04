using FerchauTest.Domain.Customers.ValueObjects;
using FerchauTest.Shared.SeedWork;
using FerchauTest.Shared.Shared;

namespace FerchauTest.Domain.Customers
{
    public class Customer : Entity<long>, IAggregateRoot
	{
        private Customer()
        {
            
        }
        private Customer(string firstname, string lastname, string phonenumber, IIdGenerator idGenerator)
        {
			SetId(idGenerator);
            SetFirstName(firstname); 
            SetLastName(lastname); 
            SetPhoneNumber(phonenumber);
		}

        public FirstName Firstname { get; private set; }
		public LastName Lastname { get; private set; }
		public PhoneNumber PhoneNumber { get; private set; }

		#region PrivateMethods
		private void SetId(IIdGenerator idGenerator) => base.Id = idGenerator.GetNewId();
		private void SetFirstName(string firstname) => Firstname = firstname;
		private void SetLastName(string lastname) => Lastname = lastname;
		private void SetPhoneNumber(string Phonenumber) => PhoneNumber = Phonenumber;
		#endregion

		#region PublicMethods
		public static Customer Create(string firstname, string lastname, string phonenumber, IIdGenerator idGenerator)
		{
			return new Customer(firstname, lastname, phonenumber, idGenerator);
		}
		#endregion
	}
}
