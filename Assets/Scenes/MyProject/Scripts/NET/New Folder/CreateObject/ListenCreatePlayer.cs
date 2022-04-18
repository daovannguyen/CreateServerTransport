using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class ListenCreatePlayer : MonoBehaviour
{
    //private void Start()
    //{
       
    //    CreateMessageToServer();
    //}

    ////random vi tri
    //void CreateMessageToServer()
    //{
    //    NetCreatePlayer ncp = new NetCreatePlayer();
    //    Vector3 randomPosition = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
    //    ObjectMessage cp = new ObjectMessage(NetworkManager.Instance.InternalId, 0, randomPosition);
    //    ncp.ChatMesage = JsonUtility.ToJson(cp);
    //    Client.Instance.SendToServer(ncp);
    //}
    //#region RegisterEvent
    //private void OnEnable()
    //{
    //    RegisterEvent();
    //}
    //private void OnDisable()
    //{
    //    UnRegisterEvent();
    //}

    //void RegisterEvent()
    //{
    //    NetUtility.S_CREATEPLAYER += OnCreatePlayerServer;
    //    NetUtility.C_CREATEPLAYER += OnCreatePlayerClient;
    //}
    //void UnRegisterEvent()
    //{
    //    NetUtility.S_CREATEPLAYER -= OnCreatePlayerServer;
    //    NetUtility.C_CREATEPLAYER -= OnCreatePlayerClient;
    //}

    //private void OnCreatePlayerServer(NetMessage msg, NetworkConnection cnn)
    //{
    //    Server.Instance.BroadCat(msg);
    //}
    //#endregion
    //private void OnCreatePlayerClient(NetMessage msg)
    //{
    //    ObjectMessage om = JsonUtility.FromJson<ObjectMessage>((msg as NetCreatePlayer).ChatMesage);
    //    ObjectManager.Instance.SetPlayerWithId(om);
    //}
}
