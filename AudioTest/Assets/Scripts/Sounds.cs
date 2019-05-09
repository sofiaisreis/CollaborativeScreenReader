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
    
}

