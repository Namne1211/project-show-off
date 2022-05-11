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

        if(augment < 4)
        {
            Vector3 rndPos = new Vector3(Random.Range(-1, 1), aumentHolder.transform.position.y , Random.Range(-2, 2));
            Instantiate(a, rndPos,aumentHolder.transform.rotation,aumentHolder.transform);
        }

    }
}
