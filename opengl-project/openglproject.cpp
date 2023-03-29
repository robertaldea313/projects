#include <windows.h>
#include <GL/gl.h>
#include <GL/glu.h>
#include <GL/glut.h>
#include <stdlib.h>

static GLfloat y = 0.0;
static GLfloat y2 = 25.0;
static bool valveFillOn = false;
static bool valveEmptyOn = false;


//empty valve
static GLfloat emptyRotateX = 5;
static GLfloat emptyRotateY = -20.0;
static GLfloat emptyColor = 1;

//fill valve
static GLfloat fillRotateX = -24.0;
static GLfloat fillRotateY = 5.0;
static GLfloat fillColor = 1;


static GLfloat timer = 1;
static bool evaporatingOn = false;

//evaporation
static GLfloat sizeMod = 0;
static GLfloat sizeMod2 = 0;
static GLfloat displace = 0.05;


//water empty 
static GLfloat waterEmptyY = -32.0;
static GLfloat waterFillY = 25;
static GLfloat evaporateFillY = 62;
void init(void)
{
    glClearColor(0.2, 0.0, 0.2, 0.0);
    glShadeModel(GL_FLAT);
}
void display(void)
{
    glClear(GL_COLOR_BUFFER_BIT);
    glPushMatrix();
    glTranslatef(0.0, 0.0, 0.0);
    glColor3f(0.6, 0.0, 0.6);
    glRectf(-15.0, 0.0, 15.0, 50.0);//tank

    //pipe
    glColor3f(0.4, 0.0, 0.5);
    glRectf(-2.0, 0.0, 2.0, -15.0);
    glRectf(-2.0, -20.0, 2.0, -30.0);
    glRectf(-2.0, -30.0, 12.0, -34);

    glRectf(-15.0, 23, -22, 27);
    glRectf(-24.0, 23, -75, 27);

    glRectf(-2.0, 50.0, 2.0, 70.0);
    glRectf(-2.0, 70.0, 30.0, 74.0);
    glRectf(28.0, 74.0, 32.0, 66.0);

    glColor3f(0.4, 0.0, 0.4);
    glRectf(10.0, 67.0, 20.0, 77.0);
    //tank2
    glColor3f(0.6, 0.0, 0.6);
    glRectf(22.0, 25.0, 50.0, 62.0);

    //endpipe
    glColor3f(0.4, 0.0, 0.4);
    glRectf(-4.0, 0.0, 4.0, -6.0);
    glRectf(8.0, -28.0, 12.0, -36);

    glRectf(-15.0, 21, -19, 29);

    glRectf(-4.0, 50.0, 4.0, 56.0);
    glRectf(26.0, 68.0, 34.0, 62.0);

    //valves
    //empty
    glColor3f(emptyColor, 1.5 - emptyColor, 0.5);
    glRectf(-emptyRotateX, -15.0, emptyRotateX, emptyRotateY);
    //fill
    glColor3f(fillColor, 1.5 - fillColor, 0.5);
    glRectf( -20.0, 25-fillRotateY, fillRotateX, 25+fillRotateY);

    //evaporation
    glColor3f(1.0, 0.6, 1.0);
    glRectf(-12+displace, 0 + displace, 12+displace, 11 * sizeMod + displace);
    displace *= -1;

    glColor3f(0.9 + (y / 50), 0.5 + (y / 50), 0.9 + (y / 50));
    glRectf(-11.5 + displace - (y / 15), 10 + displace, 11.5 + displace + (y / 15), 10 + 11 * sizeMod + displace);
    displace *= -1;

    glColor3f(0.8 + (y / 50), 0.4 + (y / 50), 0.8 + (y / 50));
    glRectf(-10 + displace - (y / 10), 20 + displace, 10 + displace + (y / 10), 20 + 11 * sizeMod + displace);
    displace *= -1;

    glColor3f(0.8 + (y / 50), 0.3 + (y / 50), 0.8 + (y / 50));
    glRectf(-9.5 + displace - (y / 10), 30 + displace, 9.5 + displace + (y / 10), 30 + 11 * sizeMod2 + displace);
    displace *= -1;

    glColor3f(0.7 + (y / 50), 0.2 + (y / 50), 0.7 + (y / 50));
    glRectf(-9 + displace - (y / 10), 40 + displace, 9 + displace + (y / 10), 40 + 10 * sizeMod2 + displace);
    displace *= -1;

    //liquid
    glPopMatrix();

    glColor3f(0.5, 0.2, 1.0);
    glRectf(-15.0, 0, 15.0, y);

    glColor3f(0.5, 0.2, 1.0);
    glRectf(22.0, 25.0, 50.0, y2);

    glRectf(12, -32, 13, waterEmptyY);
    glRectf(-15, 25, -14, waterFillY);
    glRectf(28.0, 62.0, 28.2, evaporateFillY);

    //heating
    glColor3f(1.0, 0.2, 0.5);
    glRectf(0.0, 10, 30.0, 12);
    glRectf(0.0, 12, 2.0, 5);
    glRectf(0.0, 3, 50.0, 5);

    //cooling
    glColor3f(0.5, 0.2, 1.0);
    glRectf(11.0, 72.0, 12.0, 90.0);
    glRectf(12.0, 72.0, 15.0, 73.0);
    glRectf(15.0, 72.0, 16.0, 120.0);

    glutSwapBuffers();

}
void fillTank(void)
{
    if (y < 50)
    {
        if(waterFillY > 0)
            waterFillY -= 0.01;
        else
        {
            y += 0.001;
        }

    }
    else
    {
        waterFillY = 25;
    }

    if (y > 0 && !evaporatingOn)
    {
        evaporatingOn = true;
    }
    else
        if (y > 0 && evaporatingOn)
        {
            timer -= 0.0001;
        }

    if (timer > 0.2 && timer < 0.3)
    {
        sizeMod = 1;
    }
    else if (timer >= 0 && timer < 0.2)
    {
        sizeMod2 = 1;
    }
    else if (timer <= -0.5)
    {
        timer = -0.5;
        if (evaporateFillY > 25)
        {
            evaporateFillY -= 0.01;
        }
        else
            y2 += 0.00001;
    }


    glutPostRedisplay();
}
void emptyTank(void)
{   
    if (y > 0)
    {
        y -= 0.001;
        waterEmptyY -= 0.01;
    }
    else
    {
        waterEmptyY = -32;
    }

    if (y <= 0 && evaporatingOn)
    {
        evaporatingOn = false;
    }
    else
        if (y <= 0 && !evaporatingOn)
        {
            timer += 0.001;
        }
    if (timer >= 1)
    {
        timer = 1;
        evaporateFillY = 62;
    }

    if (timer > 0.3)
    {
        sizeMod = 0;
    }
    else if (timer > 0.2)
    {
        sizeMod2 = 0;
    }
    glutPostRedisplay();
}
void tankIdle(void)
{
    if (y > 0 && !evaporatingOn)
    {
        evaporatingOn = true;
    }
    else
        if (y > 0 && evaporatingOn)
        {
            timer -= 0.0001;
            y -= 0.00001;
        }

    if (timer > 0.2 && timer < 0.3)
    {
        sizeMod = 1;
    }
    else if (timer >= 0 && timer < 0.2)
    {
        sizeMod2 = 1;
    }

    if (y <= 0 && evaporatingOn)
    {
        evaporatingOn = false;
    }
    else
        if (y <= 0 && !evaporatingOn)
        {
            timer += 0.001;
        }
    if (timer >= 1)
    {
        timer = 1;
        evaporateFillY = 62;
        }

    if (timer > 0.3)
    {
        sizeMod = 0;
    }
    else if (timer > 0.2)
    {
        sizeMod2 = 0;
    }
    else if (timer <= -0.5)
    {
        timer = -0.5;
        if (evaporateFillY > 25)
        {
            evaporateFillY -= 0.01;
        }
        else
            y2 += 0.00001;
    }

    glutPostRedisplay();

}

void reshape(int w, int h)
{
    glViewport(0, 0, (GLsizei)w, (GLsizei)h);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    glOrtho(-50.0, 50.0, -50.0, 100.0, -1.0, 1.0);
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
}
void mouse(int button, int state, int x, int y)
{
    switch (button) {
    case GLUT_LEFT_BUTTON:
        if (state == GLUT_DOWN)
            if (valveFillOn == false)
            {
                glutIdleFunc(fillTank);
                valveFillOn = true;
                valveEmptyOn = false;

                fillRotateX = -30.0;
                fillRotateY = 2.0;

                fillColor = 0.5;

                //empty off
                emptyRotateX = 5;
                emptyRotateY = -20;

                emptyColor = 1;

                waterEmptyY = -32;
            }
            else
            {
                valveFillOn = false;
                glutIdleFunc(tankIdle);

                fillRotateX = -24.0;
                fillRotateY = 5.0;

                fillColor = 1;
                waterFillY = 25;
            }
        break;
    case GLUT_RIGHT_BUTTON:
        if (state == GLUT_DOWN)
            if (valveEmptyOn == false)
            {
                glutIdleFunc(emptyTank);
                valveEmptyOn = true;
                valveFillOn = false;

                emptyRotateX = 2;
                emptyRotateY = -25;

                emptyColor = 0.5;

                //fill off
                fillRotateX = -24.0;
                fillRotateY = 5.0;

                fillColor = 1;

                waterFillY = 25;
            }
            else
            {
                valveEmptyOn = false;
                glutIdleFunc(tankIdle);

                emptyRotateX = 5;
                emptyRotateY = -20;

                emptyColor = 1;

                waterEmptyY = -32;
            }
        break;
    default:
        break;
    }
}

int main(int argc, char** argv)
{
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
    glutInitWindowSize(500, 500);
    glutInitWindowPosition(100, 100);
    glutCreateWindow(argv[0]);
    init();
    glutDisplayFunc(display);
    glutReshapeFunc(reshape);
    glutMouseFunc(mouse);
    glutMainLoop();
    return 0;
}
