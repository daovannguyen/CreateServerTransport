using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoSingleton<NetworkManager>
{
    public Server server;
    public Client client;

    [HideInInspector]
    public bool IsServer = false;
    [HideInInspector]
    public bool IsHost = false;

    // du lieu tren server





    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void SetPropertyServer()
    {
        IsServer = true;
    }
    public void SetPropertyClient()
    {
    }
    public void SetPropertyHost()
    {
        IsHost = true;
    }

}
