using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _smg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server");
        Client.instance.myId = _myId; 

        ClientSend.WelcomeReceived();
    }
}
