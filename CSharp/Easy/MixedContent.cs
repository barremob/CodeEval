/*
Score:      100
Time:       179
Memory:     4857856
Points:     30.633
*/

using System.IO;
using System;

class Program
{
	static SimpleList<int> numbers = new SimpleList<int>();
	static SimpleList<string> strings = new SimpleList<string>();
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\MixedContent.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				numbers.Reset();
				strings.Reset();

				string[] data = line.Split(',');
				int result = 0;

				for (int i = 0; i < data.Length; i++)
				{
					if (int.TryParse(data[i], out result))
					{
						numbers.Add(result);
					}
					else
					{
						strings.Add(data[i]);
					}
				}

				string rtnStr = "";
				for (int i = 0; i < strings.Count; i++)
				{
					if (i == 0)
					{
						rtnStr += strings[i];
					}
					else
					{
						rtnStr += "," + strings[i];
					}
				}
				string rtnNum = "";
				for (int i = 0; i < numbers.Count; i++)
				{
					if (i == 0)
					{
						rtnNum += numbers[i];
					}
					else
					{
						rtnNum += "," + numbers[i];
					}
				}

				if (rtnStr == "")
				{
					Console.WriteLine(rtnNum);
				}
				else if (rtnNum == "")
				{
					Console.WriteLine(rtnStr);
				}
				else
				{
					Console.WriteLine(rtnStr + "|" + rtnNum);
				}
			}
		}


		Console.ReadKey();
	}
}

public class SimpleList<T>
{
	private T[] data;
	private int nextIndex = 0;

	public SimpleList()
	{
		data = new T[8];
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

	public void Reset()
	{
		nextIndex = 0;
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