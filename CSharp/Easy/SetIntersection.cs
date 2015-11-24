/*
Pff, had some issues with this.
In the end I forgot the convert the strings to ints.

Score:      100
Time:       177
Memory:     4804608
Points:     30.681
*/

using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\SetIntersection.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] inputData = line.Split(';');
				int[] leftSide = Array.ConvertAll<string, int>(inputData[0].Split(','), int.Parse);
				int[] rightSide = Array.ConvertAll<string, int>(inputData[1].Split(','), int.Parse);

				int leftIndex = 0, rightIndex = 0;
				var intersection = new int[leftSide.Length];
				int indexOfIntersect = 0;

				while (leftIndex < leftSide.Length && rightIndex < rightSide.Length)
				{
					int compare = leftSide[leftIndex].CompareTo(rightSide[rightIndex]);
					if (compare < 0)
					{
						leftIndex++;
					}
					else if (compare > 0)
					{
						rightIndex++;
					}
					else
					{
						intersection[indexOfIntersect] = leftSide[leftIndex];
						indexOfIntersect++;
						leftIndex++;
						rightIndex++;
					}
				}

				string rtnData = "";
				for (int i = 0; i < indexOfIntersect; i++)
				{
					if (rtnData == "")
					{
						rtnData += intersection[i];
					}
					else
					{
						rtnData += "," + intersection[i];
					}
				}

				Console.WriteLine(rtnData);
			}
		}

		Console.ReadKey();
	}
}