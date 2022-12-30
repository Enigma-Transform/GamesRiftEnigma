using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject key;
    [SerializeField]
    Vector3 pos;
    public bool roomOneUnlock = false;
    [SerializeField]
    float minXPos,maxXpos,minZPos,maxZPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(keySpawnerRoutine());

    }

    private void Update()
    {

    }

    IEnumerator keySpawnerRoutine()
    {
         pos = new Vector3(Random.Range(minXPos,maxXpos), 1, Random.Range(minZPos,maxZPos));
        while (roomOneUnlock == false)
        {
            GameObject keyGO =  Instantiate(key,pos,Quaternion.identity);

            Destroy(keyGO, 10f);
            yield return new WaitForSeconds(10f);
        }
     
 
        //Debug.Log(isShot);

    }
}
