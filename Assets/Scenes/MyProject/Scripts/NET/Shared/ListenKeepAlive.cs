using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class ListenKeepAlive : MonoBehaviour
{
    //public float keepAliveTickRate = 10f;
    //public float lastKeepAlive;
    //private void Awake()
    //{
    //    RegisterEvents();
    //}
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    KeepAlive();
    //}


    //private void KeepAlive()
    //{
    //    if (NetworkManager.Instance.IsServer)
    //    {
    //        if (Time.time - lastKeepAlive > keepAliveTickRate)
    //        {
    //            lastKeepAlive = Time.time;
    //            Server.Instance.BroadCat(new NetKeepAlive());
    //        }
    //    }
    //}

    //private void RegisterEvents()
    //{
    //    NetUtility.S_KEEP_ALIVE += OnKeepAliveServer;
    //    NetUtility.C_KEEP_ALIVE += OnKeepAliveClient;
    //}
    //private void UnRegisterEvents()
    //{
    //    NetUtility.S_KEEP_ALIVE -= OnKeepAliveServer;
    //    NetUtility.C_KEEP_ALIVE -= OnKeepAliveClient;
    //}

    //// server

    //private void OnKeepAliveClient(NetMessage msg)
    //{
    //    Client.Instance.SendToServer(msg);
    //}

    //private void OnKeepAliveServer(NetMessage msg, NetworkConnection cnn)
    //{
    //}

}
