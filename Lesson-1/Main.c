////////////////////////////////////
// Задания выполнил Шадрин Андрей //
////////////////////////////////////
#define _CRT_SECURE_NO_WARNINGS
#include "Main.h"
#include <stdio.h>
#include <locale.h>
#include <stdbool.h>
#include <stdlib.h>

bool automorph(int x)
{
	int o,m=10;
	int q = x * x;
	
	do
	{
		o = q % m;
		if (x == o)
		{
			return true;
		}
		m *= 10;
	} while (m < q);
	return false;
}

int task14() 
{
	int s, n, m, o, result;

	printf("Input N\n");
	result = scanf("%d", &n);
	for (int i = 0; i < n; i++)
	{
		if (automorph(i))
		{
			printf("Number %d is automorph\n", i);
		}
	}
	result = getchar();
	return 0;
}

unsigned int random(int start, int stop, bool std)
{
	static unsigned int A = 0;

	if (std)
	{
		return rand() % (stop - start) + start;
	}
	else
	{
		if (A == 0)
		{
			A = time(NULL);
		}
		A = (978654 * A + 1678875) % 32767;
		return A % (stop - start) + start;
	}
}

int task13()
{
	int length = 10;
	srand(time(NULL));
	
	printf("\nStandart rand()\n");
	for (int i = 0; i < length; i++)
	{
		printf("%d\t", random(1, 100, true));
	}

	printf("\nNonstandart random\n");
	for (int i = 0; i < length; i++)
	{
		printf("%d\t", random(1, 100, false));
	}

	return 0;
}

int task12()
{
	int a, b, c, max;
	printf("\nInput 1 number\n");
	scanf("%d", &a);
	printf("Input 2 number\n");
	scanf("%d", &b);
	printf("Input 3 number\n");
	scanf("%d", &c);

	max = a;
	if (b > max)
	{
		max = b;
	}
	if (c > max)
	{
		max = c;
	}
	printf("Max number %d", max);
	
	return 0;
}

int main()
{
	int n = 0;
	int result = 0;
	bool exit = false;

	do
	{
		printf("\nMenu:\n");
		printf("1. Task 14 (automorph numbers)\n");
		printf("2. Task 13 (Random numbers)\n");
		printf("3. Task 12 (Maximum of 3 numbers)\n");
		printf("0. Exit\n");

		result = scanf("%d", &n);

		switch (n)
		{
		case 1:
			task14();
			break;
		case 2:
			task13();
			break;
		case 3:
			task12();
			break;
		case 4:
			printf("Not implemented yet");
			break;
		case 0:
			exit = true;
			break;
		default:
			break;
		}
	
	} while (!exit);

	return 0;
}