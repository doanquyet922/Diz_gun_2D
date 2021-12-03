using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    bool createRoom = false;
    string nameSceneMap;
    public void SetNameSceneMap(string name)
    {
        nameSceneMap = name;
    }
    public string GetNameSceneMap()
    {
        return nameSceneMap;
    }
    public void SetCreateRoom(bool create)
    {
        createRoom = create;
    }
    public bool getCreateRoom()
    {
        return createRoom;
    }

}
