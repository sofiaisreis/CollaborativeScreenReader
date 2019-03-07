using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassDemo {

    public static class GameManager
    {
        static int squares = 0;
        static int circles = 0;
        static int circInit = GameObject.FindGameObjectsWithTag("circle").Length;
        static int squaInit = GameObject.FindGameObjectsWithTag("square").Length;
        static AudioClip quadradoM;
        static AudioClip circuloM;
        static AudioClip selectedM;
        static AudioClip exitObjM;
        //Set the initial color (0f,0f,0f,0f)

        /*************************/
        /***** COUNT OBJECTS *****/
        /*************************/

        private static int IncrementSquares() { squares++; return squares; }

        private static int IncrementCircles() { circles++; return circles; }

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

        public static void HandleObjectStay(string tag, bool squareEnter, bool circleEnter) //double click to select
        {

            if (tag == "square")
            {
                if (squareEnter)
                {

                }
                /*
                if (GetSquaAtual() > 0)
                {
                    Debug.Log("Selected " + IncrementSquares() + " squares of total of " + GetSquaInit());
                }
                else if (GetSquaAtual() == 0)
                {
                    Debug.Log("Selected " + IncrementSquares() + " square of total of " + GetSquaInit());
                }*/
            }
            else if (tag == "circle")
            {
                if (circleEnter)
                {

                }
                
                /*if (GetCircAtual() > 0)
                {
                    Debug.Log("Selected " + IncrementCircles() + " circles a total of " + GetCircInit());
                }
                else if (GetCircAtual() == 0)
                {
                    Debug.Log("Selected " + IncrementCircles() + " circle a total of " + GetCircInit());
                }*/
            }
        }

        public static void HandleObjectExit(string tag, bool objExit)
        {
           
        }
    }
}