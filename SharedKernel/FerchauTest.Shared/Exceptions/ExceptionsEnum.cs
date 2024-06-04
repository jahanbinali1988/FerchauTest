namespace FerchauTest.Shared.Exceptions
{
	public enum ExceptionsEnum : int
	{
		PhoneNumberLengthIsLongerThanLimitationException,
		FirstNameLengthIsLongerThanLimitationException,
		LastNameLengthIsLongerThanLimitationException,
		CustomerIdDoesNotExistException,
		ContractIsNotExistedException,
		CarHasUnfinishedContractException,
		BrandLengthIsLongerThanLimitationException,
		ModelLengthIsLongerThanLimitationException,
		UnableToFindCustomerException
	}
}
