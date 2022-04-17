using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class L_KeepAlive : RegisterEvent
{
    public float KeepAliveTickRate = 10f;
    public float LastKeepAlive;

    private void Update()
    {
        KeepAlive();
    }
    private void KeepAlive()
    {
        if (NetworkManager.Instance.IsServer)
        {
            if (Time.time - LastKeepAlive > KeepAliveTickRate)
            {
                LastKeepAlive = Time.time;
                Server.Instance.BroadCat(new NetKeepAlive());
            }
        }
    }

    // quy định biến viết hoa hết là dành cho máy chủ

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
        RegisterEvents(ref NetUtility.S_KEEP_ALIVE, ref NetUtility.C_KEEP_ALIVE);
    }
    private void OnDisable()
    {
        UnRegisterEvents(ref NetUtility.S_KEEP_ALIVE, ref NetUtility.C_KEEP_ALIVE);
    }
    #endregion
    #region OnEventClient + Server
    public override void OnEventClient(NetMessage msg)
    {
        Client.Instance.SendToServer(msg);
    }
    public override void OnEventServer(NetMessage msg, NetworkConnection cnn)
    {
    }
    #endregion

}
