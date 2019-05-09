using UnityEngine;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;

public class UDPListener : MonoBehaviour
{

    public static string NoneMessage = "0";
    public int Port;
    public IPEndPoint _anyIP;
    public UdpClient _udpClient = null;
    public List<string> _stringsToParse;

    void Start()
    {
        udpRestart();
    }

    public void udpRestart()
    {
        if (_udpClient != null)
        {
            _udpClient.Close();
        }

        _stringsToParse = new List<string>();
        _anyIP = new IPEndPoint(IPAddress.Any, Port);
        _udpClient = new UdpClient(_anyIP);
        _udpClient.BeginReceive(new AsyncCallback(this.ReceiveCallback), null);
        //gameObject.GetComponent<Sounds>().ChooseSound();
        Debug.Log("[UDPListener] Receiving in port: " + Port);
    }

    
    public void ReceiveCallback(IAsyncResult ar)
    {
        Byte[] receiveBytes = _udpClient.EndReceive(ar, ref _anyIP);
        _stringsToParse.Add(Encoding.UTF8.GetString(receiveBytes));
        _udpClient.BeginReceive(new AsyncCallback(this.ReceiveCallback), null);
    }

    void Update()
    {
        while (_stringsToParse.Count > 0)
        {
            string stringToParse = _stringsToParse.First();
            _stringsToParse.RemoveAt(0);
            
            if (stringToParse.Length != 1)
            {
                GetComponent<Sounds>().ParseAndPlay(stringToParse);
            }
        }
    }

    void OnApplicationQuit()
    {
        if (_udpClient != null) _udpClient.Close();
    }

    void OnQuit()
    {
        OnApplicationQuit();
    }
}