/*
Score:      100
Time:       244
Memory:     4870144
Points:     30.508
*/

using System;
using System.IO;


class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		
		using (StreamReader reader = File.OpenText(@"Easy\JsonMenuIds.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}
				int sumOf = GetIdSumFromJson(line);
				Console.WriteLine(sumOf);
			}
		}

		Console.ReadKey();
	}

	/*static int GetIdSumFromJson(string JsonData)
	{
		int counter = 0;
		int indexBegin = JsonData.IndexOf('[');
		int indexEnd = JsonData.IndexOf(']');
		string strippedData = JsonData.Substring(indexBegin, indexEnd - indexBegin + 1);
		
		string[] jsonParts = strippedData.Split(new string[] { @"""id"":" }, StringSplitOptions.None);
		for (int i = 1; i < jsonParts.Length; i++)
		{
			if (jsonParts[i].IndexOf(@"label")<=0)
			{
				continue;
			}
			string[] labelParts = jsonParts[i].Split(new string[] { @"Label" }, StringSplitOptions.None);
			for (int x = 0; x < labelParts.Length; x++)
			{
				int indexLabel = labelParts[x].IndexOf(@"label");
				if (indexLabel > 0)
				{
					string addToSum = labelParts[x].Substring(0, indexLabel - 3);
					counter += Convert.ToInt32(addToSum);
				}
			}
		}

		return counter;
	}*/
	
	static int GetIdSumFromJson(string JsonData)
	{
		int counter = 0;
		string[] jsonParts = JsonData.Split(new string[] { @"""id"":" }, StringSplitOptions.None);
		for (int i = 1; i < jsonParts.Length; i++)
		{
			string[] labelParts = jsonParts[i].Split(new string[] { @"Label" }, StringSplitOptions.None);
			for (int x = 0; x < labelParts.Length; x++)
			{
				int indexLabel = labelParts[x].IndexOf(@"label");
				if (indexLabel > 0)
				{
					string addToSum = labelParts[x].Substring(0, indexLabel - 3);
					counter += Convert.ToInt32(addToSum);
				}
			}
		}

		return counter;
	}
}

