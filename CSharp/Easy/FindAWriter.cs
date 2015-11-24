/*
Score:      100
Time:       155
Memory:     4763648
Points:     30.754
*/

using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\FindAWriter.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] inputData = line.Split('|');

				char[] charList = inputData[0].ToCharArray();
				int[] numberList = Array.ConvertAll<string, int>(inputData[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
				string returnData = "";


				for (int i = 0; i < numberList.Length; i++)
				{
					returnData += charList[numberList[i] - 1];
				}


				Console.WriteLine(returnData);
			}
		}

		Console.ReadKey();
	}
}