using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class ListenPlayerState : RegisterEvent
{
    //private class PlayerState
    //{
    //    public int Id;
    //    public string Trigger;
    //    public PlayerState()
    //    {
    //        Id = 0;
    //        Trigger = "";
    //    }
    //    public PlayerState(int _id, string _trigger)
    //    {
    //        Id = _id;
    //        Trigger = _trigger;
    //    }
    //}

    //private void Awake()
    //{
    //}
    //private void OnEnable()
    //{
    //    RegisterEvents(ref NetUtility.S_PLAYERSTATE, ref NetUtility.C_PLAYERSTATE);
    //}
    //private void OnDisable()
    //{
    //    UnRegisterEvents(ref NetUtility.S_PLAYERSTATE, ref NetUtility.C_PLAYERSTATE);
    //}

    //// Start is called before the first frame update
    //void Start()
    //{
    //}

    //// Update is called once per frame
    //void FixedUpdate()
    //{

    //    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        CreateMessSendToServer("Run");
    //    }
    //    if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
    //    {
    //        CreateMessSendToServer("Normal");
    //    }
    //}
    //void CreateMessSendToServer(string trigger)
    //{
    //    NetPlayerState nps = new NetPlayerState();
    //    PlayerState ps = new PlayerState(NetworkManager.Instance.InternalId,trigger);
    //    nps.ContentBox = JsonUtility.ToJson(ps);
    //    Client.Instance.SendToServer(nps);
    //}
    //public override void OnEventClient(NetMessage msg)
    //{
    //    NetPlayerState nps = msg as NetPlayerState;
    //    PlayerState ps = JsonUtility.FromJson<PlayerState>(nps.ContentBox);
    //    GameObject player = ObjectManager.Instance.GetPlayerWithId(ps.Id);
    //    Animator animator = player.GetComponent<Animator>();
    //    animator.SetTrigger(ps.Trigger);
    //}
    //public override void OnEventServer(NetMessage msg, NetworkConnection cnn)
    //{
    //    Server.Instance.BroadCat(msg);
    //}
}
