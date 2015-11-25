/*
Score:      100
Time:       773
Memory:     5103616
Points:     29.387
*/

using System.IO;
using System;

class Program
{
	static SimpleList inputDatas = new SimpleList();
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\TheMajorElement.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();

				if (null == line || line == "")
				{
					continue;
				}

				int numberCount = 0;
				int indexCount = 0;

				inputDatas.Reset();
				string number = "";
				while (indexCount <= line.Length)
				{
					if (indexCount == line.Length || line[indexCount] == ',')
					{
						inputDatas.Add(Convert.ToInt32(number));
						number = "";
						indexCount++;
						numberCount++;
					}
					else
					{
						number += line[indexCount];
						indexCount++;
					}
				}

				int highestNumberIndex;
				int highestNumber = inputDatas.GetHighestCount(out highestNumberIndex);

				if (highestNumber >= numberCount / 2)
				{
					Console.WriteLine(inputDatas[highestNumberIndex]);
				}
				else
				{
					Console.WriteLine("None");
				}
			}
		}

		Console.ReadKey();
	}
}

public class SimpleList
{
	private int[] data;
	private int[] count;
	private int nextIndex = 0;

	int lastItem = -1;
	int lastIndex = 0;

	public SimpleList()
	{
		data = new int[101];
		count = new int[101];
	}

	public void Add(int item)
	{
		if (data.Length <= nextIndex)
		{
			ExpandArray();
		}

		int indexOfItem;
		if (lastItem == item)
		{
			indexOfItem = lastIndex;
		}
		else
		{
			lastItem = item;
			indexOfItem = IndexOf(item);
		}

		if (indexOfItem >= 0)
		{
			count[indexOfItem]++;
			lastIndex = indexOfItem;
		}
		else
		{
			data[nextIndex] = item;
			count[nextIndex]++;
			lastIndex = nextIndex;
			nextIndex++;
		}
	}

	public void Reset()
	{
		nextIndex = 0;
		lastIndex = -1;
		lastIndex = 0;
		count = new int[count.Length];
	}

	public int GetHighestCount(out int index)
	{
		int rtnNbr = 0;
		index = -1;
		for (int i = 0; i < count.Length; i++)
		{
			if (count[i] > rtnNbr)
			{
				rtnNbr = count[i];
				index = i;
			}
		}

		return rtnNbr;
	}

	private void ExpandArray()
	{
		Array.Resize(ref data, data.Length * 2);
		Array.Resize(ref count, count.Length * 2);
	}

	public int IndexOf(int item)
	{
		for (int i = 0; i < nextIndex; i++)
		{
			if (data[i] == item)
			{
				return i;
			}
		}

		return -1;
	}

	public int this[int index]
	{
		get { return data[index]; }
	}
}