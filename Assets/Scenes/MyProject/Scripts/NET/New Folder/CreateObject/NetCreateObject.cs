using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class NetCreateObject : NetMessage
{
    // cái này máy chủ quản lý;
    public NetCreateObject()
    {
        Code = OpCode.CREATEOBJECT;
    }
    public NetCreateObject(DataStreamReader reader)
    {
        Code = OpCode.CREATEOBJECT;
        Deserialize(reader);
    }
    public override void ReceivedOnClient()
    {
        NetUtility.C_CREATEOBJECT?.Invoke(this);
    }
    public override void ReceivedOnServer(NetworkConnection cnn)
    {
        NetUtility.S_CREATEOBJECT?.Invoke(this, cnn);
    }

}
