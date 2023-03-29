#ifndef PLAYER_H_INCLUDED
#define PLAYER_H_INCLUDED

#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <time.h>
#include <windows.h>
#include <conio.h>

extern void playerReset(int**, int, int);
extern int playerUpdate(int**, int, int);
extern int playerDraw(int**, int, int, int);

#endif // PLAYER_H_INCLUDED
