/*
Score:      100
Time:       283
Memory:     1953792
Points:     32.874
*/

using System.IO;
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Easy\TimeToEat.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                {
                    continue;
                }

                string[] input = line.Split(' ');
                Array.Sort<string>(input);

                StringBuilder rtn = new StringBuilder();

                for (int i = input.Length-1; i >= 0; i--)
                {
                    if(i < input.Length - 1)
                    {
                        rtn.Append(" ");
                    }
                    rtn.Append(input[i]);
                }

                Console.WriteLine(rtn.ToString());
            }
        }

        Console.ReadKey();
    }
}