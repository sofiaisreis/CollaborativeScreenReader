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
    public bool YouShouldRefactor;
    public int code = 0;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Vamos Escolher Tabuleiros para guardar
        if (Input.GetKeyDown(KeyCode.T))
        {
            code = 1;
            ChangeTabuleiro();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            code = 2;
            ChangeTabuleiroDistratores();
        }
    }
    
    public void ChangeTabuleiro()
    {
        //Quadrados
        square1.SetActive(true);
        square2.SetActive(true);
        square3.SetActive(true);
        square4.SetActive(true);
        square5.SetActive(true);

        //Circulos
        circle1.SetActive(true);
        circle2.SetActive(true);
        circle3.SetActive(true);
        circle4.SetActive(true);
        circle5.SetActive(true);

        //Triangulos ao cantinho
        triangle1.SetActive(false);
        triangle2.SetActive(false);
        triangle3.SetActive(false);
        triangle4.SetActive(false);
        triangle5.SetActive(false);

    }

    public void ChangeTabuleiroDistratores()
    {
        ///Quadrados
        square1.SetActive(true);
        square2.SetActive(true);
        square3.SetActive(true);
        square4.SetActive(true);
        square5.SetActive(true);

        //Circulos
        circle1.SetActive(true);
        circle2.SetActive(true);
        circle3.SetActive(true);
        circle4.SetActive(true);
        circle5.SetActive(true);

        //Triangulos
        triangle1.SetActive(true);
        triangle2.SetActive(true);
        triangle3.SetActive(true);
        triangle4.SetActive(true);
        triangle5.SetActive(true);
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
