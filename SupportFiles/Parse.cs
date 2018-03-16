using System.Globalization;

namespace SupportFiles
{
	class Parse
	{
		/// <summary>
		/// Parse string to double. With 'AllowDecimalPoint' and 'InvariantCulture'
		/// </summary>
		/// <param name="valueToParse"></param>
		/// <returns>Returns null if conversion fails</returns>
		public double? ParseDoubleWithOptions(string valueToParse)
		{
			var tryParseSucced = double.TryParse(valueToParse
											, NumberStyles.AllowDecimalPoint
											, CultureInfo.InvariantCulture
											, out var returnValue);
			if (tryParseSucced)
			{
				return returnValue;
			}
			return null;
		}
	}
}
