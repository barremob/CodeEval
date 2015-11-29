/*
Score:      100
Time:       167
Memory:     5181440
Points:     30.382
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\MatrixRotation.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] inputData = line.Split(' ');
				int n = (int)Math.Sqrt((double)inputData.Length);

				string rtnData = "";

				for (int i = 0; i < n; i++)
				{
					for (int x = n - 1; x >= 0; x--)
					{
						if (x < n - 1)
						{
							rtnData += " ";
						}
						int index = (x * n) + i;
						rtnData += inputData[index];
					}

					if (i < n - 1)
					{
						rtnData += " ";
					}
				}

				Console.WriteLine(rtnData);
			}

			Console.ReadKey();
		}
	}
}