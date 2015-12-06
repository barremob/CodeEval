/*
Score:      100
Time:       150
Memory:     4714496
Points:     57.204
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		MyStack<char> myStack = new MyStack<char>();

		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Moderate\ValidParantheses.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				myStack.Reset();

				char[] inputList = line.ToCharArray();
				bool inValid = false;

				for (int i = 0; i < inputList.Length; i++)
				{
					char toTest = inputList[i];

					if (toTest == '(')
					{
						myStack.Push('(');
					}
					else if (toTest == '{')
					{
						myStack.Push('{');
					}
					else if (toTest == '[')
					{
						myStack.Push('[');
					}
					else
					{
						char rightSide;
						if (toTest == ')')
						{
							rightSide = myStack.Pop();
							if (rightSide != '(')
							{
								inValid = true;
								break;
							}
						}
						else if (toTest == '}')
						{
							rightSide = myStack.Pop();
							if (rightSide != '{')
							{
								inValid = true;
								break;
							}
						}
						else if (toTest == ']')
						{
							rightSide = myStack.Pop();
							if (rightSide != '[')
							{
								inValid = true;
								break;
							}
						}
					}
				}

				if (!inValid)
				{
					inValid = myStack.Size > 0;
				}

				Console.WriteLine(!inValid);
			}
		}

		Console.ReadKey();
	}
}

public class MyStack<T>
{
	T[] numbers;
	int index;

	public int Size { get { return index + 1; } }

	public MyStack()
	{
		numbers = new T[10];
	}

	internal void Push(T input)
	{
		index++;
		if (index >= numbers.Length)
		{
			Resize();
		}
		numbers[index] = input;
	}

	private void Resize()
	{
		Array.Resize<T>(ref numbers, numbers.Length * 2);
	}

	internal T Pop()
	{
		if (index < 0)
		{
			return default(T);
		}

		return numbers[index--];
	}

	internal void Reset()
	{
		index = -1;
	}
}