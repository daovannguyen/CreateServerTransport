using Unity.Networking.Transport;
using UnityEngine;

public class NetWelcome : NetMessage
{
    public NetWelcome()
    {
        Code = OpCode.WELCOME;
    }
    public NetWelcome(DataStreamReader reader)
    {
        Code = OpCode.WELCOME;
        Deserialize(reader);
    }
    public override void ReceivedOnClient()
    {
        NetUtility.C_WELCOME?.Invoke(this);
    }
    public override void ReceivedOnServer(NetworkConnection cnn)
    {
        NetUtility.S_WELCOME?.Invoke(this, cnn);
    }

}
