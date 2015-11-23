/*
Score:      100
Time:       158
Memory:     4841472
Points:     30.683
*/

using System.IO;
using System;

class Program
{
	static string[] slangPhrases = { ", yeah!", ", this is crazy, I tell ya.", ", can U believe this?", ", eh?", ", aw yea.", ", yo.", "? No way!", ". Awesome!" };
	static int currSlangIndex = 0;

	static char[] puncts = { '.', '?', '!' };
	static bool change = false;

	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\SlangFlavor.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}

				int indexOfChar = 0;

				string printData = "";

				while (indexOfChar < line.Length)
				{
					indexOfChar = IndexOfAny(line, indexOfChar + 1);

					if (change == false)
					{
						printData += line.Substring(0, indexOfChar + 1);
						line = line.Substring(indexOfChar + 1, line.Length - indexOfChar - 1);
						indexOfChar = 0;
						change = true;
					}
					else
					{
						printData += line.Substring(0, indexOfChar);
						printData += slangPhrases[currSlangIndex];
						line = line.Substring(indexOfChar + 1, line.Length - indexOfChar - 1);

						if (currSlangIndex < slangPhrases.Length - 1)
						{
							currSlangIndex++;
						}
						else
						{
							currSlangIndex = 0;
						}

						indexOfChar = 0;
						change = false;
					}
				}


				Console.WriteLine(printData);
			}
		}
		Console.ReadKey();
	}

	public static int IndexOfAny(string test, int startIndex)
	{
		int first = -1;
		foreach (char item in puncts)
		{
			int i = test.IndexOf(item, startIndex);
			if (i >= 0)
			{
				if (first > 0)
				{
					if (i < first)
					{
						first = i;
					}
				}
				else
				{
					first = i;
				}
			}
		}
		return first;
	}
}