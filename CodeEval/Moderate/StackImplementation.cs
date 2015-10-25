using System.IO;
using System;

class Program
{
    static int[] numbers;
    static int index;

    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText("StackImplementation.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                {
                    continue;
                }

                string[] input = line.Split(' ');

                numbers = new int[input.Length];
                index = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    Push(Convert.ToInt32(input[i]));
                }

                for (int i = 0; i < numbers.Length; i++)
                {
                    var poper = Pop();

                    if(i%2==0)
                        Console.Write(poper + " ");
                }
                Console.WriteLine();
            }
        }

        Console.ReadKey();
    }

    static void Push(int nbr)
    {
        index++;
        numbers[index-1] = nbr;
    }

    static int Pop()
    {
        index--;
        return numbers[index];
    }
}