#include "nivel.h"
#include "score.h"

void delay(int number_of_seconds)
{
    int timer = 50 - gameAccelerate() * number_of_seconds;

    clock_t start_time = clock();
    while (clock() < start_time + timer);
}

int **alloc_matrix(int m, int n)
{
    int **matrix = NULL;
    int i = 0;

    matrix = (int **) malloc(m * sizeof(int *));
    if(!matrix) return NULL;
    for(i = 0; i < m; i++)
    {
        *(matrix + i) = (int *) malloc(n * sizeof(int));
        if(!(*(matrix + i))) return NULL;
    }
    return matrix;
}

void free_matrix(int **matrix, int m)
{
    int i = 0;

    for(i = 0; i < m; i++)
    {
        free(*(matrix + i));
    }
    free(matrix);
}

int mapInit(int **matrix, int mapHeight, int mapLength)
{
    int i = 0, j = 0;

    for(i = 0; i < mapHeight; i++)
        for(j = 0; j < mapLength; j++)
        {
            if(i == mapHeight - 2)
                matrix [i][j] = 178;
            else
                matrix [i][j] = 32;
        }

}

void mapDisp(int **matrix, int mapHeight, int mapLength)
{
    int i = 0, j = 0;
    char string[100];

    for(i = 1; i < mapHeight; i++)
    {
    if(i == mapHeight - 1)
    printf("Press space to jump\n");
    else if(i == 1)
    printf("                                                                            Score: %10d\n", scoreIncrease());
    else
        {
        for(j = 0; j < mapLength-1; j++)
            {
                        string[j] = matrix[i][j];
            }
        string[j] = matrix[i][mapLength - 1] + '0';
        puts(string);
        }
    }

}

void mapUpdate(int **matrix, int mapHeight, int mapLength, bool space)
{
    int i = 0, j = 0, posHeight = 0;

     for(j = 0; j < mapLength; j++)
        for(i = 0; i < mapHeight; i++)
        {
            matrix[i][j] = matrix[i][j+1];
        }
    if(space)
        {
        for(i = 0; i < mapHeight; i++)
            matrix[mapHeight-2][mapLength-1] = 32;
        }
    else
            matrix[mapHeight-2][mapLength-1] = 178;


}
int mapGenerationRandom()
{
   static int lengthRandomiser = 2;
   static bool space = true;
        if(lengthRandomiser > 0)
        {
        lengthRandomiser -=1;
        }
        else
        {
        space = !space;
        lengthRandomiser = rand() % 4 + 2;
        if(space == false)
            lengthRandomiser = lengthRandomiser * 7;
        }
        if(space)
            return 1;
        else
            return 0;
}
void colorChange(int score, int color)
{
    static int colorMult = 0, changeValue = 1500;
    HANDLE  hConsole;
    hConsole = GetStdHandle(STD_OUTPUT_HANDLE);

    if (score == 0)
        SetConsoleTextAttribute(hConsole, 0);
    else if (score > changeValue)
    {
        changeValue*=2;
        SetConsoleTextAttribute(hConsole, color+colorMult);
        colorMult+=1;
    }
}
int gameReset(int **matrix, int mapHeight, int mapLength)
{

    HANDLE  hConsole;
    hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
    mapInit(matrix, mapHeight, mapLength);
    SetConsoleTextAttribute(hConsole, 7);
    scoreReset();
    playerReset(matrix, mapHeight-3, 6);
    return 10;
}

void mapPlay(int **matrix, int mapHeight, int mapLength)
{
    bool alive = true;
    int color;

    color = gameReset(matrix, mapHeight, mapLength);
    while(alive)
        {
        system("cls");
        colorChange(scoreIncrease(), color);
        mapUpdate(matrix, mapHeight, mapLength, mapGenerationRandom());
        if(!playerUpdate(matrix, mapHeight-3, 6))
            alive = false;
        mapDisp(matrix, mapHeight, mapLength);
        delay(1);
        }
    mapDisp(matrix, mapHeight, mapLength);
    system("cls");
}

