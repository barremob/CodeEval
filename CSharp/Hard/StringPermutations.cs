/*
Score:      32.5
Time:       169
Memory:     5005312
Points:     21.346
*/

using System.IO;
using System;

class Program
{
	static char[] rtnChars;
	static int currIndex = 0;
	static string rtnData = "";

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
				rtnData = "";
				currIndex = 0;
				int permutationsNbr = CalcPermutationNbr(chars.Length);

				rtnChars = new char[permutationsNbr * chars.Length];

				GetPermutation(chars, 0, chars.Length - 1);

				for (int i = 0; i < rtnChars.Length; i++)
				{
					if (i > chars.Length - 1 && i % chars.Length == 0)
					{
						rtnData += ",";
					}
					rtnData += rtnChars[i];
				}

				Console.WriteLine(rtnData);
			}
		}

		Console.ReadKey();
	}

	static void GetPermutation(char[] characters, int start, int length)
	{
		if (start == length)
		{
			Array.Copy(characters, 0, rtnChars, currIndex, characters.Length);
			currIndex += characters.Length;
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