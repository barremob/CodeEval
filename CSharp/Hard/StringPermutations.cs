/*
Score:      100
Time:       243
Memory:     4882432
Points:     87.142
*/

using System.IO;
using System;
using System.Text;

class Program
{
	static string[] rtnStrings;
	static int currIndex = 0;
	static int permutationsNbr = 0;
	static StringBuilder strBuilder;

	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Hard\StringPermutations.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				char[] chars = line.ToCharArray();
				Array.Sort<char>(chars);
				currIndex = 0;
				permutationsNbr = CalcPermutationNbr(chars.Length);
				rtnStrings = new string[permutationsNbr];
				GetPermutation(chars, 0, chars.Length - 1);
				Array.Sort<string>(rtnStrings, StringComparer.Ordinal);
				strBuilder = new StringBuilder();

				for (int i = 0; i < rtnStrings.Length; i++)
				{
					strBuilder.Append(rtnStrings[i]);
					if (i < permutationsNbr-1)
					{
						strBuilder.Append(",");
					}
				}

				Console.WriteLine(strBuilder.ToString());
			}
		}

		Console.ReadKey();
	}
	
	static void GetPermutation(char[] characters, int start, int length)
	{
		if (start == length)
		{
			rtnStrings[currIndex] = new string(characters);
			currIndex++;
		}
		else
		{
			for (int i = start; i <= length; i++)
			{
				SwapChars(ref characters[start], ref characters[i]);
				GetPermutation(characters, start + 1, length);
				SwapChars(ref characters[start], ref characters[i]);
			}
		}
	}

	static void SwapChars(ref char a, ref char b)
	{
		if (a == b)
		{
			return;
		}
		char tmp = a;
		a = b;
		b = tmp;
	}

	static int CalcPermutationNbr(int nbr)
	{
		int rtnNbr = 0;
		for (int i = 0; i < nbr; i++)
		{
			if (rtnNbr <= 0)
			{
				rtnNbr += nbr;
			}
			else
			{
				rtnNbr *= (nbr - i);
			}
		}

		return rtnNbr;
	}
}