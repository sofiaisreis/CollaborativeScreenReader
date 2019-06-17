using UnityEngine;
using System;


/* APLICACAO PC ZENNIE */
public class Sounds : MonoBehaviour
{
    public GameObject female;
    public GameObject male;
    public GameObject select;
    public UDPListener udpConnection;
    public string feedbackType;
    public int port;
    public int user;
    public int userToPlay = 0;

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

        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            //Feedback privado
            feedbackType = "Private";
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            //Feedback task-dependent
            feedbackType = "Task-Dependent";
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Feedback publico
            feedbackType = "Public";
        }*/
    }

    internal void ParseAndPlay(string stringToParse)
    {
        print("string_ " + stringToParse);
        string[] ourStrings = stringToParse.Split(':');

        if (ourStrings[0] == "FeedbackType")
        {
            //OUR FEEDBACK MODE
            int feedback = int.Parse(ourStrings[1]);

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
            int selecionados = int.Parse(ourStrings[10]);
            int totais = int.Parse(ourStrings[11]);

            
                /*********** Feedback Private **********/
                if (feedback == 1)
                {
                    feedbackType = "Private";
                    GUI.Label(new Rect(0, 15, 200, 100), "Feedback " + feedbackType);
                    print("Private");
                    switch (userID)
                    {
                        case 1:
                            if (user == 1)
                            {
                                if (objTypeSound == 1)
                                {
                                    female.GetComponent<Female>().PlaySquare();
                                    female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                                }
                                else if (objTypeSound == 2)
                                {
                                    female.GetComponent<Female>().PlayCircle();
                                    female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                                }
                                else if (objTypeSound == 3)
                                {
                                    female.GetComponent<Female>().PlayTriangle();
                                    female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                                }
                                else if (objTypeSound == 4)
                                {
                                    female.GetComponent<Female>().PlaySelected(lastObj, selecionados, totais);
                                    female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                }
                                else if (objTypeSound == 6)
                                {
                                    print("Não podes selecionar isso!");
                                    female.GetComponent<Female>().PlayError();
                                    female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                }
                            }
                            break;

                        case 2:
                            if (user == 2)
                            {
                                if (objTypeSound == 1)
                                {
                                    male.GetComponent<Male>().PlaySquare();
                                    male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                                }
                                else if (objTypeSound == 2)
                                {
                                    male.GetComponent<Male>().PlayCircle();
                                    male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                                }
                                else if (objTypeSound == 3)
                                {
                                    male.GetComponent<Male>().PlayTriangle();
                                    male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                                }
                                else if (objTypeSound == 4)
                                {
                                    male.GetComponent<Male>().PlaySelected(lastObj, selecionados, totais);
                                    male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                }
                                else if (objTypeSound == 6)
                                {
                                    print("Não podes selecionar isso!");
                                    male.GetComponent<Male>().PlayError();
                                    male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
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
                    GUI.Label(new Rect(0, 15, 200, 100), "Feedback " + feedbackType);
                    print("Task-Dependent");
                    switch (userID)
                    {
                        case 1:
                            if (user == 1)
                            {
                                if (objTypeSound == 1)
                                {
                                    female.GetComponent<Female>().PlaySquare();
                                    female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                                }
                                else if (objTypeSound == 2)
                                {
                                    female.GetComponent<Female>().PlayCircle();
                                    female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                                }
                                else if (objTypeSound == 3)
                                {
                                    female.GetComponent<Female>().PlayTriangle();
                                    female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                                }
                                else if (objTypeSound == 4)
                                {
                                    female.GetComponent<Female>().PlaySelected(lastObj, selecionados, totais);
                                    female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                }
                                else if (objTypeSound == 6)
                                {
                                    print("Não podes selecionar isso!");
                                    female.GetComponent<Female>().PlayError();
                                    female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                }
                            }
                            else if (user == 2)
                            {
                                if (objTypeSound == 2)
                                {
                                    female.GetComponent<Female>().PlayCircle();
                                    female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                                }
                                // Deve ouvir os Selected e erros do outro?
                                /*else if (objTypeSound == 4)
                                {
                                    female.GetComponent<Female>().PlaySelected(lastObj, selecionados, totais);
                                    female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                }
                                else if (objTypeSound == 6)
                                {
                                    print("Não podes selecionar isso!");
                                    female.GetComponent<Female>().PlayError();
                                    female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                }*/

                            }
                            break;

                        case 2:
                            if (user == 1)
                            {
                                if (objTypeSound == 1)
                                {
                                    male.GetComponent<Male>().PlaySquare();
                                    male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                }

                                // Deve ouvir os Selected do outro?
                                /*else if (objTypeSound == 4)
                                {
                                    male.GetComponent<Male>().PlaySelected(lastObj, selecionados, totais);
                                    male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                }
                                else if (objTypeSound == 6)
                                {
                                    print("Não podes selecionar isso!");
                                    male.GetComponent<Male>().PlayError();
                                    male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                }*/
                            }
                            else if (user == 2)
                            {
                                if (objTypeSound == 1)
                                {
                                    male.GetComponent<Male>().PlaySquare();
                                    male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                                }
                                else if (objTypeSound == 2)
                                {
                                    male.GetComponent<Male>().PlayCircle();
                                    male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                                }
                                else if (objTypeSound == 3)
                                {
                                    male.GetComponent<Male>().PlayTriangle();
                                    male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                                }
                                else if (objTypeSound == 4)
                                {
                                    male.GetComponent<Male>().PlaySelected(lastObj, selecionados, totais);
                                    male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                }
                                else if (objTypeSound == 6)
                                {
                                    print("Não podes selecionar isso!");
                                    male.GetComponent<Male>().PlayError();
                                    male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
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
                    GUI.Label(new Rect(0, 15, 200, 100), "Feedback " + feedbackType);
                    print("Private");
                    switch (userID)
                    {
                        case 1:
                            if (objTypeSound == 1)
                            {
                                female.GetComponent<Female>().PlaySquare();
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objTypeSound == 2)
                            {
                                female.GetComponent<Female>().PlayCircle();
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objTypeSound == 3)
                            {
                                female.GetComponent<Female>().PlayTriangle();
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objTypeSound == 4)
                            {
                                female.GetComponent<Female>().PlaySelected(lastObj, selecionados, totais);
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                            }
                            else if (objTypeSound == 6)
                            {
                                print("Não podes selecionar isso!");
                                female.GetComponent<Female>().PlayError();
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                            }
                            break;

                        case 2:
                            if (objTypeSound == 1)
                            {
                                male.GetComponent<Male>().PlaySquare();
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objTypeSound == 2)
                            {
                                male.GetComponent<Male>().PlayCircle();
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objTypeSound == 3)
                            {
                                male.GetComponent<Male>().PlayTriangle();
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objTypeSound == 4)
                            {
                                male.GetComponent<Male>().PlaySelected(lastObj, selecionados, totais);
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                            }
                            else if (objTypeSound == 6)
                            {
                                print("Não podes selecionar isso!");
                                male.GetComponent<Male>().PlayError();
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                            }
                            break;
                        default:
                            print("You have no user defined!");
                            break;
                    }
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
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), "User " + user);
    }
}