/*
Score:      100
Time:       191
Memory:     4837376
Points:     56.882
*/

using System.IO;
using System;

class Program
{
	static string[] currency = { "ONE HUNDRED", "FIFTY", "TWENTY", "TEN", "FIVE", "TWO", "ONE", "HALF DOLLAR", "QUARTER", "DIME", "NICKEL", "PENNY" };
	static int[] values = { 10000, 5000, 2000, 1000, 500, 200, 100, 50, 25, 10, 5, 1 };

	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\CashRegister.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] input = line.Split(';');
				// Changed from float to decimal, rounding issues on CodeEval
				decimal price = Convert.ToDecimal(input[0]);
				decimal cash = Convert.ToDecimal(input[1]);

				if (cash < price)
				{
					Console.WriteLine("ERROR");
				}
				else if (cash == price)
				{
					Console.WriteLine("ZERO");
				}
				else
				{
					int change = (int)(cash * 100) - (int)(price * 100);
					int currIndex = 0;
					string returnData = "";

					while (change > 0)
					{
						if (change >= values[currIndex])
						{
							if (returnData == "")
							{
								returnData += currency[currIndex];
							}
							else
							{
								returnData += "," + currency[currIndex];
							}

							change -= values[currIndex];
						}
						else
						{
							currIndex++;
						}
					}

					Console.WriteLine(returnData);
				}
			}
		}

		Console.ReadKey();
	}
}