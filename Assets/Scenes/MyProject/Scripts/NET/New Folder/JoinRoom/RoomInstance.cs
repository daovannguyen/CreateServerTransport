
using System.Collections.Generic;
using UnityEngine;

public class RoomInstance
{
    public int RoomId;
    public int HostId;
    public List<int> PlayerIds;
    //public int PlayerMax;

    // khởi tạo phòng
    public RoomInstance(int _id, int _hostId)
    {
        PlayerIds = new List<int>();
        RoomId = _id;
        HostId = _hostId;
        PlayerIds.Add(_hostId);
    }
    // tạo tin nhắn, sai phòng hoặc xin tạo phòng
    public RoomInstance()
    {
        PlayerIds = new List<int>();
        RoomId = -1;
        HostId = -1;
    }

    public void AddPlayer(int playerId)
    {
        PlayerIds.Add(playerId);
    }
    public void ChangeHost(int playerId)
    {
        if (PlayerIds.Contains(playerId))
        {
            HostId = playerId;
        }
    }
    public void RemovePlayer(int playerId)
    {
        PlayerIds.Remove(playerId);
    }
    public static int FindIndexRoomById(int id, List<RoomInstance> rooms)
    {
        int lenght = rooms.Count;
        for (int i = 0; i < lenght; i++)
        {
            if (rooms[i].RoomId == id)
                return i;
        }
        return -1;
    }

    public static int GetNewRoomId(List<RoomInstance> rooms)
    {
        int idRoomRandom;
        bool thoaMan = false;
        do
        {
            idRoomRandom = Random.Range(1, 100);
            thoaMan = CheckRoomIdExist(idRoomRandom, rooms);
        }
        while (thoaMan);
        return idRoomRandom;
    }
    public static bool CheckRoomIdExist(int roomId, List<RoomInstance> rooms)
    {
        foreach (var i in rooms)
        {
            if (roomId == i.RoomId)
                return true;
        }
        return false;
    }

    public static RoomInstance FindRoomByHostId(int HostId, List<RoomInstance> rooms)
    {
        foreach (var i in rooms)
        {
            if (HostId == i.HostId)
                return i;
        }
        return null;
    }
    public static RoomInstance FindRoomByPlayerId(int id, List<RoomInstance> rooms)
    {
        foreach (var i in rooms)
        {
            if (i.PlayerIds.Contains(id))
                return i;
        }
        return null;
    }
    public static bool PlayerExistRoom(int HostId, List<RoomInstance> rooms)
    {
        foreach (var i in rooms)
        {
            if (i.PlayerIds.Contains(HostId))
                return true;
        }
        return false;
    }
}