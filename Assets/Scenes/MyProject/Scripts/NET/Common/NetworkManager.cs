using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoSingleton<NetworkManager>
{
    public int InternalId;
    public int indexPlayerPrefab;
    public Server server;
    public Client client;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

}
