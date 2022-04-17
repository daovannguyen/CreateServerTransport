using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoSingleton<NetworkManager>
{
    public Server server;
    public Client client;

    [HideInInspector]
    public int InternalId;
    [HideInInspector]
    public bool IsServer = false;

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
        IsServer = false;
    }

}
