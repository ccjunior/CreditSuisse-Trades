using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse_Trade.Data.Validate
{
   public static class Date
    {
		public static bool Validation(string data)
		{
			try
			{
				DateTime.Parse(data);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
