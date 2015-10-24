using System.IO;
using System;
class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText("FizzBuzzData.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                {
                    continue;
                }

                string[] input = line.Split(' ');
                int divX = (Convert.ToInt32(input[0]));
                int divY = (Convert.ToInt32(input[1]));
                int countN = (Convert.ToInt32(input[2]));

                bool noFizzOrBuzz = true;
                for (int i = 1; i < countN + 1; i++)
                {
                    noFizzOrBuzz = true;

                    if (i > 1)
                    {
                        Console.Write(" ");
                    }

                    if (i % divX == 0)
                    {
                        Console.Write("F");
                        noFizzOrBuzz = false;
                    }

                    if (i % divY == 0)
                    {
                        Console.Write("B");
                        noFizzOrBuzz = false;
                    }

                    if (noFizzOrBuzz)
                    {
                        Console.Write(i);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
