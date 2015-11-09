/*
Score:      100
Time:       170
Memory:     4833280
Points:     30.668
*/

using System.IO;
using System;
using System.Text;

class Program
{
	// First two are complete morse codes
	//static string[] morseCode = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", ".-.-.-", "--..--", "..--..", "-.-.--", "-....-", "-..-.", "---...", ".----.", "-.--.-", "-.-.-", "-.--.", "-...-", ".--.-.", ".-..." };
	//static string[] alphaNum = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ".", ",", "?", "!", "-", "/", ":", "'", "-", ")", ";", "(", "=", "@", "&" };
	// These two are only needed for CodeEval
	//static string[] morseCode = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----." };
	//static char[] alphaNum = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
	static string[,] morseCodes = { { ".-", "A" }, { "-...", "B" }, { "-.-.", "C" }, { "-..", "D" }, { ".", "E" }, { "..-.", "F" }, { "--.", "G" }, { "....", "H" }, { "..", "I" }, { ".---", "J" }, { "-.-", "K" }, { ".-..", "L" }, { "--", "M" }, { "-.", "N" }, { "---", "O" }, { ".--.", "P" }, { "--.-", "Q" }, { ".-.", "R" }, { "...", "S" }, { "-", "T" }, { "..-", "U" }, { "...-", "V" }, { ".--", "W" }, { "-..-", "X" }, { "-.--", "Y" }, { "--..", "Z" }, { "-----", "0" }, { ".----", "1" }, { "..---", "2" }, { "...--", "3" }, { "....-", "4" }, { ".....", "5" }, { "-....", "6" }, { "--...", "7" }, { "---..", "8" }, { "----.", "9" } };

	static StringBuilder stringB = new StringBuilder();

	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\MorseCode.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}

				stringB.Clear();

				string[] input = line.Split(' ');
				int indexOfChar = 0;
				for (int i = 0; i < input.Length; i++)
				{

					if (input[i] == "")
					{
						stringB.Append(" ");
					}
					else
					{
						//indexOfChar = Array.IndexOf(morseCode, input[i]);
						int arrayLenght = morseCodes.GetLength(0);
						for (int x = 0; x < arrayLenght; x++)
						{
							if (morseCodes[x, 0] == input[i])
							{
								stringB.Append(morseCodes[x, 1]);
							}
						}
					}
				}
				Console.WriteLine(stringB.ToString());
			}
		}

		Console.ReadKey();
	}
}