/*
Score:      100
Time:       180
Memory:     4902912
Points:     30.592
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\CompressedSequence.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}
				
				string[] input = line.Split(' ');
				string output = "";
				if (input.Length > 1)
				{
					CompressedSequence cmpSeq = new CompressedSequence();
					for (int i = 0; i < input.Length; i++)
					{
						cmpSeq.Add(input[i]);
					}

					output = cmpSeq.GetSequence();
				}
				else
				{
					output = "1 " + input[0];
				}

				Console.WriteLine(output);
			}
		}

		Console.ReadKey();
	}
}

public class CompressedSequence
{
	int currentIndex = 0;
	string[] _data;
	int[] _occurence;

	public CompressedSequence()
	{
		_data = new string[16];
		_occurence = new int[16];
	}

	public void Add(string data)
	{
		if (_data[currentIndex] == null)
		{
			_data[currentIndex] = data;
			_occurence[currentIndex]++;
			return;
		}
		else if (_data[currentIndex] == data)
		{
			_occurence[currentIndex]++;
		}
		else
		{
			currentIndex++;

			if (currentIndex >= _data.Length)
			{
				Resize();
			}

			_data[currentIndex] = data;
			_occurence[currentIndex]++;
		}
	}

	public string GetSequence()
	{
		string rtn = "";
		for (int i = 0; i <= currentIndex; i++)
		{
			if (rtn == "")
			{
				rtn += _occurence[i] + " " + _data[i];
			}
			else
			{
				rtn += " " + _occurence[i] + " " + _data[i];
			}
		}
		return rtn;
	}

	private void Resize()
	{
		Array.Resize<string>(ref _data, _data.Length * 2);
		Array.Resize<int>(ref _occurence, _occurence.Length * 2);
	}
}