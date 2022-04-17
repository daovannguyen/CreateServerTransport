using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class JoinRoomUI : MonoSingleton<JoinRoomUI>
{
    public GameObject joinRoomUI;

    public TMP_InputField roomId_Input;
    public Button create_Btn;
    public Button join_Btn;

    private void Awake()
    {
        create_Btn.onClick.AddListener(OnClickCreateRoom);
        join_Btn.onClick.AddListener(OnClickJoinRoom);
        joinRoomUI.SetActive(false);

    }

    private void OnClickJoinRoom()
    {
        FindObjectOfType<L_JoinRoom>().CreateMessageToServer(Convert.ToInt32(roomId_Input.text));
    }

    private void OnClickCreateRoom()
    {
        FindObjectOfType<L_JoinRoom>().CreateMessageToServer();
    }
    void AfterClick() { }
}
