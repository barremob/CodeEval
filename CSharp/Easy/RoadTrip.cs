/*
Score:      100
Time:       805
Memory:     4874240
Points:     29.038
*/

using System.IO;
using System;
using System.Text;

class Program
{
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

				string[] data = line.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);

				RoadTrip roadTrip = new RoadTrip();

				for (int i = 0; i < data.Length; i += 2)
				{
					roadTrip.Add(data[i], Convert.ToInt32(data[i + 1]));
				}

				Console.WriteLine(roadTrip.PrintRoute());
			}
		}

		Console.ReadKey();
	}
}

public class RoadTrip
{
	private string[] cities;
	private int[] distances;
	private int nextIndex = 0;

	public RoadTrip()
	{
		cities = new string[5];
		distances = new int[5];
	}

	public int Count
	{
		get { return nextIndex; }
	}

	public void Add(string city, int distance)
	{
		if (distances.Length == nextIndex)
		{
			ExpandArray();
		}

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

		cities[insertAtIndex] = city;
		distances[insertAtIndex] = distance;

		nextIndex++;
	}

	private void MoveItemsFrom(int fromIndex)
	{
		for (int i = nextIndex; i > fromIndex; i--)
		{
			cities[i] = cities[i - 1];
			distances[i] = distances[i - 1];
		}
	}
	
	public bool Contains(string item)
	{
		for (int i = 0; i < nextIndex; i++)
		{
			if (cities[i].Equals(item))
			{
				return true;
			}
		}

		return false;
	}

	public string PrintRoute()
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
				rtn.Append(distances[i]);
			}
			else
			{
				rtn.Append(distances[i] - distances[i - 1]);
			}

		}
		return rtn.ToString();
	}

	private void ExpandArray()
	{
		Array.Resize(ref cities, cities.Length * 2);
		Array.Resize(ref distances, distances.Length * 2);
	}
}