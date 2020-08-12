#include "Main.h"
#include <string>
#include <iostream>
using namespace std;

string sdd;

// возведение в степень
int binpow(int a, int b) {
	if (b == 0)
		return 1;
	int x = (b % 2) ? a : 1;
	int c = binpow(a, b / 2);
	return x * c * c;
}

// перевод из 10 в 2 систему
void convert10to2(int num, string &dig)
{
	if (num % 2 == 0)
		dig += '0';
	else dig += '1';
	if ((num / 2) != 0) convert10to2(num / 2, dig);
	else return;
}

int main()
{
	string dig = "";

	convert10to2(10, dig);

	cout << dig;

	getchar();

	return 0;
}