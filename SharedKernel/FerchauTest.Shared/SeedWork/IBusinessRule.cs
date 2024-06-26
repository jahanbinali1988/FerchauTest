﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerchauTest.Shared.SeedWork
{
	public interface IBusinessRule
	{
		Task<bool> IsBroken();

		string Message { get; }

		public string[] Properties { get; }

		public string ErrorType { get; }
	}
}
