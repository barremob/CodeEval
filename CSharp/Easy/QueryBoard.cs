/*
Score:      100
Time:       252
Memory:     5464064
Points:     29.999
*/

using System.IO;
using System;

class Program
{
	static byte[,] matrix;

	static void Main(string[] args)
	{
		matrix = new byte[256,256];
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\QueryBoard.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}

				string[] data = line.Split(' ');

				switch (data[0])
				{
					case "SetRow":
						SetRow(Convert.ToInt32(data[1]), Convert.ToByte(data[2]));
						break;
					case "SetCol":
						SetCol(Convert.ToInt32(data[1]), Convert.ToByte(data[2]));
						break;
					case "QueryRow":
						Console.WriteLine(QueryRow(Convert.ToInt32(data[1])));
						break;
					case "QueryCol":
						Console.WriteLine(QueryCol(Convert.ToInt32(data[1])));
						break;
				}
			}
		}

		Console.ReadKey();
	}

	static void SetRow(int row, byte value)
	{
		for (int i = 0; i < 256; i++)
		{
			/*if (matrix[i] == null)
			{
				matrix[i] = new byte[256];
			}*/
			matrix[i,row] = value;
		}
	}

	static void SetCol(int col, byte value)
	{
		/*if (matrix[col] == null)
		{
			matrix[col] = new byte[256];
		}*/
		for (int i = 0; i < 256; i++)
		{
			matrix[col,i] = value;
		}
	}

	static int QueryRow(int row)
	{
		int rtn = 0;
		for (int i = 0; i < 256; i++)
		{
			rtn += matrix[i,row];
		}
		return rtn;
	}

	static int QueryCol(int col)
	{
		int rtn = 0;
		for (int i = 0; i < 256; i++)
		{
			rtn += matrix[col,i];
		}
		return rtn;
	}
}
