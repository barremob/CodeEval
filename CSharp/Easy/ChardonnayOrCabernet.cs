/*
Score:      100
Time:       204
Memory:     5046272
Points:     30.430
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\ChardonnayOrCabernet.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] inputData = line.Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
				char[] remLetters = inputData[inputData.Length - 1].ToCharArray();

				string rtnData = "";
				for (int i = 0; i < inputData.Length - 1; i++)
				{
					if (ContainsAllLetters(inputData[i], remLetters))
					{
						if (rtnData == "")
						{
							rtnData += inputData[i];
						}
						else
						{
							rtnData += " " + inputData[i];
						}
					}
				}
				
				Console.WriteLine(rtnData == "" ? "False" : rtnData);
			}

			Console.ReadKey();
		}
	}

	static bool ContainsAllLetters(string inputData, char[] letters)
	{
		char[] uniqueChars = new char[letters.Length];
		int[] occurenceChar = new int[letters.Length];
		int currentIndex = 0;

		// Get unique characters
		for (int i = 0; i < letters.Length; i++)
		{
			int indexOfChar = Array.IndexOf<char>(uniqueChars, letters[i]);
			if (indexOfChar > -1)
			{
				occurenceChar[indexOfChar]++;
			}
			else
			{
				uniqueChars[currentIndex] = letters[i];
				occurenceChar[currentIndex]++;
				currentIndex++;
			}
		}

		for (int i = 0; i < currentIndex; i++)
		{
			int occurenceInput = inputData.Length - inputData.Replace(uniqueChars[i].ToString(), "").Length;
			if (occurenceInput < occurenceChar[i])
			{
				return false;
			}
		}

		return true;
	}
}