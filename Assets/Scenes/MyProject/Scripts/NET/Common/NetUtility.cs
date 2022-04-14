using UnityEngine;
using System;
using Unity.Networking.Transport;

public enum OpCode
{
    NULL,
    KEEP_ALIVE,
    WELCOME,
    JOINROOM,



}
public static class NetUtility
{
    //Net messages

    public static void OnData(DataStreamReader stream, NetworkConnection cnn, Server server = null )
    {
        NetMessage msg = null;
        var opCode = (OpCode)stream.ReadByte();
        switch(opCode)
        {
            //case OpCode.KEEP_ALIVE: msg = new NetKeepAlive(stream); break;
            case OpCode.WELCOME: msg = new NetWelcome(stream); break;
            case OpCode.JOINROOM: msg = new NetJoinRoom(stream); break;

            default:
                Debug.LogError("Message received had no OpCode");
                break;
        }
        if (server != null)
        {
            msg.ReceivedOnServer(cnn);
        }
        else
            msg.ReceivedOnClient();
    }



    // hình như đay là ở máy client
    public static Action<NetMessage> C_KEEP_ALIVE;
    public static Action<NetMessage> C_WELCOME;
    public static Action<NetMessage> C_JOINROOM;

    // đây ở máy server
    public static Action<NetMessage, NetworkConnection> S_KEEP_ALIVE;
    public static Action<NetMessage, NetworkConnection> S_WELCOME;
    public static Action<NetMessage, NetworkConnection> S_JOINROOM;

}
