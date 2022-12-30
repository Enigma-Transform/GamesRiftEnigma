using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUnlock : MonoBehaviour
{
    [SerializeField]
    KeySpawner KeySpawner;

    [SerializeField]
    int treeCountRoom1;

    [Range(0,100)]
    [SerializeField]
    int maxTrees = 0;

    bool roomOneUnlockedLocal;
    private void Awake()
    {
        
    }
    private void Update()
    {
        if(treeCountRoom1 == maxTrees)
        {
           // KeySpawner.roomOneUnlock = true;
            Debug.Log("true");
        }
    }
    public void Room1TreeCount()
    {
        Debug.Log(treeCountRoom1++);
    }
}
