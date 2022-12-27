using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUnlock : MonoBehaviour
{
    [SerializeField]
    int treeCountRoom1;

    [Range(0,100)]
    [SerializeField]
    int maxTrees = 0;
    private void Update()
    {
        if(treeCountRoom1 == maxTrees)
        {
            Debug.Log("Un;locked");
        }
    }
    public void Room1TreeCount()
    {
        treeCountRoom1++;
    }
}
