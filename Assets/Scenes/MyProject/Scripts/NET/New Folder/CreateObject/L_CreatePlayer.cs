using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class L_CreatePlayer : RegisterEvent
{
    // quy định biến viết hoa hết là dành cho máy chủ

    private void Awake()
    {
        CreateMessageToServer(ObjectType.PLAYER, 0);
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
        oi.Position = new Vector3(Random.Range(0,10), 0, Random.Range(0, 10));
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
    public void CreateMessageToServer(ObjectType type, int indexPrefabs)
    {
        ObjectInstance oi = new ObjectInstance(type, 1, indexPrefabs, Vector3.zero, Vector3.zero);
        NetCreatePlayer ncp = new NetCreatePlayer();
        ncp.ContentBox = JsonUtility.ToJson(oi);
        Client.Instance.SendToServer(ncp);
    }
    public override void OnEventClient(NetMessage msg)
    {
        ObjectInstance oi = JsonUtility.FromJson<ObjectInstance>((msg as NetCreatePlayer).ContentBox);
        if (oi.Type == ObjectType.PLAYER)
        {
            GameObject player = Instantiate(DataOnClient.Instance.PlayerPrefabs[oi.IndexPrefab], oi.Position, Quaternion.identity);
            player.AddComponent<ObjectId>();
            player.GetComponent<ObjectId>().Id = oi.Id;
        }    
    }

    #endregion
}
