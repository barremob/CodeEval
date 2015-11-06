/*
My first attempt to lower the memory usage. Cause I just want to stay above 30 points :P. 
On first run it took 1.6 seconds to run, which was incorrect. Run again and it was only 127ms

Score:      100
Time:       127
Memory:     5320704
Points:     30.337
*/

using System.IO;
using System;

class Program
{
	static QueryBoardCommands commands;
	static SimpleList<int> rows = new SimpleList<int>();
	static SimpleList<int> cols = new SimpleList<int>();
	static int[] rowsLastValue;
	static int[] colsLastValue;

	static int[,] matrix;

	static int matrixNormalSize = 256;

	static void Main(string[] args)
	{
		commands = new QueryBoardCommands();
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\QueryBoard.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] data = line.Split(' ');

				switch (data[0])
				{
					case "SetRow":
						int row = Convert.ToInt32(data[1]);
						commands.Add(1, row, Convert.ToByte(data[2]));
						if (!rows.Contains(row))
						{
							rows.Add(row);

						}
						//SetRow(Convert.ToInt32(data[1]), Convert.ToByte(data[2]));
						break;
					case "SetCol":
						int col = Convert.ToInt32(data[1]);
						commands.Add(2, col, Convert.ToByte(data[2]));
						if (!cols.Contains(col))
						{
							cols.Add(col);
						}
						//SetCol(Convert.ToInt32(data[1]), Convert.ToByte(data[2]));
						break;
					case "QueryRow":
						commands.Add(3, Convert.ToInt32(data[1]), 0);
						//Console.WriteLine(QueryRow(Convert.ToInt32(data[1])));
						break;
					case "QueryCol":
						commands.Add(4, Convert.ToInt32(data[1]), 0);
						//Console.WriteLine(QueryCol(Convert.ToInt32(data[1])));
						break;
				}
			}
		}

		matrix = new int[cols.Count, rows.Count];
		rowsLastValue = new int[rows.Count];
		colsLastValue = new int[cols.Count];

		for (int i = 0; i < commands.Count; i++)
		{
			switch (commands[i, 0])
			{
				case 1:// "SetRow":
					SetRow(commands[i, 1], commands[i, 2]);
					break;
				case 2:// "SetCol":
					SetCol(commands[i, 1], commands[i, 2]);
					break;
				case 3:// "QueryRow":
					Console.WriteLine(QueryRow(commands[i, 1]));
					break;
				case 4:// "QueryCol":
					Console.WriteLine(QueryCol(commands[i, 1]));
					break;
			}
		}

		Console.ReadKey();
	}

	static void SetRow(int row, int value)
	{
		int indexOfRow = rows.IndexOf(row);
		rowsLastValue[indexOfRow] = value;
		for (int i = 0; i < cols.Count; i++)
		{
			matrix[i, indexOfRow] = value;
		}
	}

	static void SetCol(int col, int value)
	{
		int indexOfCol = cols.IndexOf(col);
		colsLastValue[indexOfCol] = value;
		for (int i = 0; i < rows.Count; i++)
		{
			matrix[indexOfCol, i] = value;
		}
	}

	static int QueryRow(int row)
	{
		int rtn = 0;
		int indexOfRow = rows.IndexOf(row);
		if (indexOfRow < 0)
		{
			for (int i = 0; i < colsLastValue.Length; i++)
			{
				rtn += colsLastValue[i];
			}
		}
		else
		{
			for (int i = 0; i < cols.Count; i++)
			{
				rtn += matrix[i, indexOfRow];
			}
			rtn += (matrixNormalSize - cols.Count) * rowsLastValue[indexOfRow];
		}
		return rtn;
	}

	static int QueryCol(int col)
	{
		int rtn = 0;
		int indexOfCol = cols.IndexOf(col);
		if (indexOfCol < 0)
		{
			for (int i = 0; i < rowsLastValue.Length; i++)
			{
				rtn += rowsLastValue[i];
			}
		}
		else
		{
			for (int i = 0; i < rows.Count; i++)
			{
				rtn += matrix[indexOfCol, i];
			}
			rtn += (matrixNormalSize - rows.Count) * colsLastValue[indexOfCol];
		}
		return rtn;
	}
}

public class QueryBoardCommands
{
	private int[,] data;
	private int nextIndex = 0;
	private int currentSize = 5;
	const int depth = 3;

	public QueryBoardCommands()
	{
		data = new int[currentSize, depth];
	}

	public int Count
	{
		get { return nextIndex; }
	}

	public void Add(int action, int colRow, int value)
	{
		if (data.Length == nextIndex * depth)
		{
			ExpandArray();
		}
		data[nextIndex, 0] = action;
		data[nextIndex, 1] = colRow;
		data[nextIndex, 2] = value;
		nextIndex++;
	}

	private void ExpandArray()
	{
		currentSize *= 2;
		var newArray = new int[currentSize, depth];

		for (int i = 0; i < nextIndex; i++)
		{
			for (int x = 0; x < depth; x++)
			{
				newArray[i, x] = data[i, x];
			}
		}

		data = newArray;
	}

	public int this[int index, int item]
	{
		get { return data[index, item]; }
	}
}

public class SimpleList<T>
{
	private T[] data;
	private int nextIndex = 0;

	public SimpleList()
	{
		data = new T[5];
	}

	public int Count
	{
		get { return nextIndex; }
	}

	public void Add(T item)
	{
		if (data.Length == nextIndex)
		{
			ExpandArray();
		}
		data[nextIndex] = item;
		nextIndex++;
	}

	public bool Contains(T item)
	{
		for (int i = 0; i < nextIndex; i++)
		{
			if (data[i].Equals(item))
			{
				return true;
			}
		}
		return false;
	}

	public int IndexOf(T item)
	{
		return Array.IndexOf<T>(data, item);
	}

	private void ExpandArray()
	{
		Array.Resize(ref data, data.Length * 2);
	}

	public T this[int index]
	{
		get { return data[index]; }
	}
}