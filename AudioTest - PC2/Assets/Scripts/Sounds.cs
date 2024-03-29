﻿using UnityEngine;
using System;


/* APLICACAO PC ZENNIE */
public class Sounds : MonoBehaviour
{
    public GameObject female;
    public GameObject male;
    public GameObject select;
    public GameObject publics;
    public UDPListener udpConnection;
    public string feedbackType;
    public int port;
    public int user;
    public int userToPlay = 0;
    public int quadSelecionadosAteAgora = 0;
    public int circSelecionadosAteAgora = 0;
    public int faltamXQuad;
    public int faltamXCirc;
    public bool estaoTodosSelecionados = false;

    // Start is called before the first frame update
    void Start()
    {
        udpConnection = new UDPListener();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            user = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            user = 2;
        if (quadSelecionadosAteAgora == 5 && circSelecionadosAteAgora == 5) estaoTodosSelecionados = true;

        
        if (estaoTodosSelecionados)
        {
            System.Threading.Thread.Sleep(2000);
            select.GetComponent<Select>().TarefaTerminada();
            quadSelecionadosAteAgora = 0;
            circSelecionadosAteAgora = 0;
        }
        estaoTodosSelecionados = false;
    }

    public void ParseAndPlay(string stringToParse)
    {
        print("string_ " + stringToParse);
        string[] ourStrings = stringToParse.Split(':');
        
        // PLAY SOUNDS
        if (ourStrings[0] == "Play")
        {
            // string message = "Play:" + 
            // userID + ":" + lastObj + ":" + objTypeSound + ":" + relativePos1 + ":" + relativePos2;

            int userID = int.Parse(ourStrings[1]);
            int lastObj = int.Parse(ourStrings[2]);
            int objTypeSound = int.Parse(ourStrings[3]);
            Vector3 relativePos1 = new Vector3(float.Parse(ourStrings[4]) / 1000.0f * 2.0f, float.Parse(ourStrings[5]) / 1000.0f * 2.0f, float.Parse(ourStrings[6]) / 1000.0f * 2.0f);
            Vector3 relativePos2 = new Vector3(float.Parse(ourStrings[7]) / 1000.0f * 2.0f, float.Parse(ourStrings[8]) / 1000.0f * 2.0f, float.Parse(ourStrings[9]) / 1000.0f * 2.0f);
            int selecionadosQuad = int.Parse(ourStrings[10]);
            int totaisQuad = int.Parse(ourStrings[11]);
            int selecionadosCirc = int.Parse(ourStrings[12]);
            int totaisCirc = int.Parse(ourStrings[13]);
            int feedback = int.Parse(ourStrings[14]);
            int lastObjectGlobal = int.Parse(ourStrings[15]);
            int prevFeedback = int.Parse(ourStrings[16]);

            // Reinicia a contagem dos selecionados, porque se clicou 'a' estamos numa nova tarefa
            if(lastObj == -2)
            {
                quadSelecionadosAteAgora = 0;
                circSelecionadosAteAgora = 0;
                faltamXQuad = 5;
                faltamXCirc = 5;
                lastObj = -1;
                objTypeSound = -1;
                estaoTodosSelecionados = false;
                lastObjectGlobal = -1;
                select.GetComponent<Select>().TarefaQuadradosFemale = select.GetComponent<Select>().TarefaCirculosMale = false;
            }
            if(lastObjectGlobal == 1 && objTypeSound == 4)
            {
                quadSelecionadosAteAgora = selecionadosQuad;
                faltamXQuad = 5 - quadSelecionadosAteAgora;
            }
            if(lastObjectGlobal == 2 && objTypeSound == 4)
            {
                circSelecionadosAteAgora = selecionadosCirc;
                faltamXCirc = 5 - circSelecionadosAteAgora;
            }


            /*********** Feedback Private **********/
            if (feedback == 1)
            {
                feedbackType = "Private";
                switch (userID)
                {
                    //FEMALE - User 1 - verdinho
                    case 1:
                        // APLICACAO PARTE DELA
                        if (user == 1)
                        {
                            if (objTypeSound == 1)
                            {                            
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlaySquare();

                            }
                            else if (objTypeSound == 2)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlayCircle();

                            }
                            else if (objTypeSound == 3)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlayTriangle();

                            }
                            else if (objTypeSound == 4)
                            {
                                female.GetComponent<Female>().PlaySelected(lastObj, selecionadosQuad, totaisQuad);
                            }
                            else if (objTypeSound == 6)
                            {                              
                                female.GetComponent<Female>().PlayError();                             
                            }
                            else if (objTypeSound == 7)
                            {
                                female.GetComponent<Female>().PlayErrorVazio();                             
                            }
                        }
                        break;

                    //MALE - User 2 - Vermelho
                    case 2:
                        // APLICACAO PARTE DELE
                        if (user == 2)
                        {
                            if (objTypeSound == 1)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlaySquare();

                            }
                            else if (objTypeSound == 2)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlayCircle();

                            }
                            else if (objTypeSound == 3)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlayTriangle();

                            }
                            else if (objTypeSound == 4)
                            {
                                male.GetComponent<Male>().PlaySelected(lastObj, selecionadosCirc, totaisCirc);
                            }
                            else if (objTypeSound == 6)
                            {
                                male.GetComponent<Male>().PlayError();
                            }
                            else if (objTypeSound == 7)
                            {
                                male.GetComponent<Male>().PlayErrorVazio();
                            }
                        }
                        break;
                    default:
                        print("You have no user defined!");
                        break;
                }
            }

            /*********** Feedback Task-Dependent **********/
            if (feedback == 2)
            {
                feedbackType = "Task-Dependent";
                switch (userID)
                {
                    //FEMALE - User 1 - verdinho
                    case 1:
                        // APLICACAO PARTE DELA
                        if (user == 1)
                        {
                            // ELA OUVE QUADRADOS E CIRCULOS
                            if (objTypeSound == 1)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlaySquare();

                            }
                            else if (objTypeSound == 2)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlayCircle();

                            }
                            else if (objTypeSound == 3)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlayTriangle();

                            }
                            else if (objTypeSound == 4)
                            {
                                female.GetComponent<Female>().PlaySelected(lastObj, selecionadosQuad, totaisQuad);
                            }
                            else if (objTypeSound == 6)
                            {
                                female.GetComponent<Female>().PlayError();
                            }
                            else if (objTypeSound == 7)
                            {
                                female.GetComponent<Female>().PlayErrorVazio();
                            }
                        }
                        //APLICACAO PARTE DELE
                        else if (user == 2)
                        {
                            // ELE OUVE OS CIRCULOS EM QUE ELA TOCA
                            if (objTypeSound == 2)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlayCircle();

                            }
                            // Nao ouve os selected nem erros do outro
                        }
                        break;

                    //MALE - User 2 - Vermelho
                    case 2:
                        //APLICACAO PARTE DELA
                        if (user == 1)
                        {
                            // ELA OUVE OS QUADRADOS EM QUE ELE TOCA
                            if (objTypeSound == 1)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlaySquare();
                            }
                        }
                        //APLICACAO PARTE DELE
                        else if (user == 2)
                        {
                            // ELE OUVE OS QUADRADOS E OS CIRCULOS
                            if (objTypeSound == 1)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlaySquare();

                            }
                            else if (objTypeSound == 2)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlayCircle();

                            }
                            else if (objTypeSound == 3)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlayTriangle();

                            }
                            else if (objTypeSound == 4)
                            {
                                male.GetComponent<Male>().PlaySelected(lastObj, selecionadosCirc, totaisCirc);
                            }
                            else if (objTypeSound == 6)
                            {
                                male.GetComponent<Male>().PlayError();
                            }
                            else if (objTypeSound == 7)
                            {
                                male.GetComponent<Male>().PlayErrorVazio();
                            }
                        }
                        break;
                    default:
                        print("You have no user defined!");
                        break;
                }
            }


            /*********** Feedback Public **********/
            if (feedback == 3)
            {
                feedbackType = "Public";
                switch (userID)
                {
                    //FEMALE - User 1 - verdinho
                    case 1:
                        // APLICACAO PARTE DELA
                        if (user == 1)
                        {
                            if (objTypeSound == 1)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlaySquare();

                            }
                            else if (objTypeSound == 2)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlayCircle();
                            }
                            else if (objTypeSound == 3)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlayTriangle();

                            }
                            else if (objTypeSound == 4)
                            {
                                //Select Alto/Normal para ela
                                female.GetComponent<Female>().PlaySelected(lastObj, selecionadosQuad, totaisQuad);
                            }
                            else if (objTypeSound == 6)
                            {
                                //Select Alto/Normal para ela
                                female.GetComponent<Female>().PlayError();
                            }
                            else if (objTypeSound == 7)
                            {
                                //Select Alto/Normal para ela
                                female.GetComponent<Female>().PlayErrorVazio();
                            }
                        }
                        // APLICACAO PARTE DELE
                        else if (user == 2)
                        {
                            // ELE OUVE OS QUADRADOS, CIRCULOS EM QUE ELE TOCA. SELECTED, ERROR BUT NOT EXPLANATION
                            if (objTypeSound == 1)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlaySquare();

                            }
                            else if (objTypeSound == 2)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlayCircle();

                            }
                            else if (objTypeSound == 3)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlayTriangle();

                            }
                            else if (objTypeSound == 4)
                            {
                                //Select Baixo para ele ouvir baixo
                                //female.transform.position =;
                                female.GetComponent<Female>().PlaySelectedPublic(lastObj, selecionadosCirc, totaisCirc);
                            }
                            else if (objTypeSound == 6)
                            {
                                //Erro Baixo para ele ouvir baixo
                                //female.transform.position =
                                female.GetComponent<Female>().PlayErrorPublic();
                            }
                            else if (objTypeSound == 7)
                            {
                                //Erro Baixo para ele ouvir baixo
                                female.GetComponent<Female>().PlayErrorVazioPublic();
                            }
                        }
                        break;

                    //MALE - User 2 - Vermelho
                    case 2:
                        // APLICACAO PARTE DELA
                        if (user == 1)
                        {
                            // ELA OUVE OS QUADRADOS, CIRCULOS EM QUE ELE TOCA. SELECTED, ERROR BUT NOT EXPLANATION
                            if (objTypeSound == 1)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlaySquare();

                            }
                            else if (objTypeSound == 2)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlayCircle();
                            }
                            else if (objTypeSound == 3)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlayTriangle();
                            }
                            else if (objTypeSound == 4)
                            {

                                //Select Baixo para ela ouvir baixo
                                //male.transform.position =;
                                male.GetComponent<Male>().PlaySelectedPublic(lastObj, selecionadosQuad, totaisQuad);
                            }
                            else if (objTypeSound == 6)
                            {
                                //Selected Baixo para ela ouvir baixo
                                //male.transform.position =
                                male.GetComponent<Male>().PlayErrorPublic();
                            }
                            else if (objTypeSound == 7)
                            {
                                male.GetComponent<Male>().PlayErrorVazioPublic();
                            }
                        }
                        // APLICACAO PARTE DELE
                        else if (user == 2)
                        {
                            if (objTypeSound == 1)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlaySquare();

                            }
                            else if (objTypeSound == 2)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlayCircle();

                            }
                            else if (objTypeSound == 3)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlayTriangle();

                            }
                            else if (objTypeSound == 4)
                            {
                                //Select Alto/Normal para ele
                                male.GetComponent<Male>().PlaySelected(lastObj, selecionadosCirc, totaisCirc);
                            }
                            else if (objTypeSound == 6)
                            {
                                //Erro Alto/Normal para ele
                                male.GetComponent<Male>().PlayError();
                            }
                            else if (objTypeSound == 7)
                            {
                                male.GetComponent<Male>().PlayErrorVazio();
                            }
                        }
                        break;
                    default:
                        print("You have no user defined!");
                        break;
                }
            }

            /*********** Feedback LUCI **********/
            if (feedback == 6)
            {
                feedbackType = "LUCI";
                switch (userID)
                {
                    //FEMALE - User 1 - verdinho
                    case 1:
                        // APLICACAO PARTE DELA - so toca os female
                        if (user == 1)
                        {
                            if (objTypeSound == 1)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlaySquare();
                            }
                           /* else if (objTypeSound == 2)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Female>().PlayCircle();
                            }*/
                            else if (objTypeSound == 4)
                            {
                                switch (prevFeedback)
                                {
                                    //private
                                    case 1:
                                        if (lastObjectGlobal == 1)
                                        {
                                            female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            female.GetComponent<Female>().PlaySelected(lastObjectGlobal, selecionadosQuad, totaisQuad);
                                        }
                                       /* else if (lastObjectGlobal == 2)
                                        {
                                            male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            male.GetComponent<Male>().PlaySelected(lastObjectGlobal, selecionados, totais);
                                        }*/
                                        break;
                                    // TD
                                    case 2:
                                        if (lastObjectGlobal == 1)
                                        {
                                            female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            female.GetComponent<Female>().PlaySelected(lastObjectGlobal, selecionadosQuad, totaisQuad);
                                        }
                                        /*else if (lastObjectGlobal == 2)
                                        {
                                            male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            male.GetComponent<Male>().PlaySelected(lastObjectGlobal, selecionados, totais);
                                        }*/
                                        break;
                                    // Public
                                    case 3:
                                        if (lastObjectGlobal == 1)
                                        {
                                            female.GetComponent<Female>().PlaySelected(lastObjectGlobal, selecionadosQuad, totaisQuad);

                                            male.GetComponent<Male>().PlaySelectedPublic(lastObjectGlobal, selecionadosQuad, totaisQuad);
                                        }
                                        else if (lastObjectGlobal == 2)
                                        {
                                            male.GetComponent<Male>().PlaySelected(lastObjectGlobal, selecionadosCirc, totaisCirc);

                                            female.GetComponent<Female>().PlaySelectedPublic(lastObjectGlobal, selecionadosCirc, totaisCirc);
                                        }
                                        break;
                                }

                            }
                        }

                        // APLICACAO PARTE DELE
                        else if (user == 2)
                        {
                            // ELE OUVE OS CIRCULOS EM QUE ELA TOCA E SELECTED
                            /*if (objTypeSound == 1)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlaySquare();

                            }*/
                            if (objTypeSound == 2)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Female>().PlayCircle();
                            }
                            else if (objTypeSound == 4)
                            {
                                switch (prevFeedback)
                                {
                                    //private
                                    case 1:
                                        /*if (lastObjectGlobal == 1)
                                        {
                                            female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            female.GetComponent<Female>().PlaySelected(lastObjectGlobal, selecionados, totais);
                                        }*/
                                        if (lastObjectGlobal == 2)
                                        {
                                            male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            male.GetComponent<Male>().PlaySelected(lastObjectGlobal, selecionadosCirc, totaisCirc);
                                        }
                                        break;
                                    // TD
                                    case 2:
                                        /*if (lastObjectGlobal == 1)
                                        {
                                            female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            female.GetComponent<Female>().PlaySelected(lastObjectGlobal, selecionados, totais);
                                        }*/
                                        if (lastObjectGlobal == 2)
                                        {
                                            male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            male.GetComponent<Male>().PlaySelected(lastObjectGlobal, selecionadosCirc, totaisCirc);
                                        }
                                        break;
                                    // Public
                                    case 3:
                                        if (lastObjectGlobal == 1)
                                        {
                                            female.GetComponent<Female>().PlaySelected(lastObjectGlobal, selecionadosQuad, totaisQuad);

                                            male.GetComponent<Male>().PlaySelectedPublic(lastObjectGlobal, selecionadosQuad, totaisQuad);
                                        }
                                        else if (lastObjectGlobal == 2)
                                        {
                                            male.GetComponent<Male>().PlaySelected(lastObjectGlobal, selecionadosCirc, totaisCirc);

                                            female.GetComponent<Female>().PlaySelectedPublic(lastObjectGlobal, selecionadosCirc, totaisCirc);
                                        }
                                        break;
                                }

                            }
                        }
                            break;

                        //MALE - User 2 - Vermelho
                        case 2:
                        // APLICACAO PARTE DELA
                        if (user == 1)
                        {
                            // ELA OUVE OS QUADRADOS, CIRCULOS EM QUE ELE TOCA. SELECTED, ERROR BUT NOT EXPLANATION
                            if (objTypeSound == 1)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlaySquare();
                            }
                            /*else if (objTypeSound == 2)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlayCircle();
                            }*/
                            else if (objTypeSound == 4)
                            {
                                switch (prevFeedback)
                                {
                                    //private
                                    case 1:
                                        if (lastObjectGlobal == 1)
                                        {
                                            female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            female.GetComponent<Female>().PlaySelected(lastObjectGlobal, selecionadosQuad, totaisQuad);
                                        }
                                        /*else if (lastObjectGlobal == 2)
                                        {
                                            male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            male.GetComponent<Male>().PlaySelected(lastObjectGlobal, selecionados, totais);
                                        }*/
                                        break;
                                    // TD
                                    case 2:
                                       if (lastObjectGlobal == 1)
                                        {
                                            female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            female.GetComponent<Female>().PlaySelected(lastObjectGlobal, selecionadosQuad, totaisQuad);
                                        }
                                        /*else if (lastObjectGlobal == 2)
                                        {
                                            male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            male.GetComponent<Male>().PlaySelected(lastObjectGlobal, selecionados, totais);
                                        }*/
                                        break;
                                    // Public
                                    case 3:
                                        if (lastObjectGlobal == 1)
                                        {
                                            female.GetComponent<Female>().PlaySelected(lastObjectGlobal, selecionadosQuad, totaisQuad);

                                            male.GetComponent<Male>().PlaySelectedPublic(lastObjectGlobal, selecionadosQuad, totaisQuad);
                                        }
                                        else if (lastObjectGlobal == 2)
                                        {
                                            male.GetComponent<Male>().PlaySelected(lastObjectGlobal, selecionadosCirc, totaisCirc);

                                            female.GetComponent<Female>().PlaySelectedPublic(lastObjectGlobal, selecionadosCirc, totaisCirc);
                                        }
                                        break;
                                }

                            }
                        }
                        // APLICACAO PARTE DELE
                        else if (user == 2)
                        {
                           /* if (objTypeSound == 1)
                            {
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                female.GetComponent<Female>().PlaySquare();

                            }
                            else */if (objTypeSound == 2)
                            {
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                male.GetComponent<Male>().PlayCircle();
                            }
                            else if (objTypeSound == 4)
                            {
                                switch (prevFeedback)
                                {
                                    //private
                                    case 1:
                                       /* if (lastObjectGlobal == 1)
                                        {
                                            female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            female.GetComponent<Female>().PlaySelected(lastObjectGlobal, selecionados, totais);
                                        }
                                        else */if (lastObjectGlobal == 2)
                                        {
                                            male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            male.GetComponent<Male>().PlaySelected(lastObjectGlobal, selecionadosCirc, totaisCirc);
                                        }
                                        break;
                                    // TD
                                    case 2:
                                       /* if (lastObjectGlobal == 1)
                                        {
                                            female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            female.GetComponent<Female>().PlaySelected(lastObjectGlobal, selecionados, totais);
                                        }
                                        else */if (lastObjectGlobal == 2)
                                        {
                                            male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                            male.GetComponent<Male>().PlaySelected(lastObjectGlobal, selecionadosCirc, totaisCirc);
                                        }
                                        break;
                                    // Public
                                    case 3:
                                        if (lastObjectGlobal == 1)
                                        {
                                            female.GetComponent<Female>().PlaySelected(lastObjectGlobal, selecionadosQuad, totaisQuad);

                                            male.GetComponent<Male>().PlaySelectedPublic(lastObjectGlobal, selecionadosQuad, totaisQuad);
                                        }
                                        else if (lastObjectGlobal == 2)
                                        {
                                            male.GetComponent<Male>().PlaySelected(lastObjectGlobal, selecionadosCirc, totaisCirc);

                                            female.GetComponent<Female>().PlaySelectedPublic(lastObjectGlobal, selecionadosCirc, totaisCirc);
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    default:
                        print("You have no user defined!");
                        break;
                }
                print("Nao entrei em nada");
            }
        }

        // STOP SOUNDS
        else if (ourStrings[0] == "Stop")
        {
            print("TOU STOPPES");
            int userID = int.Parse(ourStrings[1]);
            switch (userID)
            {
                case 1:
                    female.GetComponent<Female>().Stop();
                    break;
                case 2:
                    male.GetComponent<Male>().Stop();
                    break;
            }
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), "User " + user);
        GUI.Label(new Rect(0, 15, 200, 35), "Feedback Type: " + feedbackType);
    }

   /*if (user == 1)
                                {
                                    female.transform.position = relativePos1;
                                }
                                else if (user == 2)
                                {
                                    female.transform.position = relativePos2;
                                }
                                else
                                {
                                    female.transform.position = Vector3.zero;
                                }
                                ou, simplificando sempre:
                                 
                            is the same as
                            female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero; */

}