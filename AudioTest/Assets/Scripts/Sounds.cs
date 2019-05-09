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

    public void ChooseSound()
    {
        print("imprimo");
    }

    // Sounds
    void PlayFemale()
    {
        myAudioSource.PlayOneShot(F1_quadrado);
    }

    void PlayMale()
    {
        myAudioSource.PlayOneShot(F1_quadrado);
    }

    internal void ParseAndPlay(string stringToParse)
    {
        print("string_ " + stringToParse);
        string[] ourStrings = stringToParse.Split(':');
        if (ourStrings[0] == "Play")
        {
            // string message = "Play:" + 
            // userID + ":" + numSom + ":" + relativePos1 + ":" + relativePos2;

            int userID = int.Parse(ourStrings[1]);
            int numSom = int.Parse(ourStrings[2]);
            Vector3 relativePos1 = new Vector3(float.Parse(ourStrings[3]), float.Parse(ourStrings[4]), float.Parse(ourStrings[5]));
            Vector3 relativePos2 = new Vector3(float.Parse(ourStrings[6]), float.Parse(ourStrings[7]), float.Parse(ourStrings[8]));

            transform.position = relativePos1;
            PlayFemale();
        }
        else if (ourStrings[0] == "Stop")
        {
            int userID = int.Parse(ourStrings[1]);
        }
    }
}

