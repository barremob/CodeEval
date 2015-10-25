using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText("Lowercase.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                {
                    continue;
                }

                foreach (char c in line)
                {
                    if (c > 64 && c < 91)
                        Console.Write(Convert.ToChar(c + 32));
                    else
                        Console.Write(c);
                }

                Console.WriteLine();
            }
        }
        Console.ReadKey();
    }
}