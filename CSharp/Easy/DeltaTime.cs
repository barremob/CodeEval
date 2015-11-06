/*
Different test, the last one used to much memory (compared to other tests!)
Could improve more, but who cares.

Score:      100
Time:       186
Memory:     4878336
Points:     30.602
*/

using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\DeltaTime.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] inputData = line.Split(' ');

				Console.WriteLine(DeltaTime(inputData[0], inputData[1]));
			}
		}

		Console.ReadKey();
	}

	static string DeltaTime(string a, string b)
	{
		int[] time = new int[2];
		time[0] = StrTimeToSeconds(a);
		time[1] = StrTimeToSeconds(b);

		int diff = 0;

		if (time[0] > time[1])
		{
			diff = time[0] - time[1];
		}
		else
		{
			diff = time[1] - time[0];
		}

		string rtnTime = SecondsToTimeStr(diff);

		return rtnTime;
	}

	static int StrTimeToSeconds(string time)
	{
		string[] _timeData = time.Split(':');
		int[] _time = Array.ConvertAll<string, int>(_timeData, int.Parse);
		int rtnSeconds = 0;

		rtnSeconds += _time[0] * 3600;
		rtnSeconds += _time[1] * 60;
		rtnSeconds += _time[2];

		return rtnSeconds;
	}

	static string SecondsToTimeStr(int seconds)
	{
		int[] _time = new int[3];
		int remainder = seconds;
		_time[0] = remainder / 3600;
		remainder -= _time[0] * 3600;
		_time[1] = remainder / 60;
		remainder -= _time[1] * 60;
		_time[2] = remainder;
		return string.Format("{0:D2}:{1:D2}:{2:D2}", _time[0], _time[1], _time[2]);
	}
}