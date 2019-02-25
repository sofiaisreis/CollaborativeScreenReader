using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassDemo {

    public static class CountObjects {

        static int squares = 0;
        static int circles = 0;
        static int circInit = GameObject.FindGameObjectsWithTag("circle").Length;
        static int squaInit = GameObject.FindGameObjectsWithTag("square").Length;

        public static int IncrementSquares() { squares++; return squares; }

        public static int IncrementCircles() { circles++; return circles; }

        public static int GetCircInit() { return circInit; }

        public static int GetSquaInit() { return squaInit; }

        public static int GetCircAtual() { return circles; }

        public static int GetSquaAtual() { return squares; }
    }
}