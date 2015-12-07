/*
Score:      100
Time:       170
Memory:     4853760
Points:     56.924
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\CountingPrimes.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				Int64[] inputData = Array.ConvertAll<string, Int64>(line.Split(','), Int64.Parse);
                Console.WriteLine(CalcPrimeNumbersBetween(inputData[0], ++inputData[1]));
			}
		}

		Console.ReadKey();
	}

	static int CalcPrimeNumbersBetween(Int64 from, Int64 to)
	{
		int primeNumbersFound = 0;
		for (Int64 i = from; i < to; i++)
		{
			bool isPrime = IsPrime(i);
			if (isPrime)
			{
				primeNumbersFound++;
			}
		}

		return primeNumbersFound;
	}

	/// <summary>
	/// Compliments to http://www.dotnetperls.com/prime
	/// </summary>
	/// <param name="toTest"></param>
	/// <returns></returns>
	static bool IsPrime(Int64 toTest)
	{
		if ((toTest & 1) == 0)
		{
			if (toTest == 2)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		for (int i = 3; (i * i) <= toTest; i += 2)
		{
			if ((toTest % i) == 0)
			{
				return false;
			}
		}
		return toTest != 1;
	}
}