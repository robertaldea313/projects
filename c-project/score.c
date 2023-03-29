#include "score.h"
#include "manager.h"

int score;
float scoreMult;
char filename[20] = "highscore.bin";

int scoreReset()
{
    score = 0;
    scoreMult = 1;
}

int scoreIncrease()
{
    score += 10 *scoreMult;
    if (score % 100 == 0)
    {
        scoreMult += 0.1f;
    }
    return score;
}

int gameAccelerate()
{

    if (score < 1000)
        return 0;
    else
        return (int)score/1000;
}

void highScoreReplace()
{
    FILE *save;

    save = fopen(filename, "w");
    fprintf(save, "%ld", score);
}

void highScoreCompare()
{
    int i = 0;
    long int scoreCompare = 0;
    FILE *save;

    save = fopen(filename, "r");
    fscanf(save, "%ld", &scoreCompare);
    if(score > scoreCompare)
    {
        highScoreReplace();
        newHighscore(score);
    }
    else
    {
        noHighscore(score, scoreCompare);
    }
    fclose(save);
}


