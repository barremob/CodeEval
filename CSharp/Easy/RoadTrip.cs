/*
Removed the auto expand for arrays, because there is a fixed maximum of 600.
Also remove the city names, not really needed for the output result.
Also tried to lower the memory use, but as usual CodeEval has some weird results.
After removing the cities array, it actually uses more memory.
--
Reuse the RoadTrip class, just reset the nextIndex to 0 with new input. Also didn't do shit!

Score:      100
Time:       802
Memory:     4874240
Points:     29.038
*/

using System.IO;
using System;
using System.Text;

class Program
{
	static RoadTrip roadTrip = new RoadTrip();

	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\RoadTrip.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				roadTrip.Reset();
				string[] data = line.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
				
				for (int i = 0; i < data.Length; i += 2)
				{
					roadTrip.Add(data[i], Convert.ToInt32(data[i + 1]));
				}

				roadTrip.PrintRoute();
            }
		}

		Console.ReadKey();
	}
}

public class RoadTrip
{
	private int[] distances;
	private int nextIndex = 0;

	public RoadTrip()
	{
		distances = new int[600];
	}
	
	public int Count
	{
		get { return nextIndex; }
	}

	public void Reset()
	{
		nextIndex = 0;
	}

	public void Add(string city, int distance)
	{
		int insertAtIndex = 0;
		for (int i = 0; i <= nextIndex; i++)
		{
			insertAtIndex = i;

			if (distances[i] > distance)
			{
				MoveItemsFrom(i);
				break;
			}
		}
		
		distances[insertAtIndex] = distance;
		nextIndex++;
	}
	
	private void MoveItemsFrom(int fromIndex)
	{
		Array.Copy(distances, fromIndex, distances, fromIndex + 1, nextIndex - fromIndex);
	}

	public void PrintRoute()
	{
		StringBuilder rtn = new StringBuilder();
		for (int i = 0; i < nextIndex; i++)
		{
			if (i <= nextIndex - 1 && i > 0)
			{
				rtn.Append(",");
			}
			if (i == 0)
			{
				rtn.Append(distances[i].ToString());
			}
			else
			{
				rtn.Append((distances[i] - distances[i - 1]).ToString());
			}
		}

		Console.WriteLine(rtn.ToString());
	}
}