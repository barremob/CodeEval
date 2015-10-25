/*
This one I also tested with different languages, because of the simplicity to implement.
Some reasons for the big difference between C# and C++ should be obvious.
Compiled vs JIT.
Below are the scores for the different languages.

C#
Score:      100
Time:       123
Memory:     4714496
Points:     30.849

PHP
Score:      100
Time:       38
Memory:     3400638
Points:     32.096

C++
Score:      100
Time:       3
Memory:     266240
Points:     34.772

*/

using System;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 1; i < 100; i++)
        {
            if (i % 2 != 0)
            {
                Console.WriteLine(i);
            }
        }
        Console.ReadKey();
    }
}

/* PHP
<?php
for ($i = 1; $i < 100; $i++)
{
    if ($i % 2 != 0)
    {
        echo $i . "\n";
    }
}
?>
*/

/* C++
#include <iostream>
#include <string>

int main()
{
  for (int i = 1; i < 100; i++)
        {
            if (i % 2 != 0)
            {
                std::cout << i << "\n";
            }
        }
  return 0;
}
*/
