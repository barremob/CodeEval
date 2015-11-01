/*
Score:      100
Time:       3
Memory:     266240
Points:     34.772
*/

#include <iostream>
#include <sstream>

using namespace std;
int main()
{
	stringstream data;
	for (int i = 1; i < 100; i++)
	{
		if (i % 2 != 0)
		{
			data << i << "\n";
		}
	}

	cout << data.str();

	return 0;
}
