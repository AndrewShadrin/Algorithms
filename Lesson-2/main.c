//////////////////////////////////////
//// Задания выполнил Шадрин Андрей //
//////////////////////////////////////
//#define _CRT_SECURE_NO_WARNINGS
//#include <stdio.h>
//#include <locale.h>
//#include <stdbool.h>
//
//
//void convert10to2(int num, char dig[32])
//{
//	
//	if (num % 2 == 0)
//		dig += '0';
//	else dig += '1';
//	if ((num / 2) != 0) convert10to2(num / 2, dig);
//	else return;
//}
//
//int task1()
//{
//	int n = 0;
//	char dig[32] = {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'};
//
//	printf("Enter number\n");
//	scanf("%d", &n);
//	convert10to2(n, dig);
//	printf(dig);
//
//	return 0;
//}
//
//int main()
//{
//	int n = 0;
//	int result = 0;
//	bool exit = false;
//
//	do
//	{
//		printf("\nMenu:\n");
//		printf("1. Transfer 10 -> 2\n");
//		printf("2. \n");
//		printf("3. \n");
//		printf("0. Exit\n");
//
//		result = scanf("%d", &n);
//
//		switch (n)
//		{
//		case 1:
//			task1();
//			break;
//		case 2:
//			//task13();
//			break;
//		case 3:
//			//task12();
//			break;
//		case 4:
//			printf("Not implemented yet");
//			break;
//		case 0:
//			exit = true;
//			break;
//		default:
//			break;
//		}
//
//	} while (!exit);
//
//	return 0;
//}