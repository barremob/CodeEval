/*
Correction of bit shift, difference is between bytes.

Score:      100
Time:       101
Memory:     4571136
Points:     57.587
*/

using System;
class Program
{
	static void Main(string[] args)
	{
		ushort number = 12345;
		byte upper = (byte)(number >> 8);
		
		if (upper == 48)
		{
			Console.WriteLine("LittleEndian");
		}
		else
		{
			Console.WriteLine("BigEndian");
		}
	}
}