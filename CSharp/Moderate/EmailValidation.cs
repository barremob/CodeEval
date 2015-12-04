/*
Because I can't see the input of the data I'm not sure.
But there are more emails valid than most people would think.
The check below should be adequate, however I don't check the string after @

Score:      65
Time:       150
Memory:     4685824
Points:     37.212
*/

using System.IO;
using System;

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

				int indexOfAt = line.IndexOf('@');
				int lastIndexOfPoint = line.LastIndexOf('.');
				bool valid = indexOfAt > 0 && indexOfAt < lastIndexOfPoint;

				Console.WriteLine(valid ? "true" : "false");
			}
		}

		Console.ReadKey();
	}
}