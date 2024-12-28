using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class GeneralService
    {
        public static bool IsNaturalNumber(string s)
        {
            if (int.TryParse(s, out int i) && i >= 0)
            {
                return true;
            }
            else
                return false;
        }

        public static DateTimeOffset LocalDateTimeOffset()
        {
            return DateTimeOffset.UtcNow.ToLocalTime();
        }

        public static decimal ConvertFormattedStringToDecimal(string formattedString)
        {
            // Remove the currency symbol and any other non-numeric characters
            string cleanedString = formattedString.Replace("₫", "").Trim();
            cleanedString = cleanedString.Replace(".", "");

            // Parse the cleaned string to decimal
            if (decimal.TryParse(cleanedString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
            {
                return value;
            }
            else
            {
                throw new FormatException("The input string is not in a correct format.");
            }
        }


    }
}
