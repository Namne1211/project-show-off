using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scannerManager : MonoBehaviour
{
    GameObject aumentHolder;
    bool spawned;
    public GameObject a;
    public List<GameObject> ObjToSpawn;

    private void Start()
    {
        aumentHolder = GameObject.Find("AumentHolder");
    }


    public void SpawnOnScan()
    {
        int augment = GameObject.FindGameObjectsWithTag("Plant").Length;
        Debug.Log(augment);
        if (augment < 4)
        {
            
            Vector3 rndPos = new Vector3(Random.Range(-1, 1), aumentHolder.transform.position.y , Random.Range(-2, 2));
            GameObject asd =Instantiate(a, rndPos,aumentHolder.transform.rotation,aumentHolder.transform);
            int child =asd.transform.childCount;
            for(int i = 0; i < child; i++)
            {
                asd.transform.GetChild(0).parent = aumentHolder.transform;
            }
        }

    }
}
