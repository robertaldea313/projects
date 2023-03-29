int posYmod ;
void playerReset(int **matrix, int posY,int posX)
{
    posYmod = 0;
}
int playerUpdate(int **matrix, int posY,int posX)
{
    static int jumpMax = 0;

    char input;
    if(kbhit())
        input=getch();
    playerDraw(matrix, posY + posYmod, posX - 1, 176);
    if (input == ' ' && matrix [posY + posYmod + 1][posX] == 178)
        jumpMax = 5;
    if (jumpMax > 0)
    {
        posYmod -=1;
        jumpMax-=1;
    }
    else if ((matrix [posY + posYmod + 1][posX]) != 178)
        posYmod +=1;
    playerDraw(matrix, posY + posYmod, posX, 219);

    if(posY + posYmod + 1 > posY + 2)
        return 0;
    else
        return 1;


}
int playerDraw(int **matrix, int posY,int posX, int characterSym)
{
    matrix[posY][posX] = characterSym;
    matrix[posY][posX - 1] = characterSym;
    matrix[posY - 1][posX] = characterSym;
    matrix[posY - 1][posX - 1] = characterSym;
}

