/*
Score:      100
Time:       160
Memory:     4788224
Points:     57.059
*/

using System.IO;
using System;

class Program
{
	static int printLines = 0;
	static int index = 0;
	static string[] inputLines = new string[50];
	static string[] rtnLines;

    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Moderate\LongestLines.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || line == "")
                {
                    continue;
                }
				if (printLines==0)
				{
					printLines = Convert.ToInt32(line);
				}

				inputLines[index] = line;
				index++;

            }
        }

		rtnLines = new string[index];

		for (int i = 0; i < index; i++)
		{
			rtnLines[i] = inputLines[i];
		}

		OrderLines();

		for (int i = 0; i < printLines; i++)
		{
			Console.WriteLine(rtnLines[i]);
		}

        Console.ReadKey();
    }

	static void OrderLines()
	{
		Array.Sort(rtnLines, (x, y) => y.Length.CompareTo(x.Length));
	}
}