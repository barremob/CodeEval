/*
Score:      100
Time:       152
Memory:     4743168
Points:     57.152
*/

using System.IO;
using System;

class Program
{
	static char[] removeChars;
	static SimpleList list = new SimpleList();

	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\RemoveCharacters.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				list.Reset();
				string[] inputData = line.Split(',');
				removeChars = inputData[1].ToCharArray();
				
				for (int i = 0; i < inputData[0].Length; i++)
				{
					if (!RemoveChar(inputData[0][i]))
					{
						list.Add(inputData[0][i]);
					}
				}

				Console.WriteLine(list.data);
			}
		}

		Console.ReadKey();
	}

	static bool RemoveChar(char test)
	{
		for (int i = 1; i < removeChars.Length; i++)
		{
			if (test == removeChars[i])
			{
				return true;
			}
		}

		return false;
	}
}

public class SimpleList
{
	char[] charArray;
	int nextIndex = 0;

	public char[] data {
		get {
			char[] rtnData = new char[nextIndex];
			Array.Copy(charArray, rtnData, nextIndex);
            return rtnData;
		}
	}

	public SimpleList()
	{
		charArray = new char[25];
	}

	public void Add(char character)
	{
		if (nextIndex>= charArray.Length)
		{
			Resize();
		}

		charArray[nextIndex] = character;
		nextIndex++;
	}

	public void Reset()
	{
		nextIndex = 0;
	}

	private void Resize()
	{
		Array.Resize<char>(ref charArray, charArray.Length * 2);
	}
}