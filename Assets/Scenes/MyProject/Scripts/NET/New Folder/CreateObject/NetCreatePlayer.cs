using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class NetCreatePlayer : NetMessage
{
    // cái này máy chủ quản lý;
    public NetCreatePlayer()
    {
        Code = OpCode.CREATEPLAYER;
    }
    public NetCreatePlayer(DataStreamReader reader)
    {
        Code = OpCode.CREATEPLAYER;
        Deserialize(reader);
    }
    public override void ReceivedOnClient()
    {
        NetUtility.C_CREATEPLAYER?.Invoke(this);
    }
    public override void ReceivedOnServer(NetworkConnection cnn)
    {
        NetUtility.S_CREATEPLAYER?.Invoke(this, cnn);
    }

}
