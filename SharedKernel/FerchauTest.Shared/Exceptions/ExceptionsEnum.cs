namespace FerchauTest.Shared.Exceptions
{
	public enum ExceptionsEnum : int
	{
		InvalidPhoneNumberException,
		InvalidEmailException,
		InvalidBankAccountNumberException,
		DuplicatedEmailException,
		CustomerDuplicatedException,
		UnableToFindCustomerException,
		PhoneNumberIsNotMobileException,
		PhoneNumberLengthIsLongerThanLimitationException,
		EmailLengthIsLongerThanLimitationException,
		BankAccountNumberLengthIsLongerThanLimitationException,
		FirstNameLengthIsLongerThanLimitationException,
		LastNameLengthIsLongerThanLimitationException
	}
}
