/*
Score:      100
Time:       101
Memory:     4562944
Points:     57.600
*/

using System;
class Program
{
	static void Main(string[] args)
	{
		ushort number = 123;
		byte upper = (byte)(number >> 4);
		
		if (upper != 7)
		{
			Console.WriteLine("BigEndian");
		}
		else
		{
			Console.WriteLine("LittleEndian");
		}
	}
}