using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassDemo {

    public static class CountObjects {

        static int squares = 0;
        static int triangles = 0;
        static int triInit = GameObject.FindGameObjectsWithTag("triangle").Length;
        static int squaInit = GameObject.FindGameObjectsWithTag("square").Length;

        public static int IncrementSquares() { squares++; return squares; }

        public static int IncrementTriangles() { triangles++; return triangles; }

        public static int GetTriInit() { return triInit; }

        public static int GetSquaInit() { return squaInit; }

        public static int GetTriAtual() { return triangles; }

        public static int GetSquaAtual() { return squares; }
    }
}