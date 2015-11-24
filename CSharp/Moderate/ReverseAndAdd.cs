/*
Score:      100
Time:       187
Memory:     5767168
Points:     55.455
*/

using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Moderate\ReverseAndAdd.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || line == "")
                {
                    continue;
                }

                uint currentVal = Convert.ToUInt32(line);
                int currentLoopCount = 0;
                bool foundPalindrome = false;
                
                while (!foundPalindrome)
                {
                    currentLoopCount++;
                    currentVal += Reverse(currentVal);
                    foundPalindrome = IsPalindrome(currentVal);
                }

                Console.WriteLine(currentLoopCount + " " + currentVal);
            }
        }

        Console.ReadKey();
    }

    static uint Reverse(uint number)
    {
        uint remaining = number;
        uint returnVal = 0;
        while (remaining > 0)
        {
            var r = remaining % 10;
            returnVal = returnVal * 10 + r;
            remaining /= 10;
        }

        return returnVal;
    }

    static bool IsPalindrome(uint number)
    {
        string forward = number.ToString();
        char[] charArray = forward.ToCharArray();
        Array.Reverse(charArray);
        string reverse = new String(charArray);

        if (forward == reverse)
        {
            return true;
        }

        return false;
    }
}