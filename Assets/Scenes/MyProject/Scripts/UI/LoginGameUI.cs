using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class LoginGameUI : MonoBehaviour
{
    public GameObject LoginUI;


    public Button server_Btn;
    public Button client_Btn;
    public TMP_InputField ip_Input;
    public TMP_InputField port_Input;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        server_Btn.onClick.AddListener(OnClickServerButton);
        client_Btn.onClick.AddListener(OnClickClientButton);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickServerButton()
    {
        Server.Instance.Init(GetPort());
        Client.Instance.Init(GetIp(), GetPort());
        NetworkManager.Instance.SetPropertyServer();
        AfterClickButton();
    }
    public void OnClickClientButton()
    {
        Client.Instance.Init(GetIp(), GetPort());
        NetworkManager.Instance.SetPropertyClient();
        AfterClickButton();
    }
    public string GetIp()
    {
        if (ip_Input.text == "")
            return "127.0.0.1";
        else
            return ip_Input.text;
    }
    public ushort GetPort()
    {
        if (port_Input.text == "")
            return 8000;
        else
            return Convert.ToUInt16(port_Input.text);
    }
    void AfterClickButton()
    {
        LoginUI.SetActive(false);
        JoinRoomUI.Instance.joinRoomUI.SetActive(true);
        //SceneManager.LoadScene("Lobby");
    }
}
