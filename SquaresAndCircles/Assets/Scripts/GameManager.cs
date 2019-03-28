using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    static int squares = 0;
    static int circles = 0;
    static int circInit = GameObject.FindGameObjectsWithTag("circle").Length;
    static int squaInit = GameObject.FindGameObjectsWithTag("square").Length;

    //Set the initial color (0f,0f,0f,0f)

    /*************************/
    /***** COUNT OBJECTS *****/
    /*************************/

    private static int IncrementSquares() { return ++squares; }

    private static int IncrementCircles() { return ++circles; }

    private static int GetCircInit() { return circInit; }

    private static int GetSquaInit() { return squaInit; }

    private static int GetCircAtual() { return circles; }

    private static int GetSquaAtual() { return squares; }


    /*************************/
    /***** TOUCH EVENTS ******/
    /*****     AND      ******/
    /***** SOUND MANAGER *****/
    /*************************/

    public static void HandleObjectEnter(string tag)
    {

    }

    public static void HandleObjectStay(string tag) //double click to select
    {

        if (tag == "square")
        {
           
        }
        else if (tag == "circle")
        {
        }
    }

    public static void HandleObjectExit(string tag)
    {
           
    }
}
