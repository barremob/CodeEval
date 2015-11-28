/*
Score:      100
Time:       161
Memory:     4767744
Points:     30.739
*/

using System.IO;
using System;
using System.Text;

class Program
{
	static string[,] AppendNumbers = { 
		/* Zero */ { "-**--", "*--*-", "*--*-", "*--*-", "-**--", "-----" },
		/* One  */ { "--*--", "-**--", "--*--", "--*--", "-***-", "-----" },
		/* Two  */ { "***--", "---*-", "-**--", "*----", "****-", "-----" },
		/* Three*/ { "***--", "---*-", "-**--", "---*-", "***--", "-----" },
		/* Four */ { "-*---", "*--*-", "****-", "---*-", "---*-", "-----" },
		/* Five */ { "****-", "*----", "***--", "---*-", "***--", "-----" },
		/* Six  */ { "-**--", "*----", "***--", "*--*-", "-**--", "-----" },
		/* Seven*/ { "****-", "---*-", "--*--", "-*---", "-*---", "-----" },
		/* Eight*/ { "-**--", "*--*-", "-**--", "*--*-", "-**--", "-----" },
		/* Nine */ { "-**--", "*--*-", "-***-", "---*-", "-**--", "-----" },
	};

	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\BigDigits.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				char[] inputData = line.ToCharArray();
				int[] numbers = new int[inputData.Length];
				int currentIndex = 0;

				for (int i = 0; i < inputData.Length; i++)
				{
					int currentNbr = inputData[i] - 48;
					if (currentNbr > -1 && currentNbr < 10)
					{
						numbers[currentIndex] = currentNbr;
						currentIndex++;
					}
				}

				StringBuilder rtnString = new StringBuilder();

				for (int i = 0; i < 6; i++)
				{
					for (int x = 0; x < currentIndex; x++)
					{
						rtnString.Append(AppendNumbers[numbers[x],i]);
					}

					if (i<5)
					{
						rtnString.Append('\n');
					}
				}

				Console.WriteLine(rtnString.ToString());
			}

			Console.ReadKey();
		}
	}
}