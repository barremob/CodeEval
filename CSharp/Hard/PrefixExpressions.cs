/*
Score:      100
Time:       76
Memory:     4358144
Points:     89.229
*/

using System.IO;
using System;

class Program
{
	static void Main(string[] args)
	{
		SimpleStack<double> simpleStack = new SimpleStack<double>();

		//using (StreamReader reader = File.OpenText(args[0]))
		using (StreamReader reader = File.OpenText(@"Hard\PrefixExpressions.txt"))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line || line == "")
				{
					continue;
				}

				string[] inputData = line.Split(' ');
				double left = 0;
				double right = 0;

				for (int i = inputData.Length - 1; i >= 0; i--)
				{
					if (IsOp(inputData[i]))
					{
						left = simpleStack.Pop();
						right = simpleStack.Pop();
						simpleStack.Push(Calculate(left, right, inputData[i]));
					}
					else
					{
						simpleStack.Push(Convert.ToInt32(inputData[i]));
					}
				}

				Console.WriteLine(simpleStack.Pop());
			}
		}

		Console.ReadLine();
	}

	public static bool IsOp(string data)
	{
		if (data == "+" || data == "-" || data == "*" || data == "/")
		{
			return true;
		}

		return false;
	}

	public static double Calculate(double left, double right, string op)
	{
		switch (op)
		{
			case "+": return left + right;
			case "-": return left - right;
			case "*": return left * right;
			case "/": return left / right;
		}

		throw new InvalidOperationException();
	}
}

public class SimpleStack<T>
{
	T[] array;
	int tail;

	public SimpleStack()
	{
		array = new T[40];
		tail = 0;
	}

	public void Push(T data)
	{
		array[tail++] = data;
	}

	public T Pop()
	{
		return array[--tail];
	}
}