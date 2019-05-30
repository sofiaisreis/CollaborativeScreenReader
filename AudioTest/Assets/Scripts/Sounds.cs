using UnityEngine;
using System;


/* APLICACAO PC ZENNIE */
public class Sounds : MonoBehaviour
{
    public GameObject female;
    public GameObject male;
    public UDPListener udpConnection;
    public int port;
    public string obj;


    // Start is called before the first frame update
    void Start()
    {
        udpConnection = new UDPListener();
    }

    void Update()
    {
    }
    
    internal void ParseAndPlay(string stringToParse)
    {
        print("Entrei no parse");

        print("string_ " + stringToParse);
        string[] ourStrings = stringToParse.Split(':');
        if (ourStrings[0] == "Play")
        {
            // string message = "Play:" + 
            // userID + ":" + numSom + ":" + objType + ":" + relativePos1 + ":" + relativePos2;

            int userID = int.Parse(ourStrings[1]);
            int numSom = int.Parse(ourStrings[2]);
            int objType = int.Parse(ourStrings[3]);
            Vector3 relativePos1 = new Vector3(float.Parse(ourStrings[4]) / 1000.0f, float.Parse(ourStrings[5]) / 1000.0f, float.Parse(ourStrings[6]) / 1000.0f);
            Vector3 relativePos2 = new Vector3(float.Parse(ourStrings[7]) / 1000.0f, float.Parse(ourStrings[8]) / 1000.0f, float.Parse(ourStrings[9]) / 1000.0f);

            transform.position = relativePos1;

            print("Vou escolher o Som e sou o user: " + userID);
            
            switch (userID)
            {
                case 1:
                    if (objType == 1)
                    {
                        obj = "quadrado";
                        female.GetComponent<Female>().PlaySquare();

                    }
                    else if (objType == 2)
                    {
                        obj = "circulo";
                        female.GetComponent<Female>().PlayCircle();

                    }
                    else if (objType == 3)
                    {
                        obj = "triangulo";
                        female.GetComponent<Female>().PlayTriangle();

                    }
                    else if (objType == 4)
                    {
                        female.GetComponent<Female>().PlaySelectedF();
                    }
                    else if (objType == 5)
                    {
                        female.GetComponent<Female>().PlayExitF();
                    }
                    break;

                case 2:
                    if (objType == 1)
                    {
                        obj = "quadrado";
                        male.GetComponent<Male>().PlaySquare();

                    }
                    else if (objType == 2)
                    {
                        obj = "circulo";
                        male.GetComponent<Male>().PlayCircle();

                    }
                    else if (objType == 3)
                    {
                        obj = "triangulo";
                        male.GetComponent<Male>().PlayTriangle();

                    }
                    else if (objType == 4)
                    {
                        male.GetComponent<Male>().PlaySelectedM();
                    }
                    else if (objType == 5)
                    {
                        male.GetComponent<Male>().PlayExitM();
                    }
                    break;
                default:
                    print("You have no user defined!");
                    break;
            }
            if (objType == 1 || objType == 2 || objType == 3) {
                print("User: " + userID + " tocou num: " + obj + ".");
            }
            else if (objType == 4)
            {
                print("User: " + userID + " selecionou objeto!");
            }
        }
        else if (ourStrings[0] == "Stop")
        {
            print("TOU STOPPES");
            int userID = int.Parse(ourStrings[1]);
        }
    }

}