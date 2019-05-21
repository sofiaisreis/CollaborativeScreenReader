using UnityEngine;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;

[RequireComponent(typeof(AudioSource))]
public class Sounds : MonoBehaviour
{
    public AudioSource myAudioSource;
    public AudioClip 
        F1_quadrado, F1_circulo, F1_triangulo,
        M1_quadrado, M1_circulo, M1_triangulo,
        M2_quadrado, M2_circulo, M2_triangulo,
        ding, selected, exitObj;

    public UDPListener udpConnection;
    public int port;


    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        udpConnection = new UDPListener();
        //udpConnection.GetComponent<UDPListener>().Port = port;
        //udpConnection.GetComponent<UDPListener>().udpRestart();
        
    }

    void Update()
    {

    }

    public void ChooseSound(int user, int soundNum, int objType)
    {
        print("Vou escolher o Som: ");
        switch (objType)
        {
            case 1: //quadrado
                //if user eh o 1 userID = 1 Feminino
                if (user == -1)
                {
                    myAudioSource.PlayOneShot(F1_quadrado);
                }
                else
                {
                    myAudioSource.PlayOneShot(M2_quadrado);
                }
                break;

            case 2: //circulo
                //if user eh o 1 userID = 1 Feminino
                if (user == -1)
                {
                    myAudioSource.PlayOneShot(F1_circulo);
                }
                else
                {
                    myAudioSource.PlayOneShot(M2_circulo);
                }
                break;

            case 3: //triangulo
                //if user eh o 1 userID = 1 Feminino
                if (user == -1)
                {
                    myAudioSource.PlayOneShot(F1_triangulo);
                }
                else
                {
                    myAudioSource.PlayOneShot(M2_triangulo);
                }
                break;

            case 4: //select
                myAudioSource.PlayOneShot(selected);
                break;

            case 5: //onExit
                myAudioSource.PlayOneShot(exitObj);
                break;

            default:
                print("You have no object type defined!");
                break;
        }

    }


    // Sounds

    void PlayFemale()
    {
        
        print("playing female");
    }

    void PlayMale()
    {
        myAudioSource.PlayOneShot(M2_quadrado);
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
            Vector3 relativePos1 = new Vector3(float.Parse(ourStrings[4]), float.Parse(ourStrings[5]), float.Parse(ourStrings[6]));
            Vector3 relativePos2 = new Vector3(float.Parse(ourStrings[7]), float.Parse(ourStrings[8]), float.Parse(ourStrings[9]));

            transform.position = relativePos1;
            ChooseSound(userID, numSom, objType);
        }
        else if (ourStrings[0] == "Stop")
        {
            int userID = int.Parse(ourStrings[1]);
        }
    }
}

