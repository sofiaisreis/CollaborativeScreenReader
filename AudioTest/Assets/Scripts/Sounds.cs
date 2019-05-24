using UnityEngine;
using System;


/* APLICACAO PC ZENNIE */

[RequireComponent(typeof(AudioSource))]
public class Sounds : MonoBehaviour
{
    private AudioSource myAudioSource;
    public AudioClip
        F1_quadrado, F1_circulo, F1_triangulo,
        M1_quadrado, M1_circulo, M1_triangulo,
        M2_quadrado, M2_circulo, M2_triangulo,
        ding, selected, exitObj, F1_test;

    public UDPListener udpConnection;
    public int port;
    public string obj;


    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        udpConnection = new UDPListener();
    }

    void Update()
    {
    }
    
    internal void ParseAndPlay(string stringToParse)
    {


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
                        myAudioSource.PlayOneShot(F1_quadrado);

                    }
                    else if (objType == 2)
                    {
                        obj = "circulo";
                        myAudioSource.PlayOneShot(F1_circulo);

                    }
                    else if (objType == 3)
                    {
                        obj = "triangulo";
                        myAudioSource.PlayOneShot(F1_triangulo);

                    }
                    else if (objType == 4)
                    {
                        myAudioSource.PlayOneShot(selected);
                    }
                    else if (objType == 5)
                    {
                        myAudioSource.PlayOneShot(exitObj);
                    }
                    break;

                case 2:                    
                    if (objType == 1)
                    {
                        obj = "quadrado";
                        myAudioSource.PlayOneShot(M2_quadrado);

                    }
                    else if (objType == 2)
                    {
                        obj = "circulo";
                        myAudioSource.PlayOneShot(M2_circulo);

                    }
                    else if (objType == 3)
                    {
                        obj = "triangulo";
                        myAudioSource.PlayOneShot(M2_triangulo);

                    }
                    else if (objType == 4)
                    {
                        myAudioSource.PlayOneShot(selected);
                    }
                    else if (objType == 5)
                    {
                        myAudioSource.PlayOneShot(exitObj);
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