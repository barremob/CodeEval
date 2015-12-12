/*
Score:      100
Time:       180
Memory:     5279744
Points:     56.230
*/

using System.IO;
using System;

class Program
{
	static string cipher = " !\"#$%&'()*+,-./0123456789:<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\GronsfeldCipher.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] inputData = line.Split(';');
				int[] code = Array.ConvertAll(inputData[0].ToCharArray(), c => (int)Char.GetNumericValue(c));
				string encoded = inputData[1];

				int codeIndex = 0;

				string returnData = "";
				int indexOfChar = -1;
				int processed = 0;

				while (encoded.Length > processed)
				{
					int appendIndex = 0;
					indexOfChar = cipher.IndexOf(encoded[processed]);

					if ((indexOfChar - code[codeIndex]) < 0)
					{
						appendIndex = cipher.Length + (indexOfChar - code[codeIndex]);
					}
					else
					{
						appendIndex = indexOfChar - code[codeIndex];
					}

					returnData += cipher[appendIndex];
					processed++;
					if (codeIndex == code.Length - 1)
					{
						codeIndex = 0;
					}
					else
					{
						codeIndex++;
					}
				}

				Console.WriteLine(returnData);
			}
		}

		Console.ReadKey();
	}
}