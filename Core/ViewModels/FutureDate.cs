using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.Core.ViewModels
{
	public class FutureDate : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			DateTime date;
			var isValid = DateTime.TryParseExact(Convert.ToString(value),
				"dd-MM-yyyy",
				CultureInfo.CurrentCulture,
				DateTimeStyles.None,out date) 
			              ||
				DateTime.TryParseExact(Convert.ToString(value),
					"d-M-yyyy",
					CultureInfo.CurrentCulture,
					DateTimeStyles.None, out date) 
			              ||
				DateTime.TryParseExact(Convert.ToString(value),
					"dd-M-yyyy",
					CultureInfo.CurrentCulture,
					DateTimeStyles.None, out date) 
			              ||
			DateTime.TryParseExact(Convert.ToString(value),
					"d-MM-yyyy",
					CultureInfo.CurrentCulture,
					DateTimeStyles.None, out date);

			return isValid && date > DateTime.Today;

		}
	}
}