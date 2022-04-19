using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_CreateObject : MonoBehaviour
{
    L_CreateObject l_CreateObject;
    private void Awake()
    {
        l_CreateObject = GetComponent<L_CreateObject>();
        int indexPrefab = DataOnClient.Instance.IndexCharactor;
        Vector3 randomPosition = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
        l_CreateObject.CreateMessageToServer(ObjectType.PLAYER, indexPrefab, randomPosition);
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (Input.GetMouseButtonDown(0))
            {
                int indexPrefab = Random.Range(0, 3);
                Vector3 randomPosition = DataOnClient.Instance.GetPlayerLocal().transform.position;
                Debug.Log(randomPosition);
                l_CreateObject.CreateMessageToServer(ObjectType.NORMAL, indexPrefab, randomPosition);
            }

        }
    }
}
