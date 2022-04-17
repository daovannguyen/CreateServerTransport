using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class CL_JoinRoom : RegisterEvent
{
    public TMP_InputField roomId_Input;
    public Button join_Btn;
    private void Awake()
    {
        join_Btn.onClick.AddListener(OnClickJoinButton);
    }

    void CreateMessageToServer(string roomId)
    {
        JoinRoomMessage jrm = new JoinRoomMessage(Convert.ToInt32(roomId));
        NetJoinRoom jr = new NetJoinRoom();
        jr.ContentBox = JsonUtility.ToJson(jrm);
        Client.Instance.SendToServer(jr);
        
    }
    
    private void OnClickJoinButton()
    {
        CreateMessageToServer(roomId_Input.text);
    }

    private void OnEnable()
    {
        RegisterEventsClient(ref NetUtility.C_JOINROOM);
    }
    private void OnDisable()
    {
        UnRegisterEventsClient(ref NetUtility.C_JOINROOM);
    }
    public override void OnEventClient(NetMessage msg)
    {
        NetJoinRoom jr = msg as NetJoinRoom;
        JoinRoomMessage jrm = JsonUtility.FromJson<JoinRoomMessage>(jr.ContentBox);
        if (jrm.Id.ToString() == roomId_Input.text)
        {
            roomId_Input.text = "Bạn dã vào nhóm";
        }
        else
        {
            roomId_Input.text = jrm.Id.ToString();
        }
    }
}
