using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public int Id;
    public int HostId;
    public List<int> PlayerIds;
    //public int PlayerMax;
    public Room(int _id, int _hostId)
    {
        PlayerIds = new List<int>();
        Id = _id;
        HostId = _hostId;
        PlayerIds.Add(_hostId);
    }
}
public class DataOnServer : MonoSingleton<DataOnServer>
{
    public List<Room> rooms = new List<Room>();
}
