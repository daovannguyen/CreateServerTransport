using Unity.Networking.Transport;
using UnityEngine;

public class NetChangeScene : NetMessage
{
    // cái này máy chủ quản lý;
    public NetChangeScene()
    {
        Code = OpCode.CHANGESCENE;
    }
    public NetChangeScene(DataStreamReader reader)
    {
        Code = OpCode.CHANGESCENE;
        Deserialize(reader);
    }
    public override void ReceivedOnClient()
    {
        NetUtility.C_CHANGESCENE?.Invoke(this);
    }
    public override void ReceivedOnServer(NetworkConnection cnn)
    {
        NetUtility.S_CHANGESCENE?.Invoke(this, cnn);
    }

}
