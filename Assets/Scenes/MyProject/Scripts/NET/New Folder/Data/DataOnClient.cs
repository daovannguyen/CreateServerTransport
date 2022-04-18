using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataOnClient : MonoSingleton<DataOnClient>
{
    public int InternalId;
    public RoomInstance room = new RoomInstance();

    // objects
    public GameObject[] PlayerPrefabs;
    //[HideInInspector]
    public GameObject[] PlayerGameObjects;

    public GameObject[] SpawnPrefabs;
    [HideInInspector]
    public GameObject[] SpawnGameObjects;

    // index charactor selected

    #region IndexCharactor
    [HideInInspector]
    public int IndexCharactor;
    private void SetIndexCharactor(int obj)
    {
        IndexCharactor = obj;
    }
    #endregion

    private void OnEnable()
    {
        EventManager.CHARACTORSELECTED += SetIndexCharactor;
    }
    private void OnDisable()
    {
        EventManager.CHARACTORSELECTED -= SetIndexCharactor;
    }



    private void Awake()
    {
        DontDestroyOnLoad(this);
        //PlayerPrefabs = new List<GameObject>();
        PlayerGameObjects = new GameObject[100];
        SpawnGameObjects = new GameObject[100];
    }

    #region CreateObject
    public void SetPlayer(ObjectInstance om)
    {
        GameObject player = Instantiate(PlayerPrefabs[om.IndexPrefab], om.Position, Quaternion.identity);
        player.AddComponent<ObjectId>();
        player.GetComponent<ObjectId>().Id = om.Id;
        PlayerGameObjects[om.Id] = player;
    }

    public GameObject GetPlayerLocal()
    {
        return GetPlayerWithId(InternalId);
    }
    public GameObject GetPlayerWithId(int id)
    {
        return PlayerGameObjects[id];
    }

    public void SetSpawn(ObjectInstance om)
    {
        GameObject spawn = Instantiate(SpawnPrefabs[om.IndexPrefab], om.Position, Quaternion.identity);
        spawn.AddComponent<ObjectId>();
        spawn.GetComponent<ObjectId>().Id = om.Id;
        SpawnGameObjects[om.Id] = spawn;
    }
    public GameObject GetSpawnWithId(int id)
    {
        return SpawnGameObjects[id];
    }
    #endregion

}
