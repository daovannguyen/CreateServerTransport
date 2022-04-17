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

    }

    private void OnClickCreateRoom()
    {

    }
    void AfterClick() { }
}
