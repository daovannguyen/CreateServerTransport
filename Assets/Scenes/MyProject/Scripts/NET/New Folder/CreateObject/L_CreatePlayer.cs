using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class L_CreatePlayer : RegisterEvent
{
    // quy định biến viết hoa hết là dành cho máy chủ

    private void Awake()
    {
        int indexPrefab = Random.Range(0, 2);
        Vector3 randomPosition = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
        CreateMessageToServer(ObjectType.PLAYER, indexPrefab, randomPosition);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int indexPrefab = Random.Range(0, 3);
            Vector3 randomPosition = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
            CreateMessageToServer(ObjectType.NORMAL, indexPrefab, randomPosition);
        }
    }

    #region REGISTEEVENT
    private void OnEnable()
    {
        RegisterEvents(ref NetUtility.S_CREATEPLAYER, ref NetUtility.C_CREATEPLAYER);
    }
    private void OnDisable()
    {
        UnRegisterEvents(ref NetUtility.S_CREATEPLAYER, ref NetUtility.C_CREATEPLAYER);
    }
    #endregion
    #region Server
    public void CreateMessageToClient(NetMessage msg, NetworkConnection cnn)
    {
        RoomInstance room = RoomInstance.FindRoomByPlayerId(cnn.InternalId, DataOnServer.Instance.rooms);
        NetCreatePlayer ncp = msg as NetCreatePlayer;
        ObjectInstance oi = JsonUtility.FromJson<ObjectInstance>(ncp.ContentBox);
        oi.Id = cnn.InternalId;
        ncp.ContentBox = JsonUtility.ToJson(oi);
        Server.Instance.BroadCatOnRoom(room, ncp);
    }
    public override void OnEventServer(NetMessage msg, NetworkConnection cnn)
    {
        CreateMessageToClient(msg, cnn);
    }
    #endregion

    #region Client
    // chỉ gửi kiểu object và chỉ số prefabs
    public void CreateMessageToServer(ObjectType type, int indexPrefabs, Vector3 position)
    {
        ObjectInstance oi = new ObjectInstance(type, 1, indexPrefabs, position, Vector3.zero);
        NetCreatePlayer ncp = new NetCreatePlayer();
        ncp.ContentBox = JsonUtility.ToJson(oi);
        Client.Instance.SendToServer(ncp);
    }
    public override void OnEventClient(NetMessage msg)
    {
        GameObject player;
        ObjectInstance oi = JsonUtility.FromJson<ObjectInstance>((msg as NetCreatePlayer).ContentBox);
        if (oi.Type == ObjectType.PLAYER)
        {
            player = Instantiate(DataOnClient.Instance.PlayerPrefabs[oi.IndexPrefab], oi.Position, Quaternion.identity);
        }    
        else //if(oi.Type == ObjectType.NORMAL)
        {
            player = Instantiate(DataOnClient.Instance.SpawnPrefabs[oi.IndexPrefab], oi.Position, Quaternion.identity);
        }

        player.AddComponent<ObjectId>();
        player.GetComponent<ObjectId>().Id = oi.Id;
    }

    #endregion
}
