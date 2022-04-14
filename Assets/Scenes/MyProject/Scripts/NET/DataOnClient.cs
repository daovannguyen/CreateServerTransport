using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataOnClient : MonoSingleton<DataOnClient>
{
    public int InternalId;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
