#include "stdafx.h"
#include <stdio.h>
#include <iostream>
#include <conio.h>
#include <ctype.h>
#include <vector>
#include <string>

#define BUFSIZE 80

std::vector<std::string> TD = { ";", "$"};
std::vector<std::string> TID;
std::vector<std::string> TSIM = { "T", "F" };
std::vector<std::string> TW = { "xor", "or", "and", "not", "(", ")" };

char buf[BUFSIZE]; /* ��� ���������� �������� ������� */
char T = 'T';
char F = 'F';
int c; /* ��������� ������ */
int j; /* ����� ������ � �������, ��� ��������� �������,
��������� �������� look */

int line = 0;
enum state { H, ID, W, SIM, ASN, DLM, ER, END };
enum state TC; /* ������� ��������� */

FILE* fp;
errno_t err;

unsigned int currentfilepos = 0;
void add(void) {
buf[currentfilepos] = c;
currentfilepos++;
};

void clear(void){
	std::fill_n(buf, BUFSIZE, NULL); //������� �������
	currentfilepos = 0;
}; /* ������� ������ buf */

int look(std::vector<std::string>& tab) 
	{
	std::string lex(buf);
	if (lex == "") lex = c;
	std::vector<std::string>::iterator itr = std::find(tab.begin(), tab.end(), lex);
	if (itr != tab.cend()) {
	return(int(std::distance(tab.begin(), itr)));
	}
	else {
	return -1;
	}
	};/* ����� � ������� ������� �� buf;
���������: ����� ������ ������� ���� 0 */

int putl(std::vector<std::string>& tab) {
std::string lex(buf);
if (lex == "") lex = c;
int pos = look(tab);
if (pos != -1) {
return(pos);
}
else {
tab.push_back(lex);
return(int(tab.size() - 1));
}

};; /* ������ � ������� ������� �� buf, ���� ��

��� �� ����; ���������: ����� ������

������� */

void makelex(int b, int k) {
	const char* value;
	const char* type;
	setlocale(LC_ALL, "Rus");
	printf("%d ������: ", line);
	switch (b) {

case W:
	type = "��������";
	value = TW.at(k).c_str();
	printf("%8s �%1d %15s\n", type, k, value);
	break;
case DLM:
	type = "�����������";
	value = TD.at(k).c_str();	
	printf("%8s �%1d %12s\n", type, k, value);
	break;

case ID:
	type = "�������������";
	value = TID.at(k).c_str();
	printf("%8s �%1d %6s\n", type, k, value);
	break;

case SIM:
	type = "���������";
	value = TSIM.at(k).c_str();
	printf("%8s �%1d %14s\n", type, k, value);
	break;

case ASN:
	type = "������������";
	value = ":=";
	printf("%8s �%1d %7s\n", type, k, value);
	break;
}

};

void gc(void) {
c = fgetc(fp);
}
void id_or_word(void) {
j = look(TW);
if (j != -1) makelex(W, j);
else {
j = putl(TID); makelex(ID, j);
}
}
void is_sim(void) {
j = look(TSIM);
if (j != -1) {
makelex(SIM, j);
gc();
TC = H;
}
else
{
TC = ER;
}
}
void is_assign(void) {
std::string lex(buf);
if (lex == ":=") {
makelex(ASN, 0);
gc();
TC = H;
}
else {
TC = ER;
}
}
void is_dlm(void) {
j = look(TD);
if (j != -1) {
makelex(DLM, j);
gc();
TC = H;
}
else {
TC = ER;
}
}
void scan(void) {
TC = H;
err = fopen_s(&fp, "prog.txt", "r"); /* � �����"prog" ��������� ����� �������� ��������� */
if (err == 0)
{
setlocale(LC_ALL, "Rus");
printf("���� 'prog.txt' ��� ������� ������\n");
gc();
do {
switch (TC) {
case H:
if (c == ' ') gc();
else if (c == '\n') {
line++; gc();
}
else if ((c == T ) | (c == F) ){
TC = SIM;
}
else if (isalpha(c) | (isdigit(c))) {
clear();
add(); gc();
TC = ID;
}
else if (c == ':') {
clear();
add(); gc();
TC = ASN;
}
else if (c == '$') {
makelex(DLM, putl(TD));
TC = END;
}
else TC = DLM;
break;
case DLM:
clear();
is_dlm();
break;
case ID:
if (isalpha(c) || isdigit(c)) {
add(); gc();
}
else {
id_or_word();
TC = H;
}
break;
case SIM:
if ((c == T) | (c == F)) {
is_sim();
TC = H;
}
break;
case ASN:
if (c == '=')
{
add();
is_assign();
}
else
{
TC = H;
}
break;
}
} while (TC != END && TC != ER);
{
if (TC == ER)
{
printf("%d ������: ", line);
printf("<%8s,%02d> %12c - ����������� �������\n", "ERROR", 0, c);
}
else printf("����������� ������ ��������� ��� ������� �������\n");
}
fclose(fp);
}
else
{
printf("���� 'prog.txt' �� ��� ������\n");
}
}

int main()

{
scan();
_getch();
return 0;
}