using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class L_Welcome : RegisterEvent
{
    private class CreateIdPlayerMessage{
        public int Id;
        public CreateIdPlayerMessage()
        {
            Id = -1;
        }
        public CreateIdPlayerMessage(int _id)
        {
            Id = _id;
        }
    }
    // quy định biến viết hoa hết là dành cho máy chủ
    private int PlayerCount = -1;

    #region CreateMessageToClient + Server
    void CreateMessageToClient()
    {
    }
    void CreateMessageToServer()
    {

    }
    #endregion
    #region REGISTEEVENT
    private void OnEnable()
    {
        RegisterEvents(ref NetUtility.S_WELCOME, ref NetUtility.C_WELCOME);
    }
    private void OnDisable()
    {
        UnRegisterEvents(ref NetUtility.S_WELCOME, ref NetUtility.C_WELCOME);
    }
    #endregion
    #region OnEventClient + Server
    public override void OnEventClient(NetMessage msg)
    {
        CreateIdPlayerMessage pi = JsonUtility.FromJson<CreateIdPlayerMessage>((msg as NetWelcome).ContentBox);
        DataOnClient.Instance.InternalId = pi.Id;
    }
    public override void OnEventServer(NetMessage msg, NetworkConnection cnn)
    {
        NetWelcome nw = msg as NetWelcome;
        PlayerCount++;
        CreateIdPlayerMessage pi = new CreateIdPlayerMessage(PlayerCount);
        nw.ContentBox = JsonUtility.ToJson(pi);
        Server.Instance.SendToClient(cnn, nw);
    }
    #endregion
}
