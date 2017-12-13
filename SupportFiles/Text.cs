using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFiles
{
	public class Text
	{
		/// <summary>
		/// Replace accented letters with 'normal' ones
		/// </summary>
		public static string RemoveDiacritics(string text)
		{// Replaces accented letters with equivalent ones (normalizes the string)
			if (string.IsNullOrWhiteSpace(text)) return string.Empty;

			var normalizedString = text.Normalize(NormalizationForm.FormD);
			var stringBuilder = new StringBuilder();

			foreach (var character in normalizedString) {
				var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(character);
				if (unicodeCategory != UnicodeCategory.NonSpacingMark) {
					stringBuilder.Append(character);
				}
			}
			return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
		}
	}
}
