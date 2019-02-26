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
        static AudioSource myAudioSource;
        static AudioClip quadrado;
        static AudioClip circle;
        static AudioClip selected;


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
        /*************************/

        public static void HandleObjectEnter(string tag)
        {
            if (tag == "square")
            {

                if (GetSquaAtual() > 0)
                {
                    Debug.Log("Selected " + IncrementSquares() + " squares of total of " + GetSquaInit());
                }
                else if (GetSquaAtual() == 0)
                {
                    Debug.Log("Selected " + IncrementSquares() + " square of total of " + GetSquaInit());
                }
            } else if (tag == "circle")
            {
                if (GetCircAtual() > 0)
                {
                    Debug.Log("Selected " + IncrementCircles() + " circles a total of " + GetCircInit());
                }
                else if (GetCircAtual() == 0)
                {
                    Debug.Log("Selected " + IncrementCircles() + " circle a total of " + GetCircInit());
                }
            }
        }

        public static void HandleObjectSelect(MonoBehaviour obj)
        {

        }

        public static void HandleObjectExit(MonoBehaviour obj)
        {

        }

        /*************************/
        /***** SOUND MANAGER *****/
        /*************************/


    }
}