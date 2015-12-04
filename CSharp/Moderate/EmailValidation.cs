/*
Score:      100
Time:       357
Memory:     5406720
Points:     55.460
*/

using System.IO;
using System;
using System.Text.RegularExpressions;

class Program
{
	static Regex regex = new Regex(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
	 + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
	 + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
	 + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$", RegexOptions.IgnoreCase);

	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\EmailValidation.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				Console.WriteLine(CheckEmail(line) ? "true" : "false");
			}
		}

		Console.ReadKey();
	}

	public static bool CheckEmail(string email)
	{
		Match match = regex.Match(email);
		if (match.Success)
			return true;
		else
			return false;
	}
}