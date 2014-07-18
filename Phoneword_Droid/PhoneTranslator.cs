using System.Text;
using System;

namespace Core
{
	public static class PhoneTranslator
	{
		private static String numberVar = " -0123456789";

		public static String translate (String raw)
		{
			if (string.IsNullOrWhiteSpace (raw))
				return "";
			else
				raw = raw.ToUpperInvariant();


			var newNumber = new StringBuilder ();

			foreach (var c in raw) {
				String cString = c.ToString ();
				if (numberVar.Contains (cString))
					newNumber.Append (c);
				else {
					var result = TranslateToNumber( cString);
					if (result != null)
						newNumber.Append (result);
					// otherwise we've skipped aF non-numeric char
				}



			}
			return newNumber.ToString();
		}



		private static int? TranslateToNumber(String c)
		{
			if ("ABC".Contains(c))
				return 2;
			else if ("DEF".Contains(c))
				return 3;
			else if ("GHI".Contains(c))
				return 4;
			else if ("JKL".Contains(c))
				return 5;
			else if ("MNO".Contains(c))
				return 6;
			else if ("PQRS".Contains(c))
				return 7;
			else if ("TUV".Contains(c))
				return 8;
			else if ("WXYZ".Contains(c))
				return 9;
			return null;

		}
	}
}

