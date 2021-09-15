// ����������� ������ 4.1.cpp: ������� ���� �������.

#include "stdafx.h"
include <stdio.h>
#include <ctype.h>
#define BUFSIZE 80
extern ptab TW, TID, TD, TNUM;
char buf[BUFSIZE]; /* ��� ���������� �������� ������� */
int c; /* ��������� ������ */
int d; /* ��� ������������ ��������� �������� ��������� */
int j; /* ����� ������ � �������, ��� ��������� �������,
 ��������� �������� look */
enum state {H, ID, NUM, ASN, DLM, ER, END};
enum state TC; /* ������� ��������� */
FILE* fp;
void clear(void); /* ������� ������ buf */
void add(void); /* ���������� ������� � � ����� ������ buf */
int look(ptab); /* ����� � ������� ������� �� buf;
 ���������: ����� ������ ������� ���� 0 */
int putl(ptab); /* ������ � ������� ������� �� buf, ���� ��
 ��� �� ����; ���������: ����� ������
������� */
int putnum(); /* ������ � TNUM ��������� �� d, ���� �� ���
 �� ����; ���������: ����� ������ �������
TNUM */
void makelex(int,int); /* ������������ � ����� �����������
 ������������� ������� */
void id_or_word(void)
{
 if (j=look(TW)) makelex(1,j);
 else
 {
 j=putl(TID); makelex(4,j);
 }
}
void is_dlm(void)
{
 if(j=look(TD))
 {
 makelex(2,j);
 gc();
 ��=H;
 }
 TC=ER;
}
void gc(void)
{
 c = fgetc(fp);
}
void scan (void)
{
 TC = H;
 fp = fopen("prog","r"); /* � ����� "prog" ��������� �����
 �������� ��������� */
 gc();
 do
 {
 switch (TC)
 {
 case H:
 if (c == ' ') gc();
 else if (isalpha(c))
 {
 clear();
 add();
 gc();
 TC = ID;
 }
 else if (isdigit (c))
 {
 d = c - '0';
 gc();
 TC = NUM;
 }
 else if (c == ':')
 {
 gc();
 TC = ASN;
 }
 else if (c == '?')
 {
 makelex(2, N?);
 TC = END;
 }
 else TC = DLM;
 break;
 case ID:
 if (isalpha(c) || isdigit(c))
 {
 add();
 gc();
 }
 else
 {
 id_or_word(); 
 TC = H;
}
break;
case NUM:
if (isdigit(c))
{
d=d*10+(c - '0');
gc();
}
else
{
makelex (5, putnum());
TC = H;
}
break;
/* ........... */
} /* ����� switch */
} /* ����� ���� ����� */
while (TC != END && TC != ER);
if (TC == ER) printf("ERROR !!!\n");
else printf("O.K.!!!\n");
}