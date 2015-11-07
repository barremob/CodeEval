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
	static SimpleList<byte> rows = new SimpleList<byte>();
	static SimpleList<byte> cols = new SimpleList<byte>();
	static byte[] rowsLastValue;
	static byte[] colsLastValue;

	static byte[,] matrix;

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
						byte row = Convert.ToByte(data[1]);
						commands.Add(1, row, Convert.ToByte(data[2]));
						if (!rows.Contains(row))
						{
							rows.Add(row);

						}
						break;
					case "SetCol":
						byte col = Convert.ToByte(data[1]);
						commands.Add(2, col, Convert.ToByte(data[2]));
						if (!cols.Contains(col))
						{
							cols.Add(col);
						}
						break;
					case "QueryRow":
						commands.Add(3, Convert.ToByte(data[1]), 0);
						break;
					case "QueryCol":
						commands.Add(4, Convert.ToByte(data[1]), 0);
						break;
				}
			}
		}

		matrix = new byte[cols.Count, rows.Count];
		rowsLastValue = new byte[rows.Count];
		colsLastValue = new byte[cols.Count];

		for (byte i = 0; i < commands.Count; i++)
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

	static void SetRow(byte row, byte value)
	{
		int indexOfRow = rows.IndexOf(row);
		rowsLastValue[indexOfRow] = value;
		for (int i = 0; i < cols.Count; i++)
		{
			matrix[i, indexOfRow] = value;
		}
	}

	static void SetCol(byte col, byte value)
	{
		int indexOfCol = cols.IndexOf(col);
		colsLastValue[indexOfCol] = value;
		for (int i = 0; i < rows.Count; i++)
		{
			matrix[indexOfCol, i] = value;
		}
	}

	static int QueryRow(byte row)
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

	static int QueryCol(byte col)
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
	private byte[,] data;
	private int nextIndex = 0;
	private int currentSize = 160;
	const int depth = 3;

	public QueryBoardCommands()
	{
		data = new byte[currentSize, depth];
	}

	public int Count
	{
		get { return nextIndex; }
	}

	public void Add(byte action, byte colRow, byte value)
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
		var newArray = new byte[currentSize, depth];

		for (int i = 0; i < nextIndex; i++)
		{
			for (int x = 0; x < depth; x++)
			{
				newArray[i, x] = data[i, x];
			}
		}

		data = newArray;
	}

	public byte this[byte index, byte item]
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
		data = new T[40];
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