/*
Score:      100
Time:       157
Memory:     4857856
Points:     30.670
*/

using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\DataRecovery.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}
				string[] inputData = line.Split(';');
				string OrderedWords = OrderWords(inputData[0], inputData[1]);
				Console.WriteLine(OrderedWords);
			}
		}

		Console.ReadKey();
	}

	static string OrderWords(string sentence, string order)
	{
		string[] _sentence = sentence.Split(' ');
		string[] _order = order.Split(' ');
		string[] _return = new string[_sentence.Length];

		int[] _orderI = Array.ConvertAll<string, int>(_order, int.Parse);
		int total = 0;
		int shouldHave = (_sentence.Length * (_sentence.Length + 1)) / 2;
		for (int i = 0; i < _order.Length; i++)
		{
			_return[_orderI[i] - 1] = _sentence[i];
			total += _orderI[i];
		}

		_return[shouldHave - total - 1] = _sentence[_sentence.Length - 1];

		string rtn = "";
		for (int i = 0; i < _return.Length; i++)
		{
			if (i > 0 && i < _return.Length)
			{
				rtn += " ";
			}
			rtn += _return[i];
		}

		return rtn;
	}
}

