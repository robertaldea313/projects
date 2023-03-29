#ifndef NIVEL_H_INCLUDED
#define NIVEL_H_INCLUDED

#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <time.h>
#include <windows.h>

#include "player.h"

extern void delay(int);
extern int **alloc_matrix(int, int);
extern void free_matrix(int**, int);
extern int mapInit(int**, int, int);
extern void mapDisp(int**, int, int);
extern void mapUpdate(int**, int, int, bool);
extern int mapGenerationRandom();
extern void colorChange(int, int);
extern void mapPlay(int**, int, int);
extern int gameReset(int**, int, int);


#endif // NIVEL_H_INCLUDED
