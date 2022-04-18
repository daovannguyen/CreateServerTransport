using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectId : MonoBehaviour
{
    public int Id;
    public void SetId(int id)
    {
        Id = id;
    }
    public int GetId()
    {
        return Id;
    }
}
