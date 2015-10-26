/*
Score:      100
Time:       156
Memory:     5201920
Points:     30.386

With own list
Score:      100
Time:       152
Memory:     4673536
Points:     30.834
*/

using System.IO;
using System;
//using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //using (StreamReader reader = File.OpenText(args[0]))
        using (StreamReader reader = File.OpenText(@"Easy\UniqueElements.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                {
                    continue;
                }

                string[] input = line.Split(',');
                //List<string> output = new List<string>();
                SimpleList<string> output = new SimpleList<string>();

                for (int i = 0; i < input.Length; i++)
                {
                    //if (!output.Exists(x => x == input[i]))
                    if (!output.Contains(input[i]))
                    {
                        output.Add(input[i]);
                    }
                }

                for (int i = 0; i < output.Count; i++)
                {
                    Console.Write(output[i]);
                    if (i < output.Count - 1)
                    {
                        Console.Write(",");
                    }
                }

                Console.WriteLine();
            }
        }

        Console.ReadKey();
    }
}
public class SimpleList<T> where T : class
{
    private T[] data;
    private int nextIndex = 0;

    public SimpleList()
    {
        data = new T[5];
    }

    public int Count
    {
        get { return nextIndex; }
    }

    public void Add(T item)
    {
        if(data.Length == nextIndex)
        {
            ExpandArray();
        }
        data[nextIndex] = item;
        nextIndex++;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < nextIndex; i++)
        {
            if (data[i].Equals(item))
            {
                return true;
            }
        }
        return false;
    }

    private void ExpandArray()
    {
        Array.Resize(ref data, data.Length * 2);
    }

    public T this[int index]
    {
        get { return data[index]; }
    }
}