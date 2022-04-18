using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    PLAYER,
    NORMAL,// đồ chung
}
public class ObjectInstance 
{
    public ObjectType Type;
    public int Id;
    public int IndexPrefab;
    public Vector3 Position;
    public Vector3 Rotation;
    public ObjectInstance()
    {
        Type = ObjectType.NORMAL;
        Id = -1;
        IndexPrefab = -1;
        Position = Vector3.zero;
        Rotation = Vector3.zero;
    }
    public ObjectInstance(ObjectType _type, int _id, int _indexPrefab, Vector3 _position, Vector3 _rotation)
    {
        Type = _type;
        Id = _id;
        IndexPrefab = _indexPrefab;
        Position = _position;
        Rotation = _rotation;
    }

}
