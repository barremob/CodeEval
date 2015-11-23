/*
Lower memory footprint by removing the string data array.

Score:      100
Time:       162
Memory:     4800512
Points:     87.744
*/

using System.IO;
using System;
class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Hard\SpiralPrinting.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] splitData = line.Split(';', ' ');

				int n = Convert.ToInt32(splitData[0]);
				int m = Convert.ToInt32(splitData[1]);
				string[,] inputData = new string[n, m];

				int row = 0;
				int col = 0;
				for (int i = 2; i < splitData.Length; i++)
				{
					inputData[row, col] = splitData[i];
					if (col == m - 1)
					{
						col = 0;
						row++;
					}
					else
					{
						col++;
					}
				}

				string returnData = "";
				int Offset = 0;
				row = 0;
				col = 0;

				bool reverse = false;

				for (int i = 0; i < n * m; i++)
				{
					if (returnData == "")
					{
						returnData += inputData[row, col];
					}
					else
					{
						returnData += " " + inputData[row, col];
					}

					if (reverse)
					{
						if (col == 0 + Offset)
						{
							if (row == 0 + Offset+1)
							{
								col++;
								reverse = false;
								Offset++;
                            }
							else
							{
								row--;
							}
						}
						else
						{
							col--;
						}
					}
					else
					{
						if (col == m - 1 - Offset)
						{
							if (row == n - 1 - Offset)
							{
								col--;
								reverse = true;
							}
							else
							{
								row++;
							}
						}
						else
						{
							col++;
						}
					}
				}

				Console.WriteLine(returnData);
			}
		}

		Console.ReadKey();
	}
}