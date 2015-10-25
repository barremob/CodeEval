/*
Score:      100
Time:       167
Memory:     4808704
Points:     30.695
*/

using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText("SelfDescribingNumbers.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                {
                    continue;
                }

                bool isSelf = true;
                int[] nbr = new int[10];
                int[] bLine = new int[line.Length];

                for (byte i = 0; i < bLine.Length; i++)
                {
                    char[] chars = line.ToCharArray();
                    bLine[i] = chars[i] - 48;
                    nbr[bLine[i]]++;
                }

                for (byte i = 0; i < bLine.Length; i++)
                {
                    if (nbr[i] != bLine[i])
                    {
                        isSelf = false;
                    }
                }

                Console.WriteLine(isSelf ? 1 : 0);
                nbr = null;
            }
        }
        Console.ReadKey();
    }
}