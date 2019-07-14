using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public int squaresOnBoard = 0;
    public int circlesOnBoard = 0;
    public int trianglesOnBoard = 0;

    public float[,] array2D;
    public int code = 0;

    //Lista de Tabuleiros
    public Vector3[] AllPositionsTabuleiro;
    public Vector3[] AglomeradoDeVectosrs3Pos;
    public List<string> tabuleiros = new List<string>();
    public List<Vector3> tabuleirosD = new List<Vector3>();

    private System.Random r = new System.Random();

    /*
        1 * Há sempre 1 quadrado, 1 círculo e, no caso dos distratores, 1 triângulo por linha;
        2 * Não existem dois polígonos adjacentes;
        3 * Maneira de balancear numero de objetos do lado direito e lado esquerdo. Entre 2 a 4 de um lado
    */

    // Start is called before the first frame update
    void Start()
    {
        AllPositions();
        AllPositionsTabuleiro = new Vector3[] {
            quadrado1, quadrado2, quadrado3, quadrado4, quadrado5,
            circulo1, circulo2, circulo3, circulo4, circulo5,
            triangulo1, triangulo2, triangulo3, triangulo4, triangulo5
        };

        quadrados = new Vector3[] { quadrado1, quadrado2, quadrado3, quadrado4, quadrado5 };
        circulos = new Vector3[] { circulo1, circulo2, circulo3, circulo4, circulo5 };
        triangulos = new Vector3[] { triangulo1, triangulo2, triangulo3, triangulo4, triangulo5 };
    }

    // Update is called once per frame
    void Update()
    {
        // Vamos Escolher Tabuleiros para guardar
        if (Input.GetKeyDown(KeyCode.T))
        {
            code = 1;
            ChangeTabuleiro();
            HeuristicThreeSem();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            code = 2;
            ChangeTabuleiroDistratores();
            HeuristicThreeCom();
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
    }

    public void PrintTabuleiroCompleto()
    {
        string lineTotal = "";

        for (int i = 0; i < AllPositionsTabuleiro.Length ; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i < 5)
                {
                    AllPositionsTabuleiro[i] = quadrados[j];
                    if (code == 1) lineTotal += quadrados[j] + ":"; //tabuleiros.Add(quadrados[i]);
                    if (code == 2) tabuleirosD.Add(quadrados[j]);
                }
                else if (i >= 5 && i < 10)
                {
                    AllPositionsTabuleiro[i] = circulos[j];
                    if (code == 1)  lineTotal += circulos[j] + ":"; //tabuleiros.Add(circulos[i-5]);
                    if (code == 2) tabuleirosD.Add(circulos[j]);
                }
                else if (i >= 10 && i < 15)
                {
                    AllPositionsTabuleiro[i] = triangulos[j];
                    if (code == 1) lineTotal += triangulos[j] + ":"; //tabuleiros.Add(triangulos[i-10]);
                    if (code == 2) tabuleirosD.Add(triangulos[j]);
                }

            }
        }
        if (code == 1)
        {
            print("Line: " + lineTotal);
            // Cada linha eh um tabuleiro
            //Cada coordenada é separada por ":"
            tabuleiros.Add(lineTotal);
        }
    }

    public int Randomerino(int i)
    {
        return r.Next(0, i);
    }

    private void RandomizeLine(int i)
    {
        //nos [i,0] a [i,8]
        quadrados[i].x = (array2D[0, Randomerino(8)]) / 1000;
        circulos[i].x = (array2D[0, Randomerino(8)]) / 1000;
        triangulos[i].x = (array2D[0, Randomerino(8)]) / 1000;

        while (HasAdjacents(i))
        {
            quadrados[i].x = (array2D[0, Randomerino(8)]) / 1000;
            circulos[i].x = (array2D[0, Randomerino(8)]) / 1000;
            triangulos[i].x = (array2D[0, Randomerino(8)]) / 1000;
        }
    }

    public bool HasAdjacents(int i)
    {
        //H1 - nao estao sobrepostos nem adjacentes em LINHAS
        if (Math.Abs(quadrados[i].x - circulos[i].x) < (float)800 / 1000) return true;
        if (Math.Abs(quadrados[i].x - triangulos[i].x) < (float)800 / 1000) return true;
        if (Math.Abs(triangulos[i].x - circulos[i].x) < (float)800 / 1000) return true;

        //H2 - nao estao em COLUNAS adjacentes
        if (i != 0) { 
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
        square1.SetActive(true);
        square2.SetActive(true);
        square3.SetActive(true);
        square4.SetActive(true);
        square5.SetActive(true);

        //Circulos
        circle1.transform.localPosition = circulos[0];
        circle2.transform.localPosition = circulos[1];
        circle3.transform.localPosition = circulos[2];
        circle4.transform.localPosition = circulos[3];
        circle5.transform.localPosition = circulos[4];
        circle1.SetActive(true);
        circle2.SetActive(true);
        circle3.SetActive(true);
        circle4.SetActive(true);
        circle5.SetActive(true);

        //Triangulos ao cantinho
        triangle1.transform.localPosition = triangulos[0];
        triangle2.transform.localPosition = triangulos[1];
        triangle3.transform.localPosition = triangulos[2];
        triangle4.transform.localPosition = triangulos[3];
        triangle5.transform.localPosition = triangulos[4];
        triangle1.SetActive(true);
        triangle2.SetActive(true);
        triangle3.SetActive(true);
        triangle4.SetActive(true);
        triangle5.SetActive(true);
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
        square1.SetActive(true);
        square2.SetActive(true);
        square3.SetActive(true);
        square4.SetActive(true);
        square5.SetActive(true);

        //Circulos
        circle1.transform.localPosition = circulos[0];
        circle2.transform.localPosition = circulos[1];
        circle3.transform.localPosition = circulos[2];
        circle4.transform.localPosition = circulos[3];
        circle5.transform.localPosition = circulos[4];
        circle1.SetActive(true);
        circle2.SetActive(true);
        circle3.SetActive(true);
        circle4.SetActive(true);
        circle5.SetActive(true);

        //Triangulos
        triangle1.transform.localPosition = triangulos[0];
        triangle2.transform.localPosition = triangulos[1];
        triangle3.transform.localPosition = triangulos[2];
        triangle4.transform.localPosition = triangulos[3];
        triangle5.transform.localPosition = triangulos[4];
        triangle1.SetActive(true);
        triangle2.SetActive(true);
        triangle3.SetActive(true);
        triangle4.SetActive(true);
        triangle5.SetActive(true);
    }

    private void HeuristicThreeSem()
    {
        //TO DO, VER ARRAY
        // so quero ver ate metade. 
        for (int colunas = 0; colunas < 5; colunas++)
        {
            for (int numObj = 0; numObj < 5; numObj++)
            {
                if (quadrados[numObj].x == array2D[numObj, colunas])
                {
                    squaresOnBoard++;
                }
                if(circulos[numObj].x == array2D[numObj, colunas])
                {
                    circlesOnBoard++;
                }
            }
        }
        print("Squares: " + squaresOnBoard + " and Circles: " + circlesOnBoard);

        // Se no lado esquerdo do tabuleiro houver menos que 2 objetos de cada e mais que 4: refaz
        if (squaresOnBoard < 2 || squaresOnBoard > 4 || circlesOnBoard < 2 || circlesOnBoard > 4)
        {
            ChangeTabuleiro();
            print("Fiz refactor");
            squaresOnBoard = 0;
            circlesOnBoard = 0;
        }
        else
        {
            print("Board Accepted!");
        }
    }

    private void HeuristicThreeCom()
    {
        // so quero ver ate metade. 
        for (int colunas = 0; colunas < 5; colunas++)
        {
            for (int numObj = 0; numObj < 5; numObj++)
            {
                if (quadrados[numObj].x == array2D[numObj, colunas])
                {
                    squaresOnBoard++;
                }
                if (circulos[numObj].x == array2D[numObj, colunas])
                {
                    circlesOnBoard++;
                }
                if(triangulos[numObj].x == array2D[numObj, colunas])
                {
                    trianglesOnBoard++;
                }
            }
        }

        // Se no lado esquerdo do tabuleiro houver menos que 2 objetos de cada e mais que 4: refaz
        if (squaresOnBoard < 2 || squaresOnBoard > 4 || circlesOnBoard < 2 || circlesOnBoard > 4 || trianglesOnBoard < 2 || trianglesOnBoard > 4)
        {
            ChangeTabuleiroDistratores();
            print("Fiz refactor");
            squaresOnBoard = 0;
            circlesOnBoard = 0;
            trianglesOnBoard = 0;
        }
        else
        {
            print("Board Accepted!");
        }
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
