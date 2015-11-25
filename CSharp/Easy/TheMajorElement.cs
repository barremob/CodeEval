/*
Score:      100
Time:       1091
Memory:     5173248
Points:     28.773
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

	public SimpleList()
	{
		data = new int[100];
		count = new int[100];
	}

	public void Add(int item)
	{
		if (data.Length < nextIndex)
		{
			ExpandArray();
		}
		if (Contains(item))
		{
			int indexOfItem = IndexOf(item);
			count[indexOfItem]++;
		}
		else
		{
			data[nextIndex] = item;
			count[nextIndex]++;
			nextIndex++;
		}
	}

	public bool Contains(int item)
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

	public void Reset()
	{
		nextIndex = 0;
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