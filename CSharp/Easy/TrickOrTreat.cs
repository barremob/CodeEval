/*
Score:      100
Time:       180
Memory:     4902912
Points:     30.593
*/

using System.IO;
using System;

class Program
{


	static void Main(string[] args)
	{
		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Easy\TrickOrTreat.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
				{
					continue;
				}

				House houses = new House(line);

				Console.WriteLine(houses.CountTotalCandy());
			}
		}

		Console.ReadKey();
	}
}

class House
{
	static int CandyVampire = 3;
	static int CandyZombie = 4;
	static int CandyWitch = 5;

	int Vampires;
	int Zombies;
	int Witches;

	int Houses;

	public House(string data)
	{
		string[] dataArr = data.Split(new char[] { ':', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
		Vampires = Convert.ToInt32(dataArr[1]);
		Zombies = Convert.ToInt32(dataArr[3]);
		Witches = Convert.ToInt32(dataArr[5]);
		Houses = Convert.ToInt32(dataArr[7]);
	}

	public int CountTotalCandy()
	{
		int candyVampires = Houses * Vampires * CandyVampire;
		int candyZombies = Houses * Zombies * CandyZombie;
		int candyWitches = Houses * Witches * CandyWitch;
		return (candyVampires + candyZombies + candyWitches) / (Vampires + Zombies + Witches);
	}
}