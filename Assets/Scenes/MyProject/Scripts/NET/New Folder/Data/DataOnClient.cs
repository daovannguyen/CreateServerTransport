using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo
{

}

public class DataOnClient : MonoSingleton<DataOnClient>
{
    public int InternalId;
    public RoomInstance room = new RoomInstance();

    // objects
    public List<GameObject> PlayerPrefabs;
    public List<GameObject> PlayerGameObjects;

    public List<GameObject> SpawnPrefabs;
    public List<GameObject> SpawnGameObjects;







    private void Awake()
    {
        DontDestroyOnLoad(this);
        //PlayerPrefabs = new List<GameObject>();
        PlayerGameObjects = new List<GameObject>();
        SpawnGameObjects = new List<GameObject>();
    }
}
