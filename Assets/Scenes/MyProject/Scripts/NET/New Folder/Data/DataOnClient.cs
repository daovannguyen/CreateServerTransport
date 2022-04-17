using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataOnClient : MonoSingleton<DataOnClient>
{
    public int InternalId;
    public RoomInstance rooms = new RoomInstance();
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
