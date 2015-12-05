/*
Score:      100
Time:       167
Memory:     4845568
Points:     56.945
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\Pangrams.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				bool[] alpha = new bool[26];
				char[] chars = line.ToLower().ToCharArray();

				for (int i = 0; i < chars.Length; i++)
				{
					if (chars[i] >= 97 && chars[i] <= 122)
					{
						int index = chars[i] - 97;
						alpha[index] = true;
					}
				}

				string rtn = "";

				for (int i = 0; i < 26; i++)
				{
					if (alpha[i] == false)
					{
						rtn += (char)(i + 97);
					}
				}

				if (rtn == "")
				{
					rtn = "NULL";
				}

				Console.WriteLine(rtn);
			}
		}

		Console.ReadKey();
	}
}