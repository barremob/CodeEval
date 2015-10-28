/*
Score:      100
Time:       157
Memory:     4804608
Points:     30.716
*/

using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Easy\ArmstrongNumbers.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                {
                    continue;
                }

                int inputNumber = Convert.ToInt32(line);

                int[] numbers = GetSingleNumbers(inputNumber, line.Length);
                int armstrongNumber = GetArmstrongNumber(numbers);

                Console.WriteLine(armstrongNumber == inputNumber ? "True":"False");
            }
        }
        Console.ReadKey();
    }

    static int[] GetSingleNumbers(int data, int nbrCount)
    {
        int[] rtnData = new int[nbrCount];
        int remaining = data;

        for (int i = 0; i < nbrCount; i++)
        {
            var r = remaining % 10;
            rtnData[i] = r;
            remaining /= 10;
        }

        return rtnData;
    }

    static int GetArmstrongNumber(int[] input)
    {
        int rtnNumber = 0;
        for (int i = 0; i < input.Length; i++)
        {
            rtnNumber += (int)Math.Pow((double)input[i],(double)input.Length);
        }
        return rtnNumber;
    }

}