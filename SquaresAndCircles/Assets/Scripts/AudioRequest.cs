using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class AudioRequest : MonoBehaviour
{
    public int Port;
    public Transform User1;
    public Transform User2;

    public GameObject GO;
    public Logs log;
    public string ft; //feedback type


    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.S))
            PlayRemoteAudio();*/

    }

    // args: userID, numSom, posSom

    public void FeedbackType(int feedback)
    {
        string message = "FeedbackType:" + feedback;
        // Envia!
        UDPBroadcast(message);
    }

    public void StopRemoteAudio(int userID)
    {
        string message = "Stop:" + userID;

        // Envia!
        UDPBroadcast(message);
    }

    public void PlayRemoteAudio(int userID, int numSom, int objType, Vector3 posSom, int selecao, int totais)
    {
        // Compoe Mensagem
        Vector3 relativePos1 = User1.worldToLocalMatrix.MultiplyPoint(posSom);
        Vector3 relativePos2 = User2.worldToLocalMatrix.MultiplyPoint(posSom);

        GO.transform.parent = User1;
        GO.transform.localPosition = relativePos1;
        //GO.transform.parent = null;

        string message = "Play:" + userID + ":" + numSom + ":" + objType + ":"
            + (int)(relativePos1.x * 1000) + ":" + (int)(relativePos1.y * 1000) + ":" + (int)(relativePos1.z * 1000) + ":"
            + (int)(relativePos2.x * 1000) + ":" + (int)(relativePos2.y * 1000) + ":" + (int)(relativePos2.z * 1000) + ":" + selecao + ":" + totais;

        // Envia!
        UDPBroadcast(message);
    }

    private void UDPBroadcast(string message)
    {
        UdpClient udp = new UdpClient();
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Broadcast, Port);
        byte[] data = Encoding.UTF8.GetBytes(message);
        udp.Send(data, data.Length, remoteEndPoint);

        print("Enviou a mensagem: " + message);
    }
}

