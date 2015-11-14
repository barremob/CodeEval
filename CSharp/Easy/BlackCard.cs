/*
Score:      100
Time:       164
Memory:     4743168
Points:     30.754
*/

using System.IO;
using System;

class Program
{
	static SimpleList inputData = new SimpleList();
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\BlackCard.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				inputData.Reset();

				string[] inData = line.Split('|', ' ');

				for (int i = 0; i < inData.Length - 1; i++)
				{
					if (inData[i] != "")
					{
						inputData.Add(inData[i]);
					}
				}

				Console.WriteLine(GetLastStanding(Convert.ToInt32(inData[inData.Length - 1])));
			}
		}

		Console.ReadKey();
	}

	static string GetLastStanding(int number)
	{
		int removeIndex;
		while (inputData.Count > 1)
		{
			removeIndex = number;
			while (removeIndex > inputData.Count)
			{
				removeIndex -= inputData.Count;
			}

			inputData.RemoveByIndex(removeIndex - 1);
		}
		return inputData[0];
	}
}

public class SimpleList
{
	private string[] data;
	private int nextIndex = 0;

	public SimpleList()
	{
		data = new string[5];
	}

	public int Count
	{
		get { return nextIndex; }
	}

	public void Add(string item)
	{
		if (data.Length == nextIndex)
		{
			ExpandArray();
		}
		data[nextIndex] = item;
		nextIndex++;
	}

	public void RemoveByIndex(int index)
	{
		Array.Copy(data, index + 1, data, index, nextIndex - index - 1);
		nextIndex--;
	}

	public void Reset()
	{
		nextIndex = 0;
	}

	private void ExpandArray()
	{
		Array.Resize(ref data, data.Length * 2);
	}

	public string this[int index]
	{
		get { return data[index]; }
	}
}