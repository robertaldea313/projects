#include "manager.h"

void newHighscore(long int score)
{
    HANDLE  hConsole;
    hConsole = GetStdHandle(STD_OUTPUT_HANDLE);

    SetConsoleTextAttribute(hConsole, 7);
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("                    ============================================================                    \n");
    printf("                    NEW HIGHSCORE!                                                                  \n");
    printf("                                                                -------------                  \n");
    SetConsoleTextAttribute(hConsole, 14);
    printf("                                                                      %10ld                              \n", score);
    SetConsoleTextAttribute(hConsole, 7);
    printf("                                                                 -------------                   \n");
    printf("                                                                                                    \n");
    printf("                                                                                                    \n");
    printf("                    !                                                          !                    \n");
    printf("                    ============================================================                    \n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
}
void noHighscore(long int score, long int highscore)
{
    HANDLE  hConsole;
    hConsole = GetStdHandle(STD_OUTPUT_HANDLE);

    SetConsoleTextAttribute(hConsole, 7);
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("                    ============================================================                    \n");
    printf("                    Score:                                                                  \n");
    printf("                          %10ld                                                                \n",score);
    printf("                                                                -------------                  \n");
    SetConsoleTextAttribute(hConsole, 14);
    printf("                    Your highscore:                                   %10ld                              \n", highscore);
    SetConsoleTextAttribute(hConsole, 7);
    printf("                                                                 -------------                   \n");
    printf("                                                                                                    \n");
    printf("                                                                                                    \n");
    printf("                    !                                                          !                    \n");
    printf("                    ============================================================                    \n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
}
void mainMenu()
{
    HANDLE  hConsole;
    hConsole = GetStdHandle(STD_OUTPUT_HANDLE);

    SetConsoleTextAttribute(hConsole, 7);
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    SetConsoleTextAttribute(hConsole, 14);
    printf("                                          %c %c %c %c   %c %c%c %c%c%c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
    printf("                                          %c %c %c %c%c %c%c %c %c %c%c%c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
    printf("                                          %c %c %c %c %c %c %c%c  %c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178);
    printf("                                        %c %c %c %c %c   %c %c  \n", 178, 178, 178, 178, 178, 178, 178);
    printf("                                         %c   %c  %c   %c %c  %c\n", 178, 178, 178, 178, 178, 178);
    SetConsoleTextAttribute(hConsole, 7);
    printf("\n");
    printf("\n");
    printf("                                         -PRESS SPACE TO START-");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
}
void keyPress()
{
    char input;
    input = getch();

    if(input == 'q')
        return 0;
    else if (input == ' ')
        return 1;
}
