
using System.Collections.Generic;

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
}