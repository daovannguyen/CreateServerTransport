using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class L_CreateObject : RegisterEvent
{
    // quy định biến viết hoa hết là dành cho máy chủ


    #region REGISTEEVENT
    private void OnEnable()
    {
        RegisterEvents(ref NetUtility.S_CREATEOBJECT, ref NetUtility.C_CREATEOBJECT);
    }
    private void OnDisable()
    {
        UnRegisterEvents(ref NetUtility.S_CREATEOBJECT, ref NetUtility.C_CREATEOBJECT);
    }
    #endregion
    #region Server
    public void CreateMessageToClientCreatePlayer(NetMessage msg, NetworkConnection cnn)
    {
        NetCreateObject ncp = msg as NetCreateObject;
        ObjectInstance oi = JsonUtility.FromJson<ObjectInstance>(ncp.ContentBox);
        oi.Id = cnn.InternalId;
        ncp.ContentBox = JsonUtility.ToJson(oi);
        Server.Instance.BroadCatOnRoom(cnn, ncp);
    }
    public void CreateMessageToClientCreateSpawn(NetMessage msg, NetworkConnection cnn)
    {
        NetCreateObject ncp = msg as NetCreateObject;
        ObjectInstance oi = JsonUtility.FromJson<ObjectInstance>(ncp.ContentBox);
        DataOnServer.Instance.SpawnCount++;
        oi.Id = DataOnServer.Instance.SpawnCount;
        ncp.ContentBox = JsonUtility.ToJson(oi);
        Server.Instance.BroadCatOnRoom(cnn, ncp);
    }
    public override void OnEventServer(NetMessage msg, NetworkConnection cnn)
    {
        ObjectInstance oi = JsonUtility.FromJson<ObjectInstance>((msg as NetCreateObject).ContentBox);
        if (oi.Type == ObjectType.PLAYER)
        {
            CreateMessageToClientCreatePlayer(msg, cnn);
        }
        else //if(oi.Type == ObjectType.NORMAL)
        {
            CreateMessageToClientCreateSpawn(msg, cnn);
        }
    }
    #endregion

    #region Client
    // chỉ gửi kiểu object và chỉ số prefabs
    public void CreateMessageToServer(ObjectType type, int indexPrefabs, Vector3 position)
    {
        ObjectInstance oi = new ObjectInstance(type, 1, indexPrefabs, position, Vector3.zero);
        NetCreateObject ncp = new NetCreateObject();
        ncp.ContentBox = JsonUtility.ToJson(oi);
        Client.Instance.SendToServer(ncp);
    }
    public override void OnEventClient(NetMessage msg)
    {
        ObjectInstance oi = JsonUtility.FromJson<ObjectInstance>((msg as NetCreateObject).ContentBox);
        if (oi.Type == ObjectType.PLAYER)
        {
            DataOnClient.Instance.SetPlayer(oi);
        }    
        else //if(oi.Type == ObjectType.NORMAL)
        {
            DataOnClient.Instance.SetSpawn(oi);
        }
    }

    #endregion
}
