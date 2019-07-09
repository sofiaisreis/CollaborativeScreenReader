using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabuleiros : MonoBehaviour
{
    public GameObject square1;
    public GameObject square2;
    public GameObject square3;
    public GameObject square4;
    public GameObject square5;
    public GameObject circle1;
    public GameObject circle2;
    public GameObject circle3;
    public GameObject circle4;
    public GameObject circle5;
    public GameObject triangle1;
    public GameObject triangle2;
    public GameObject triangle3;
    public GameObject triangle4;
    public GameObject triangle5;

    public Vector3 quadrado1, quadrado2, quadrado3, quadrado4, quadrado5;
    public Vector3 circulo1, circulo2, circulo3, circulo4, circulo5;
    public Vector3 triangulo1, triangulo2, triangulo3, triangulo4, triangulo5;

    public Vector3[] quadrados, circulos, triangulos;

    public float[,] array2D;
    public int code = 0;

    private System.Random r = new System.Random();

    /*
        1 * Há sempre 1 quadrado, 1 círculo e, no caso dos distratores, 1 triângulo por linha;
        2 * Não existem dois polígonos adjacentes;
        3 * A definir - maneira de balancear numero de objetos do lado direito e lado esquerdo.
    */

    // Start is called before the first frame update
    void Start()
    {
        AllPositions();
        quadrados = new Vector3[] { quadrado1, quadrado2, quadrado3, quadrado4, quadrado5 };
        circulos = new Vector3[] { circulo1, circulo2, circulo3, circulo4, circulo5 };
        triangulos = new Vector3[] { triangulo1, triangulo2, triangulo3, triangulo4, triangulo5 };
    }

    // Update is called once per frame
    void Update()
    {
        // Vamos Escolher Tabuleiro
        if (Input.GetKeyDown(KeyCode.T))
        {
            ChangeTabuleiro();
            code = 1;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ChangeTabuleiroDistratores();
            code = 2;
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            PrintTabuleiroCompleto();
        }
    }

    public void AllPositions()
    {
        // 2-dimentional array
        int linhas = 5;
        int colunas = 9;

        //(*1000)
        int comecaX = -1600;
        int somas = 400;
        int incrementoX = comecaX;
        int coord = 0;

        array2D = new float[linhas, colunas];
        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                incrementoX = comecaX + (somas * coord);
                array2D[i, j] = incrementoX;
                coord++;
                if (coord == 9) { coord = 0; }
            }
        }
        //print("Array Length: " + array2D.Length);
    }

    public void PrintTabuleiroCompleto()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 27; j++)
            {
                print("Array Pos [" + i + "," + j + "]" + ": " + "(" + array2D[i, j] + "," + array2D[i, j + 1] + "," + array2D[i, j + 2] + ")");
            }
        }
    }

    public int Randomerino()
    {
        return r.Next(0, 8);
    }

    private void RandomizeLine(int i)
    {
        //nos [i,0] a [i,8]
        quadrados[i].x = (array2D[0, Randomerino()]) / 1000;
        circulos[i].x = (array2D[0, Randomerino()]) / 1000;
        triangulos[i].x = (array2D[0, Randomerino()]) / 1000;

        while (HasAdjacents(i))
        {
            quadrados[i].x = (array2D[0, Randomerino()]) / 1000;
            circulos[i].x = (array2D[0, Randomerino()]) / 1000;
            triangulos[i].x = (array2D[0, Randomerino()]) / 1000;
        }
    }

    public bool HasAdjacents(int i)
    {
        //nao estao sobrepostos nem adjacentes em LINHAS
        if (Math.Abs(quadrados[i].x - circulos[i].x) < (float)800 / 1000) return true;
        if (Math.Abs(quadrados[i].x - triangulos[i].x) < (float)800 / 1000) return true;
        if (Math.Abs(triangulos[i].x - circulos[i].x) < (float)800 / 1000) return true;
        
        //nao estao em COLUNAS adjacentes
        if (i != 0)
        {
            if (quadrados[i].x == quadrados[i - 1].x) return true;
            if (quadrados[i].x == circulos[i - 1].x) return true;
            if (quadrados[i].x == triangulos[i - 1].x) return true;
            if (circulos[i].x == quadrados[i - 1].x) return true;
            if (circulos[i].x == circulos[i - 1].x) return true;
            if (circulos[i].x == triangulos[i - 1].x) return true;
            if (triangulos[i].x == quadrados[i - 1].x) return true;
            if (triangulos[i].x == circulos[i - 1].x) return true;
            if (triangulos[i].x == triangulos[i - 1].x) return true;
        }

        return false;        
    }

    public void HeuristicOne()
    {
        // yy fixos
        int comecaY = -800;
        int somas = 400;
        int incrementoY = comecaY;
        for (int i = 0; i < 5; i++)
        {
            // zz fixos
            triangulos[i].z = -(float)10 / 1000;

            incrementoY = comecaY + (somas * i);
            quadrados[i].y = (circulos[i].y = (triangulos[i].y = (float)incrementoY / 1000));
        }
    }



    public void HeuristicTwoDistratores()
    {
        for (int i = 0; i < 5; i++)
        {
            RandomizeLine(i);
        }
    }

    public void HeuristicTwoSemDistratores()
    {
        HeuristicTwoDistratores();
        // escondê-los bem
        for ( int i = 0; i < 5; i++)
        {
            triangulos[i].x = -1000;
        }
    }
    

    //3 * A definir - maneira de balancear numero de objetos do lado direito e lado esquerdo.



    public void ChangeTabuleiro()
    {
        /* HEURISTICA 1
         * Há sempre 1 quadrado, 1 círculo e, no caso dos distratores*/
        HeuristicOne();
        HeuristicTwoSemDistratores();

        //Quadrados
        square1.transform.localPosition = quadrados[0];
        square2.transform.localPosition = quadrados[1];
        square3.transform.localPosition = quadrados[2];
        square4.transform.localPosition = quadrados[3];
        square5.transform.localPosition = quadrados[4];

        //Circulos
        circle1.transform.localPosition = circulos[0];
        circle2.transform.localPosition = circulos[1];
        circle3.transform.localPosition = circulos[2];
        circle4.transform.localPosition = circulos[3];
        circle5.transform.localPosition = circulos[4];

        //Triangulos ao cantinho
        triangle1.transform.localPosition = triangulos[0];
        triangle2.transform.localPosition = triangulos[1];
        triangle3.transform.localPosition = triangulos[2];
        triangle4.transform.localPosition = triangulos[3];
        triangle5.transform.localPosition = triangulos[4];
    }

    public void ChangeTabuleiroDistratores()
    {
        /* HEURISTICA 1
        * Há sempre 1 quadrado, 1 círculo e, no caso dos distratores, 1 triângulo por linha */
        HeuristicOne();
        HeuristicTwoDistratores();

        ///Quadrados
        square1.transform.localPosition = quadrados[0];
        square2.transform.localPosition = quadrados[1];
        square3.transform.localPosition = quadrados[2];
        square4.transform.localPosition = quadrados[3];
        square5.transform.localPosition = quadrados[4];

        //Circulos
        circle1.transform.localPosition = circulos[0];
        circle2.transform.localPosition = circulos[1];
        circle3.transform.localPosition = circulos[2];
        circle4.transform.localPosition = circulos[3];
        circle5.transform.localPosition = circulos[4];

        //Triangulos ao cantinho
        triangle1.transform.localPosition = triangulos[0];
        triangle2.transform.localPosition = triangulos[1];
        triangle3.transform.localPosition = triangulos[2];
        triangle4.transform.localPosition = triangulos[3];
        triangle5.transform.localPosition = triangulos[4];
    }

    void OnGUI()
    {
        if (code  == 1)
        {
            GUI.Label(new Rect(10, 90, 300, 35), "Tabuleiro SEM distratores");
        }
        else if (code == 2)
        {
            GUI.Label(new Rect(10, 90, 300, 35), "Tabuleiro COM distratores");
        }
    }
}
