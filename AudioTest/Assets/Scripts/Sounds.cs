using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Sounds : MonoBehaviour
{
    private AudioSource myAudioSource;
    public AudioClip
        F1_quadrado, F1_circulo, F1_triangulo,
        M1_quadrado, M1_circulo, M1_triangulo,
        M2_quadrado, M2_circulo, M2_triangulo,
        ding, selected, exitObj;

    public UDPListener udpConnection;
    public int port;
    public bool tocaQuadradoF = false;
    public bool tocaQuadradoM= false;
    public bool tocaCirculoF = false;
    public bool tocaCirculoM = false;
    public bool tocaTrianguloF = false;
    public bool tocaTrianguloM = false;
    public bool tocaSelected = false;
    public bool tocaExit = false;


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
        ChooseSound();
    }

    void ChooseSound()
    {
        print("Estou no Choose Sound");
        if (tocaQuadradoF)
        {
            myAudioSource.PlayOneShot(F1_quadrado);
            print("Tocou quadrado F. ");
            tocaQuadradoF = false;
        }
        if (tocaCirculoF)
        {
            myAudioSource.PlayOneShot(F1_circulo);
            tocaCirculoF = false;
        }
        if (tocaTrianguloF)
        {
            myAudioSource.PlayOneShot(F1_triangulo);
            tocaTrianguloF = false;
        }
        if (tocaQuadradoM)
        {
            myAudioSource.PlayOneShot(M2_quadrado);
            print("Tocou quadrado M. ");
            tocaQuadradoM = false;
        }
        if (tocaCirculoM)
        {
            myAudioSource.PlayOneShot(M2_circulo);
            tocaCirculoM = false;
        }
        if (tocaTrianguloM)
        {
            myAudioSource.PlayOneShot(M2_triangulo);
            tocaTrianguloM = false;
        }
        if (tocaSelected)
        {
            myAudioSource.PlayOneShot(selected);
            tocaSelected = false;
        }
        if (tocaExit)
        {
            myAudioSource.PlayOneShot(exitObj);
            tocaExit = false;
        }        
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

            print("Vou escolher o Som e sou o user: " + userID);

            switch (objType) {
                case 1:
                    if(userID == 1)
                    {
                        tocaQuadradoF = true;
                    }
                    else if(userID == 2)
                    {
                        tocaQuadradoM = true;
                    }
                    break;
                case 2:
                    if (userID == 1)
                    {
                        tocaCirculoF = true;
                    }
                    else if (userID == 2)
                    {
                        tocaCirculoM = true;
                    }
                    break;
                case 3:
                    if (userID == 1)
                    {
                        tocaTrianguloF = true;
                    }
                    else if (userID == 2)
                    {
                        tocaTrianguloM = true;
                    }
                    break;
                case 4:
                    tocaSelected = true;
                    break;
                case 5:
                    tocaExit = true;
                    break;
                default:
                    print("You have no object type defined!");
                    break;
            }
            //print("UserID: " + userID + " NumSom: " + numSom + " ObjType: " + objType);        
            print(tocaQuadradoF + " " +  tocaCirculoF + " " +  tocaTrianguloF + " " + tocaSelected + " " + tocaExit + " "  + "BOYS: " + tocaQuadradoM + " " + tocaCirculoM + " " + tocaTrianguloM);
        }
        else if (ourStrings[0] == "Stop")
        {
            int userID = int.Parse(ourStrings[1]);
        }
    }
}

