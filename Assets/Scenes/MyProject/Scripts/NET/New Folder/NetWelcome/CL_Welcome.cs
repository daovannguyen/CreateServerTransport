using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CL_Welcome : RegisterEvent
{
    private void OnEnable()
    {
        RegisterEventsClient(ref NetUtility.C_WELCOME);
    }
    private void OnDisable()
    {
        UnRegisterEventsClient(ref NetUtility.C_WELCOME);
    }
    public override void OnEventClient(NetMessage msg)
    {
        NetWelcome nw = msg as NetWelcome;
        PlayerId pi = JsonUtility.FromJson<PlayerId>(nw.ContentBox);
        DataOnClient.Instance.InternalId = pi.Id;
    }
}
