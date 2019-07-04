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

    public Vector3 quadrado1;
    public Vector3 quadrado2;
    public Vector3 quadrado3;
    public Vector3 quadrado4;
    public Vector3 quadrado5;
    public Vector3 circulo1;
    public Vector3 circulo2;
    public Vector3 circulo3;
    public Vector3 circulo4;
    public Vector3 circulo5;
    public Vector3 triangulo1;
    public Vector3 triangulo2;
    public Vector3 triangulo3;
    public Vector3 triangulo4;
    public Vector3 triangulo5;

    public float[,] array2D;
    public bool key = false;
    public int code = 0;

    // Start is called before the first frame update
    void Start()
    {
        AllPositions();
    }

    // Update is called once per frame
    void Update()
    {
        // Vamos Escolher Tabuleiro
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (key == true)
            {
                key = false;
            }

            else if (key == false)
            {
                key = true;
            }
        }

        // SEM DISTRATORES
        if (key == true && Input.GetKeyDown(KeyCode.Alpha1))
        {
            code = 1;
            ChangeTabuleiro();
        }
        if (key == true && Input.GetKeyDown(KeyCode.Alpha2))
        {
            code = 2;
            ChangeTabuleiro();
        }
        if (key == true && Input.GetKeyDown(KeyCode.Alpha3))
        {
            code = 3;
            ChangeTabuleiro();
        }

        // COM DISTRATORES
        if (key == true && Input.GetKeyDown(KeyCode.Alpha4))
        {
            code = 4;
            ChangeTabuleiroDistratores();
        }
        if (key == true && Input.GetKeyDown(KeyCode.Alpha5))
        {
            code = 5;
            ChangeTabuleiroDistratores();
        }
        if (key == true && Input.GetKeyDown(KeyCode.Alpha6))
        {
            code = 6;
            ChangeTabuleiroDistratores();
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
        int colunas = 9*3;

        //(*1000)
        int comecaX = -1600;
        int comecaY = 800;
        int somas = 400;
        int incrementoX = comecaX;
        int incrementoY = comecaY;
        int coord = 0;

        array2D = new float[linhas, colunas];
        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j += 3)
            {
                incrementoX = comecaX + (somas * coord);
                incrementoY = comecaY - (somas * i);
                array2D[i, j] = incrementoX;
                array2D[i, j + 1] = incrementoY;
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

    public void ChangeTabuleiro()
    {
        //Quadrados
        square1.transform.position = quadrado1;
        square2.transform.position = quadrado2;
        square3.transform.position = quadrado3;
        square4.transform.position = quadrado4;
        square5.transform.position = quadrado5;

        //Circulos
        circle1.transform.position = circulo1;
        circle2.transform.position = circulo2;
        circle3.transform.position = circulo3;
        circle4.transform.position = circulo4;
        circle5.transform.position = circulo5;
        
        //Triangulos ao cantinho
        triangle1.transform.position = triangulo1;
        triangle2.transform.position = triangulo2;
        triangle3.transform.position = triangulo3;
        triangle4.transform.position = triangulo4;
        triangle5.transform.position = triangulo5;

        switch (code)
        {
            case 1:
                quadrado1.x = (array2D[0, 12]) / 1000;
                quadrado2.x = (array2D[1, 24]) / 1000;
                quadrado3.x = (array2D[2, 12]) / 1000;
                quadrado4.x = (array2D[3, 6]) / 1000;
                quadrado5.x = (array2D[4, 21]) / 1000;

                quadrado1.y = (array2D[0, 13]) / 1000;
                quadrado2.y = (array2D[1, 25]) / 1000;
                quadrado3.y = (array2D[2, 12]) / 1000;
                quadrado4.y = (array2D[3, 7]) / 1000;
                quadrado5.y = (array2D[4, 22]) / 1000;

                quadrado1.z = (array2D[0, 14]) / 1000;
                quadrado2.z = (array2D[1, 26]) / 1000;
                quadrado3.z = (array2D[2, 14]) / 1000;
                quadrado4.z = (array2D[3, 8]) / 1000;
                quadrado5.z = (array2D[4, 23]) / 1000;
                
                circulo1.x = (array2D[0, 3]) / 1000;
                circulo2.x = (array2D[1, 9]) / 1000;
                circulo3.x = (array2D[2, 18]) / 1000;
                circulo4.x = (array2D[3, 0]) / 1000;
                circulo5.x = (array2D[4, 12]) / 1000;

                circulo1.y = (array2D[0, 4]) / 1000;
                circulo2.y = (array2D[1, 10]) / 1000;
                circulo3.y = (array2D[2, 19]) / 1000;
                circulo4.y = (array2D[3, 1]) / 1000;
                circulo5.y = (array2D[4, 13]) / 1000;

                circulo1.z = (array2D[0, 5]) / 1000;
                circulo2.z = (array2D[1, 11]) / 1000;
                circulo3.z = (array2D[2, 20]) / 1000;
                circulo4.z = (array2D[3, 2]) / 1000;
                circulo5.z = (array2D[4, 14]) / 1000;
                break;

            case 2:
                quadrado1.x = (array2D[0, 15]) / 1000;
                quadrado2.x = (array2D[1, 6]) / 1000;
                quadrado3.x = (array2D[2, 21]) / 1000;
                quadrado4.x = (array2D[3, 12]) / 1000;
                quadrado5.x = (array2D[4, 24]) / 1000;

                quadrado1.y = (array2D[0, 16]) / 1000;
                quadrado2.y = (array2D[1, 7]) / 1000;
                quadrado3.y = (array2D[2, 22]) / 1000;
                quadrado4.y = (array2D[3, 13]) / 1000;
                quadrado5.y = (array2D[4, 25]) / 1000;

                quadrado1.z = (array2D[0, 17]) / 1000;
                quadrado2.z = (array2D[1, 8]) / 1000;
                quadrado3.z = (array2D[2, 23]) / 1000;
                quadrado4.z = (array2D[3, 14]) / 1000;
                quadrado5.z = (array2D[4, 25]) / 1000;

                circulo1.x = (array2D[0, 0]) / 1000;
                circulo2.x = (array2D[1, 18]) / 1000;
                circulo3.x = (array2D[2, 9]) / 1000;
                circulo4.x = (array2D[3, 3]) / 1000;
                circulo5.x = (array2D[4, 21]) / 1000;

                circulo1.y = (array2D[0, 1]) / 1000;
                circulo2.y = (array2D[1, 19]) / 1000;
                circulo3.y = (array2D[2, 10]) / 1000;
                circulo4.y = (array2D[3, 4]) / 1000;
                circulo5.y = (array2D[4, 22]) / 1000;

                circulo1.z = (array2D[0, 2]) / 1000;
                circulo2.z = (array2D[1, 20]) / 1000;
                circulo3.z = (array2D[2, 11]) / 1000;
                circulo4.z = (array2D[3, 5]) / 1000;
                circulo5.z = (array2D[4, 23]) / 1000;
                break;

            case 3:
                quadrado1.x = (array2D[0, 21]) / 1000;
                quadrado2.x = (array2D[1, 6]) / 1000;
                quadrado3.x = (array2D[2, 12]) / 1000;
                quadrado4.x = (array2D[3, 24]) / 1000;
                quadrado5.x = (array2D[4, 12]) / 1000;

                quadrado1.y = (array2D[0, 22]) / 1000;
                quadrado2.y = (array2D[1, 7]) / 1000;
                quadrado3.y = (array2D[2, 12]) / 1000;
                quadrado4.y = (array2D[3, 25]) / 1000;
                quadrado5.y = (array2D[4, 13]) / 1000;

                quadrado1.z = (array2D[0, 23]) / 1000;
                quadrado2.z = (array2D[1, 8]) / 1000;
                quadrado3.z = (array2D[2, 14]) / 1000;
                quadrado4.z = (array2D[3, 26]) / 1000;
                quadrado5.z = (array2D[4, 14]) / 1000;

                circulo1.x = (array2D[0, 12]) / 1000;
                circulo2.x = (array2D[1, 0]) / 1000;
                circulo3.x = (array2D[2, 18]) / 1000;
                circulo4.x = (array2D[3, 9]) / 1000;
                circulo5.x = (array2D[4, 3]) / 1000;

                circulo1.y = (array2D[0, 13]) / 1000;
                circulo2.y = (array2D[1, 1]) / 1000;
                circulo3.y = (array2D[2, 19]) / 1000;
                circulo4.y = (array2D[3, 10]) / 1000;
                circulo5.y = (array2D[4, 4]) / 1000;

                circulo1.z = (array2D[0, 14]) / 1000;
                circulo2.z = (array2D[1, 2]) / 1000;
                circulo3.z = (array2D[2, 20]) / 1000;
                circulo4.z = (array2D[3, 11]) / 1000;
                circulo5.z = (array2D[4, 5]) / 1000;
                break;
        }
        
        triangulo1.x = -2;
        triangulo2.x = -2;
        triangulo3.x = -2;
        triangulo4.x = -2;
        triangulo5.x = -2;

        triangulo1.y = (array2D[0, 19]) / 1000;
        triangulo2.y = (array2D[1, 7]) / 1000;
        triangulo3.y = (array2D[2, 1]) / 1000;
        triangulo4.y = (array2D[3, 13]) / 1000;
        triangulo5.y = (array2D[4, 25]) / 1000;

        triangulo1.z = -(10 / 1000);
        triangulo2.z = -(10 / 1000);
        triangulo3.z = -10 / 1000;
        triangulo4.z = -(10 / 1000);
        triangulo5.z = -(10 / 1000);
    }

    public void ChangeTabuleiroDistratores()
    {
        //Quadrados
        square1.transform.position = quadrado1;
        square2.transform.position = quadrado2;
        square3.transform.position = quadrado3;
        square4.transform.position = quadrado4;
        square5.transform.position = quadrado5;

        //Circulos
        circle1.transform.position = circulo1;
        circle2.transform.position = circulo2;
        circle3.transform.position = circulo3;
        circle4.transform.position = circulo4;
        circle5.transform.position = circulo5;
        
        //Triangulos
        triangle1.transform.position = triangulo1;
        triangle2.transform.position = triangulo2;
        triangle3.transform.position = triangulo3;
        triangle4.transform.position = triangulo4;
        triangle5.transform.position = triangulo5;

        switch (code)
        {
            case 4:
                quadrado1.x = (array2D[0, 12]) / 1000;
                quadrado2.x = (array2D[1, 24]) / 1000;
                quadrado3.x = (array2D[2, 12]) / 1000;
                quadrado4.x = (array2D[3, 6]) / 1000;
                quadrado5.x = (array2D[4, 21]) / 1000;

                quadrado1.y = (array2D[0, 13]) / 1000;
                quadrado2.y = (array2D[1, 25]) / 1000;
                quadrado3.y = (array2D[2, 12]) / 1000;
                quadrado4.y = (array2D[3, 7]) / 1000;
                quadrado5.y = (array2D[4, 22]) / 1000;

                quadrado1.z = (array2D[0, 14]) / 1000;
                quadrado2.z = (array2D[1, 26]) / 1000;
                quadrado3.z = (array2D[2, 14]) / 1000;
                quadrado4.z = (array2D[3, 8]) / 1000;
                quadrado5.z = (array2D[4, 23]) / 1000;

                circulo1.x = (array2D[0, 3]) / 1000;
                circulo2.x = (array2D[1, 9]) / 1000;
                circulo3.x = (array2D[2, 18]) / 1000;
                circulo4.x = (array2D[3, 0]) / 1000;
                circulo5.x = (array2D[4, 12]) / 1000;

                circulo1.y = (array2D[0, 4]) / 1000;
                circulo2.y = (array2D[1, 10]) / 1000;
                circulo3.y = (array2D[2, 19]) / 1000;
                circulo4.y = (array2D[3, 1]) / 1000;
                circulo5.y = (array2D[4, 13]) / 1000;

                circulo1.z = (array2D[0, 5]) / 1000;
                circulo2.z = (array2D[1, 11]) / 1000;
                circulo3.z = (array2D[2, 20]) / 1000;
                circulo4.z = (array2D[3, 2]) / 1000;
                circulo5.z = (array2D[4, 14]) / 1000;
                
                triangulo1.x = (array2D[0, 18]) / 1000;
                triangulo2.x = (array2D[1, 6]) / 1000;
                triangulo3.x = (array2D[2, 0]) / 1000;
                triangulo4.x = (array2D[3, 12]) / 1000;
                triangulo5.x = (array2D[4, 24]) / 1000;

                triangulo1.y = (array2D[0, 19]) / 1000;
                triangulo2.y = (array2D[1, 7]) / 1000;
                triangulo3.y = (array2D[2, 1]) / 1000;
                triangulo4.y = (array2D[3, 13]) / 1000;
                triangulo5.y = (array2D[4, 25]) / 1000;

                triangulo1.z = -(10 / 1000);
                triangulo2.z = -(10 / 1000);
                triangulo3.z = -(10 / 1000);
                triangulo4.z = -(10 / 1000);
                triangulo5.z = -(10 / 1000);
                break;

            case 5:
                quadrado1.x = (array2D[0, 15]) / 1000;
                quadrado2.x = (array2D[1, 6]) / 1000;
                quadrado3.x = (array2D[2, 21]) / 1000;
                quadrado4.x = (array2D[3, 12]) / 1000;
                quadrado5.x = (array2D[4, 24]) / 1000;

                quadrado1.y = (array2D[0, 16]) / 1000;
                quadrado2.y = (array2D[1, 7]) / 1000;
                quadrado3.y = (array2D[2, 22]) / 1000;
                quadrado4.y = (array2D[3, 13]) / 1000;
                quadrado5.y = (array2D[4, 25]) / 1000;

                quadrado1.z = (array2D[0, 17]) / 1000;
                quadrado2.z = (array2D[1, 8]) / 1000;
                quadrado3.z = (array2D[2, 23]) / 1000;
                quadrado4.z = (array2D[3, 14]) / 1000;
                quadrado5.z = (array2D[4, 25]) / 1000;

                circulo1.x = (array2D[0, 0]) / 1000;
                circulo2.x = (array2D[1, 18]) / 1000;
                circulo3.x = (array2D[2, 9]) / 1000;
                circulo4.x = (array2D[3, 3]) / 1000;
                circulo5.x = (array2D[4, 21]) / 1000;

                circulo1.y = (array2D[0, 1]) / 1000;
                circulo2.y = (array2D[1, 19]) / 1000;
                circulo3.y = (array2D[2, 10]) / 1000;
                circulo4.y = (array2D[3, 4]) / 1000;
                circulo5.y = (array2D[4, 22]) / 1000;

                circulo1.z = (array2D[0, 2]) / 1000;
                circulo2.z = (array2D[1, 20]) / 1000;
                circulo3.z = (array2D[2, 11]) / 1000;
                circulo4.z = (array2D[3, 5]) / 1000;
                circulo5.z = (array2D[4, 23]) / 1000;

                triangulo1.x = (array2D[0, 9]) / 1000;
                triangulo2.x = (array2D[1, 21]) / 1000;
                triangulo3.x = (array2D[2, 18]) / 1000;
                triangulo4.x = (array2D[3, 6]) / 1000;
                triangulo5.x = (array2D[4, 0]) / 1000;

                triangulo1.y = (array2D[0, 10]) / 1000;
                triangulo2.y = (array2D[1, 22]) / 1000;
                triangulo3.y = (array2D[2, 19]) / 1000;
                triangulo4.y = (array2D[3, 7]) / 1000;
                triangulo5.y = (array2D[4, 1]) / 1000;

                triangulo1.z = -(10 / 1000);
                triangulo2.z = -(10 / 1000);
                triangulo3.z = -(10 / 1000);
                triangulo4.z = -(10 / 1000);
                triangulo5.z = -(10 / 1000);
                break;

            case 6:
                quadrado1.x = (array2D[0, 21]) / 1000;
                quadrado2.x = (array2D[1, 6]) / 1000;
                quadrado3.x = (array2D[2, 12]) / 1000;
                quadrado4.x = (array2D[3, 24]) / 1000;
                quadrado5.x = (array2D[4, 12]) / 1000;

                quadrado1.y = (array2D[0, 22]) / 1000;
                quadrado2.y = (array2D[1, 7]) / 1000;
                quadrado3.y = (array2D[2, 12]) / 1000;
                quadrado4.y = (array2D[3, 25]) / 1000;
                quadrado5.y = (array2D[4, 13]) / 1000;

                quadrado1.z = (array2D[0, 23]) / 1000;
                quadrado2.z = (array2D[1, 8]) / 1000;
                quadrado3.z = (array2D[2, 14]) / 1000;
                quadrado4.z = (array2D[3, 26]) / 1000;
                quadrado5.z = (array2D[4, 14]) / 1000;

                circulo1.x = (array2D[0, 12]) / 1000;
                circulo2.x = (array2D[1, 0]) / 1000;
                circulo3.x = (array2D[2, 18]) / 1000;
                circulo4.x = (array2D[3, 9]) / 1000;
                circulo5.x = (array2D[4, 3]) / 1000;

                circulo1.y = (array2D[0, 13]) / 1000;
                circulo2.y = (array2D[1, 1]) / 1000;
                circulo3.y = (array2D[2, 19]) / 1000;
                circulo4.y = (array2D[3, 10]) / 1000;
                circulo5.y = (array2D[4, 4]) / 1000;

                circulo1.z = (array2D[0, 14]) / 1000;
                circulo2.z = (array2D[1, 2]) / 1000;
                circulo3.z = (array2D[2, 20]) / 1000;
                circulo4.z = (array2D[3, 11]) / 1000;
                circulo5.z = (array2D[4, 5]) / 1000;

                triangulo1.x = (array2D[0, 24]) / 1000;
                triangulo2.x = (array2D[1, 12]) / 1000;
                triangulo3.x = (array2D[2, 0]) / 1000;
                triangulo4.x = (array2D[3, 6]) / 1000;
                triangulo5.x = (array2D[4, 18]) / 1000;

                triangulo1.y = (array2D[0, 25]) / 1000;
                triangulo2.y = (array2D[1, 13]) / 1000;
                triangulo3.y = (array2D[2, 1]) / 1000;
                triangulo4.y = (array2D[3, 7]) / 1000;
                triangulo5.y = (array2D[4, 19]) / 1000;

                triangulo1.z = -(10 / 1000);
                triangulo2.z = -(10 / 1000);
                triangulo3.z = -(10 / 1000);
                triangulo4.z = -(10 / 1000);
                triangulo5.z = -(10 / 1000);
                break;
        }
    }

    void OnGUI()
    {
        if (key == false)
        {
            GUI.Label(new Rect(10, 90, 300, 35), "Board: " + code + " locked.");
            GUI.Label(new Rect(10, 110, 300, 35), "Press T + # to choose another.");
        }
        else if (key == true)
        {
            GUI.Label(new Rect(10, 90, 200, 35), "Board: " + code);
        }
    }
}
