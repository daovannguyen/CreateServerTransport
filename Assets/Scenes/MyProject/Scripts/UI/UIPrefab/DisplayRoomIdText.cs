using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayRoomIdText : MonoBehaviour
{
    TMP_Text roomName_Text;
    RoomInstance room;
    // Start is called before the first frame update
    void Start()
    {
        roomName_Text = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        if (room != DataOnClient.Instance.room)
        {
            room = DataOnClient.Instance.room; 
            roomName_Text.text = "Ma phong: " + room.RoomId.ToString() + "\n"
             + "So luong: " + room.PlayerIds.Count.ToString();
            Debug.Log(JsonUtility.ToJson(room));
        }
        
    }
}
