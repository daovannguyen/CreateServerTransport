using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class SL_Welcome : RegisterEvent
{
    // mutil logic hữu ích cho cả máy chủ, máy khách
    private int playerCount = -1;
    private void OnEnable()
    {
        RegisterEventsServer(ref NetUtility.S_WELCOME);
    }
    private void OnDisable()
    {
        UnRegisterEventsServer(ref NetUtility.S_WELCOME);
    }

    public override void OnEventServer(NetMessage msg, NetworkConnection cnn)
    {
        NetWelcome nw = msg as NetWelcome; 
        playerCount ++;
         PlayerId pi = new PlayerId(playerCount);
        nw.ContentBox = JsonUtility.ToJson(pi);
        // return back to the client
        Server.Instance.SendToClient(cnn, nw);
    }

}
