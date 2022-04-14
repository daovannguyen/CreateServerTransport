using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class JoinRoomMessage
{
    public int Id;
    public JoinRoomMessage(int _id)
    {
        Id = _id;
    }
}

public class SL_JoinRoom : RegisterEvent
{
    private void OnEnable()
    {
        RegisterEventsServer(ref NetUtility.S_JOINROOM);
    }
    private void OnDisable()
    {
        UnRegisterEventsServer(ref NetUtility.S_JOINROOM);
    }
    void CreateMessageToClient(int roomId)
    {
        JoinRoomMessage jrm = new JoinRoomMessage(roomId);
        NetJoinRoom jr = new NetJoinRoom();
        jr.ContentBox = JsonUtility.ToJson(jrm);
        Server.Instance.BroadCat(jr);
    }
    public override void OnEventServer(NetMessage msg, NetworkConnection cnn)
    {
        Debug.Log("Hello");
        NetJoinRoom jr = msg as NetJoinRoom;
        Debug.Log(jr.ContentBox);
        JoinRoomMessage jrm = JsonUtility.FromJson<JoinRoomMessage>(jr.ContentBox);
        int indexRoom = FindIndexRoomById(jrm.Id);
        if (indexRoom != -1)
        {
            DataOnServer.Instance.rooms[indexRoom].PlayerIds.Add(cnn.InternalId);
            CreateMessageToClient(DataOnServer.Instance.rooms[indexRoom].Id);
        }
        else
        {
            int idRoomRandom;
            bool thoaMan = false;
            do
            {
                idRoomRandom = Random.Range(1, 100);
                thoaMan = CheckRoomIdExist(idRoomRandom);
            }
            while (thoaMan);

            Room room = new Room(idRoomRandom, cnn.InternalId);
            DataOnServer.Instance.rooms.Add(room);
            CreateMessageToClient(idRoomRandom);
            Debug.Log(idRoomRandom);
        }    
        
    }

    int FindIndexRoomById(int id)
    {
        List<Room> rooms = DataOnServer.Instance.rooms;
        int lenght = rooms.Count;
        for (int i=0; i<lenght; i++)
        {
            if (rooms[i].Id == id)
                return i;
        }
        return -1;
    }
    bool CheckRoomIdExist(int roomId)
    {
        foreach (var i in DataOnServer.Instance.rooms)
        {
            if (roomId == i.Id)
                return true;
        }
        return false;
    }    

}
