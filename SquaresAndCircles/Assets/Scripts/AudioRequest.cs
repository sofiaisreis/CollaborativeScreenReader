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

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.S))
            PlayRemoteAudio();*/
    }

    // args: userID, numSom, posSom

    public void StopRemoteAudio(int userID)
    {
        string message = "Stop:" + userID;

        // Envia!
        UDPBroadcast(message);
    }

    public void PlayRemoteAudio(int userID, int numSom, Vector3 posSom)
    {
        // Compoe Mensagem
        Vector3 relativePos1 = User1.worldToLocalMatrix.MultiplyPoint(posSom);
        Vector3 relativePos2 = User2.worldToLocalMatrix.MultiplyPoint(posSom);

        string message = "Play:" + userID + ":" + numSom + ":"
            + relativePos1.x + ":" + relativePos1.y + ":" + relativePos1.z + ":"
            + relativePos2.x + ":" + relativePos2.y + ":" + relativePos2.z;

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

