using UnityEngine;
using System;


/* APLICACAO PC ZENNIE */
public class Sounds : MonoBehaviour
{
    public GameObject female;
    public GameObject male;
    public UDPListener udpConnection;
    public string feedbackType = null;
    public int port;
    public int user;

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
        if (Input.GetKeyDown(KeyCode.Z))
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
        }
    }

    internal void ParseAndPlay(string stringToParse)
    {
        print("string_ " + stringToParse);
        string[] ourStrings = stringToParse.Split(':');

        // PLAY SOUNDS
        if (ourStrings[0] == "Play")
        {
            // string message = "Play:" + 
            // userID + ":" + numSom + ":" + objType + ":" + relativePos1 + ":" + relativePos2;

            int userID = int.Parse(ourStrings[1]);
            int numSom = int.Parse(ourStrings[2]);
            int objType = int.Parse(ourStrings[3]);
            Vector3 relativePos1 = new Vector3(float.Parse(ourStrings[4]) / 1000.0f * 2.0f, float.Parse(ourStrings[5]) / 1000.0f * 2.0f, float.Parse(ourStrings[6]) / 1000.0f * 2.0f);
            Vector3 relativePos2 = new Vector3(float.Parse(ourStrings[7]) / 1000.0f * 2.0f, float.Parse(ourStrings[8]) / 1000.0f * 2.0f, float.Parse(ourStrings[9]) / 1000.0f * 2.0f);



            /*********** Feedback Private **********/
            if (feedbackType == "Private")
            {
                switch (userID)
                {
                    case 1:
                        if (user == 1)
                        {
                            if (objType == 1)
                            {
                                female.GetComponent<Female>().PlaySquare();
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objType == 2)
                            {
                                female.GetComponent<Female>().PlayCircle();
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objType == 3)
                            {
                                female.GetComponent<Female>().PlayTriangle();
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objType == 4)
                            {
                                female.GetComponent<Female>().PlaySelected();
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                            }
                            //else if () {female.GetComponent<Female>().PlayError(); }
                        }
                        break;
                        
                    case 2:
                        if (user == 2)
                        {
                            if (objType == 1)
                            {
                                male.GetComponent<Male>().PlaySquare();
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objType == 2)
                            {
                                male.GetComponent<Male>().PlayCircle();
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objType == 3)
                            {
                                male.GetComponent<Male>().PlayTriangle();
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objType == 4)
                            {
                                male.GetComponent<Male>().PlaySelected();
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                //else if () {male.GetComponent<Male>().PlayError(); }
                            }
                        }
                        break;
                    default:
                        print("You have no user defined!");
                        break;
                }
            }

            /*********** Feedback Task-Dependent **********/
            if (feedbackType == "Task-Dependent")
            {
                switch (userID)
                {
                    case 1:
                        if (user == 1)
                        {
                            if (objType == 1)
                            {
                                female.GetComponent<Female>().PlaySquare();
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objType == 2)
                            {
                                female.GetComponent<Female>().PlayCircle();
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objType == 3)
                            {
                                female.GetComponent<Female>().PlayTriangle();
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objType == 4)
                            {
                                female.GetComponent<Female>().PlaySelected();
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                            }
                            //else if () {female.GetComponent<Female>().PlayError(); }
                        }
                        else if (user == 2)
                        {
                            if (objType == 2)
                            {
                                female.GetComponent<Female>().PlayCircle();
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }

                            // Deve ouvir os Selected do outro?
                            else if (objType == 4)
                            {
                                female.GetComponent<Female>().PlaySelected();
                                female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                //else if () {male.GetComponent<Male>().PlayError(); }
                            }
                        }
                        break;

                    case 2:
                        if (user == 1)
                        {
                            if (objType == 1)
                            {
                                male.GetComponent<Male>().PlaySquare();
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                            }

                            // Deve ouvir os Selected do outro?
                            else if (objType == 4)
                            {
                                male.GetComponent<Male>().PlaySelected();
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                //else if () {male.GetComponent<Male>().PlayError(); }
                            }
                        }
                        else if (user == 2)
                        {
                            if (objType == 1)
                            {
                                male.GetComponent<Male>().PlaySquare();
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objType == 2)
                            {
                                male.GetComponent<Male>().PlayCircle();
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objType == 3)
                            {
                                male.GetComponent<Male>().PlayTriangle();
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                            }
                            else if (objType == 4)
                            {
                                male.GetComponent<Male>().PlaySelected();
                                male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                                //else if () {male.GetComponent<Male>().PlayError(); }
                            }
                        }
                        break;
                    default:
                        print("You have no user defined!");
                        break;
                }
            }
        

            /*********** Feedback Public **********/
            if (feedbackType == "Public")
            {
                switch (userID)
                {
                    case 1:
                        if (objType == 1)
                        {
                            female.GetComponent<Female>().PlaySquare();
                            female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                        }
                        else if (objType == 2)
                        {
                            female.GetComponent<Female>().PlayCircle();
                            female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                        }
                        else if (objType == 3)
                        {
                            female.GetComponent<Female>().PlayTriangle();
                            female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                        }
                        else if (objType == 4)
                        {
                            female.GetComponent<Female>().PlaySelected();
                            female.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                        }
                        //else if () {female.GetComponent<Female>().PlayError(); }
                        break;

                    case 2:
                        if (objType == 1)
                        {
                            male.GetComponent<Male>().PlaySquare();
                            male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                        }
                        else if (objType == 2)
                        {
                            male.GetComponent<Male>().PlayCircle();
                            male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                        }
                        else if (objType == 3)
                        {
                            male.GetComponent<Male>().PlayTriangle();
                            male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;

                        }
                        else if (objType == 4)
                        {
                            male.GetComponent<Male>().PlaySelected();
                            male.transform.position = user == 1 ? relativePos1 : user == 2 ? relativePos2 : Vector3.zero;
                            //else if () {male.GetComponent<Male>().PlayError(); }
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

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), "User " + user);
        GUI.Label(new Rect(0, 15, 200, 100), "Feedback " + feedbackType);
    }
}