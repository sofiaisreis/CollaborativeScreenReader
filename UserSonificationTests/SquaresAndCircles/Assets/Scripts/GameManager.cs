using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    static int squares = 0;
    static int circles = 0;
    static int circInit = GameObject.FindGameObjectsWithTag("circle").Length;
    static int squaInit = GameObject.FindGameObjectsWithTag("square").Length;

    /*************************/
    /***** COUNT OBJECTS *****/
    /*************************/

    private static int IncrementSquares() { return ++squares; }

    private static int IncrementCircles() { return ++circles; }

    private static int GetCircInit() { return circInit; }

    private static int GetSquaInit() { return squaInit; }

    private static int GetCircAtual() { return circles; }

    private static int GetSquaAtual() { return squares; }    
}

