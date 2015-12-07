/*
Score:      100
Time:       235
Memory:     5124096
Points:     56.293
*/

using System.IO;
using System;
using System.Text;

class Program
{
	static int primeNumbersFound;
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\PrimeNumbers.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				primeNumbersFound = 0;		
				Console.WriteLine(CalcPrimeNumbers(Convert.ToInt64(line)));
			}
		}

		Console.ReadKey();
	}

	static string CalcPrimeNumbers(Int64 upTo)
	{
		StringBuilder rtn = new StringBuilder();

		for (int i = 0; i < upTo; i++)
		{
			bool isPrime = IsPrime(i);
			if (isPrime)
			{
				primeNumbersFound++;
				if (rtn.Length<=0)
				{
					rtn.Append(i);
				}
				else
				{
					rtn.Append("," + i);
				}
			}
		}

		return rtn.ToString();
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