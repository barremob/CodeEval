/*
Previous version wasn't good, so this one uses the microsoft check.
But still not good enough, next are the slow regex expressions.

Score:      90
Time:       158
Memory:     4775936
Points:     51.376
*/

using System.IO;
using System;
using System.Net.Mail;

class Program
{
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
		try
		{
			MailAddress address = new MailAddress(email);
			return true;
		}
		catch (FormatException)
		{
			return false;
		}
	}
}