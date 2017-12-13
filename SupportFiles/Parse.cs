using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFiles
{
	class Parse
	{
		/// <summary>
		/// Parse string to double. With 'AllowDecimalPoint' and 'InvariantCulture'
		/// </summary>
		public double? ParseDoubleWithOptions(string valueToParse)
		{
			var returnValue = 0.0;
			var tryParseSucced = double.TryParse(valueToParse, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out returnValue);
			if (tryParseSucced)
				return returnValue;
			return null;
		}
	}
}
