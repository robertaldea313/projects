#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <windows.h>
#include <time.h>

#include "nivel.h"
#include "score.h"
#include "manager.h"

#define Height 25
#define Length 100

int main()
{
    int m = Height, n = Length, gameState;
    int **map;

    system("mode con: lines=25 cols=100");
    map = alloc_matrix(m, n);
    srand(time(NULL));

    mainMenu();
    gameState = keyPress();
    while(gameState>0)
    {
        mapPlay(map, m, n);
        highScoreCompare();
        gameState = keyPress();
    }
    free_matrix(map,m);
}
