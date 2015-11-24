/*
Score:      100
Time:       155
Memory:     4698112
Points:     30.807
*/

using System.IO;
using System;

class Program
{
	const string Append = "... <Read More>";
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Easy\ReadMore.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || line == "")
                {
                    continue;
                }

				if (line.Length <= 55)
				{
					Console.WriteLine(line);
				}
				else
				{
					Console.WriteLine(CutString(line) + Append);
				}                
            }
        }

        Console.ReadKey();
    }

	static string CutString(string inputData)
	{
		int cutAt = 0;
		for (int i = 39; i > 0; i--)
		{
			if (inputData[i] == ' ')
			{
				cutAt = i;
				break;
			}
		}

		if (cutAt <= 0)
		{
			cutAt = 40;
		}

		return inputData.Substring(0, cutAt);
	}
}