﻿using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class L_JoinRoom : RegisterEvent
{
    /*
    private class JoinRoomMessage
    {
        public int RoomId;
        public int HostId;
        public List<int> PlayerIds;
        public JoinRoomMessage()
        {
            RoomId = -1;
            HostId = -1;
            PlayerIds = new List<int>();
        }
        public JoinRoomMessage(int _roomId, int _hostId)
        {
            RoomId = _roomId;
            HostId = _hostId;
            PlayerIds = new List<int>();
            PlayerIds.Add(HostId);
        }
    }

    */
    // quy định biến viết hoa hết là dành cho máy chủ

    #region REGISTEEVENT
    private void OnEnable()
    {
        RegisterEvents(ref NetUtility.S_JOINROOM, ref NetUtility.C_JOINROOM);
    }
    private void OnDisable()
    {
        UnRegisterEvents(ref NetUtility.S_JOINROOM, ref NetUtility.C_JOINROOM);
    }
    #endregion
    #region Server
    //public void CreateMessageToClient(NetworkConnection cnn, string jrmString)
    //{
    //    NetJoinRoom njr = new NetJoinRoom();
    //    njr.ContentBox = jrmString;
    //    Server.Instance.BroadCat(njr);
    //}
    public override void OnEventServer(NetMessage msg, NetworkConnection cnn)
    {
        NetJoinRoom jr = msg as NetJoinRoom;
        RoomInstance jrm = JsonUtility.FromJson<RoomInstance>(jr.ContentBox);
        //add thành viên khi room có sẵn
        if (jrm.RoomId != -1)
        {
            int indexRoom = RoomInstance.FindIndexRoomById(jrm.RoomId, DataOnServer.Instance.rooms);
            // client join, không có room, server trả về room trống
            if (indexRoom == -1)
            {
                NetJoinRoom njr = new NetJoinRoom();
                njr.ContentBox = JsonUtility.ToJson(njr);
                Server.Instance.SendToClient(cnn, njr);
            }
            else
            {
                DataOnServer.Instance.rooms[indexRoom].AddPlayer(cnn.InternalId);
                jrm = DataOnServer.Instance.rooms[indexRoom];
                NetJoinRoom njr = new NetJoinRoom();
                njr.ContentBox = JsonUtility.ToJson(jrm);
                Server.Instance.BroadCatOnRoom(jrm, njr);
                //CreateMessageToClient(cnn, JsonUtility.ToJson(jrm));
            }
        }
        // trường hợp phải tạo room
        else
        {
            int idRoomRandom = RoomInstance.GetNewRoomId(DataOnServer.Instance.rooms);
            RoomInstance room = new RoomInstance(idRoomRandom, cnn.InternalId);
            DataOnServer.Instance.rooms.Add(room);

            NetJoinRoom njr = new NetJoinRoom();
            njr.ContentBox = JsonUtility.ToJson(room);
            Server.Instance.SendToClient(cnn, njr);
        }
    }

    

    #endregion

    #region Client
    public void CreateMessageToServer(int roomId = -1)
    {
        RoomInstance jrm = new RoomInstance();
        if (roomId != -1)
        {
            jrm.RoomId = roomId;
        }

        jrm.HostId = DataOnClient.Instance.InternalId;
        NetJoinRoom njr = new NetJoinRoom();
        njr.ContentBox = JsonUtility.ToJson(jrm);
        Client.Instance.SendToServer(njr);
    }
    public override void OnEventClient(NetMessage msg)
    {
        RoomInstance jrm = JsonUtility.FromJson<RoomInstance>((msg as NetJoinRoom).ContentBox);
        if (jrm.RoomId == -1)
        {
            Debug.Log("Không có room");
        }
        else
        {
            DataOnClient.Instance.room = jrm;
            Debug.Log(JsonUtility.ToJson(jrm));
        }
    }

    #endregion




}
