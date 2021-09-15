// Лаба 4.cpp: главный файл проекта.

#include "stdafx.h"

#include <string.h>
#include <conio.h>
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <io.h>
#include <windows.h>
#include <math.h>
#include <fstream>
#include <string>
using namespace std;


int func1(char* buf) {
	if (strcmp(buf, "or") == 0 || strcmp(buf, "xor") == 0 || strcmp(buf, "and") == 0 || strcmp(buf, "not") == 0)
		return 1;
	else
		return 0;
}


void main() {
	setlocale(LC_CTYPE, "rus");
	int k = 1;
	string path = "file.txt";
	ifstream fin;
	fin.open(path);
	if (!fin.is_open())
		cout << "Ошибка ";
	else {
		cout << "Файл открыт" << endl << endl << endl;
		cout << "Таблица лексического анализатора" << endl << "Лексема" << "      " << "Тип лексемы" << endl;
		while (!fin.eof()) {
			int k;
			char* ch1;
			ch1 = new char[128];
			fin >> ch1;
			int f = strlen(ch1);
			for (int i = 0; i < f; i++) {
				k = 0; int z = 0;
				char* buf;
				buf = new char[32];
				while (i != f && isalpha(ch1[i])) {					
					buf[z] = ch1[i];
					i++; z++; k++;
				}
				buf[z] = '\0';
				z = 0;
				if (k != 0) {
					int d = func1(buf);
					if (d == 1) {
						while (buf[z] != '\0') {
							cout << buf[z];
							z++;
						}
						if (strlen(buf) == 2)
							cout << "          " << " Ключевое слово" << endl;
						else
							cout << "         " << " Ключевое слово" << endl;
					}
					else {
						while (buf[z] != '\0') {
							cout << buf[z];
							z++;
						}
						int c = 10 - z;
						while (c != 0) {
							cout << " ";
							c--;
						}
						cout << "  " << " Индентификатор" << endl;
					}
				}
				if (i != f) {
					if (ch1[i] == '(' || ch1[i] == ')' || ch1[i] == ';')
						cout << ch1[i] << "            " << "Разделитель" << endl;
					else {
						if (ch1[i] == ':') {
							if (ch1[i + 1] == '=') {
								cout << ch1[i] << ch1[i + 1] << "           " << "Операция присваивания" << endl;
								i++;
							}
							else
								cout << endl << "Ошибка, не опознанная лексема ' " << ch1[i] << " ' " << endl << endl;
						}
						else {
							if (isalnum(ch1[i]))
								cout << ch1[i] << "            " << "Целая десятичная константа без знака" << endl;
							else
								cout << endl << "Ошибка, не опознанная лексема ' " << ch1[i] << " ' " << endl << endl;
						}
					}
				}
				delete[] buf;
			}
		}
	}
	fin.close();
	cout << endl;
	system("pause");
}