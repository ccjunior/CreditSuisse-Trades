using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse_Trade.Data.Validate
{
    public static class Numeric
    {
        public static string InputValidate()
        {
            ConsoleKeyInfo promptInfo;
            string input = "";
            bool flagValidate = true;
            while (flagValidate)
            {
                promptInfo = Console.ReadKey(true);
				switch (promptInfo.Key)
				{
					case ConsoleKey.Backspace:
						if (input.Length == 0) continue;
						input = input.Remove(input.Length - 1);
						Console.Write("\b \b");
						break;
					case ConsoleKey.Enter:
						flagValidate = false;
						break;
					case ConsoleKey key when ((ConsoleKey.D0 <= key) && (key <= ConsoleKey.D9) ||
												  (ConsoleKey.NumPad0 <= key) && (key <= ConsoleKey.NumPad9)):
						input += promptInfo.KeyChar;
						Console.Write(promptInfo.KeyChar);
						break;
				}
			}
			return input;
		}

		public static bool NumericValid(string info)
		{
			try
			{
				double.Parse(info);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
