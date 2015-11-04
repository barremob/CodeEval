/*
Score:      100
Time:       167
Memory:     5185536
Points:     30.380
*/

using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Easy\SwapElements.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                {
                    continue;
                }

				string[] inputData = line.Split(':');
				string[] inpNbs = inputData[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				string[] inpSwap = inputData[1].Split(new char[] { '-', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
				int[] inputSwap = Array.ConvertAll<string, int>(inpSwap, int.Parse);

				for (int i = 0; i < inpSwap.Length; i+=2)
				{
					string tmp = inpNbs[inputSwap[i]];
					inpNbs[inputSwap[i]] = inpNbs[inputSwap[i + 1]];
					inpNbs[inputSwap[i + 1]] = tmp;
                }

				string returnLine = "";

				for (int i = 0; i < inpNbs.Length; i++)
				{
					if (i > 0 && i < inpNbs.Length)
					{
						returnLine += " ";
					}

					returnLine += inpNbs[i];
				}

				Console.WriteLine(returnLine);
            }
        }

        Console.ReadKey();
    }
}