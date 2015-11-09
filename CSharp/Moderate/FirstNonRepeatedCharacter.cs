/*
Score:      100
Time:       149
Memory:     4739072
Points:     57.169
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\FirstNonRepeatedCharacter.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				FirstNonRepeatingChar firstNonRep = new FirstNonRepeatingChar(line);
				Console.WriteLine(firstNonRep.GetChar());
			}
		}
		
		Console.ReadKey();
	}
}

public class FirstNonRepeatingChar
{
	private char[] data;
	private byte[] dataCount;
	private int nextIndex = 0;

	public FirstNonRepeatingChar(string inputData)
	{
		data = new char[36];
		dataCount = new byte[36];
		for (int i = 0; i < inputData.Length; i++)
		{
			if (!Contains(inputData[i]))
			{
				Add(inputData[i]);
			}
			dataCount[IndexOf(inputData[i])]++;
		}
	}
	
	public void Add(char item)
	{
		data[nextIndex] = item;
		nextIndex++;
	}

	public bool Contains(char item)
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

	public int IndexOf(char item)
	{
		for (int i = 0; i < nextIndex; i++)
		{
			if (data[i]==item)
			{
				return i;
			}
		}

		return -1;
	}

	public char GetChar()
	{
		for (int i = 0; i < nextIndex; i++)
		{
			if (dataCount[i]==1)
			{
				return data[i];
			}
		}

		return '!';
	}
}