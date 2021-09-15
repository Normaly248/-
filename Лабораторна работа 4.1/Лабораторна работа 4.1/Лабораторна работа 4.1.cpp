// Лабораторна работа 4.1.cpp: главный файл проекта.

#include "stdafx.h"
include <stdio.h>
#include <ctype.h>
#define BUFSIZE 80
extern ptab TW, TID, TD, TNUM;
char buf[BUFSIZE]; /* для накопления символов лексемы */
int c; /* очередной символ */
int d; /* для формирования числового значения константы */
int j; /* номер строки в таблице, где находится лексема,
 найденная функцией look */
enum state {H, ID, NUM, ASN, DLM, ER, END};
enum state TC; /* текущее состояние */
FILE* fp;
void clear(void); /* очистка буфера buf */
void add(void); /* добавление символа с в конец буфера buf */
int look(ptab); /* поиск в таблице лексемы из buf;
 результат: номер строки таблицы либо 0 */
int putl(ptab); /* запись в таблицу лексемы из buf, если ее
 там не было; результат: номер строки
таблицы */
int putnum(); /* запись в TNUM константы из d, если ее там
 не было; результат: номер строки таблицы
TNUM */
void makelex(int,int); /* формирование и вывод внутреннего
 представления лексемы */
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
 ТС=H;
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
 fp = fopen("prog","r"); /* в файле "prog" находится текст
 исходной программы */
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
} /* конец switch */
} /* конец тела цикла */
while (TC != END && TC != ER);
if (TC == ER) printf("ERROR !!!\n");
else printf("O.K.!!!\n");
}