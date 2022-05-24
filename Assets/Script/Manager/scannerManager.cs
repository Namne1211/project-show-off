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
        int augment = ObjToSpawn.Count;
     
        Debug.Log(augment);
        if (augment < 4)
        {
            
            Vector3 rndPos = new Vector3(Random.Range(-1, 1), aumentHolder.transform.position.y , Random.Range(-2, 2));
            GameObject asd =Instantiate(a, rndPos,aumentHolder.transform.rotation,aumentHolder.transform);
            int child =asd.transform.childCount;
            ObjToSpawn.Add(asd);
            for(int i = 0; i < child; i++)
            {
                ObjToSpawn.Add(asd.transform.GetChild(0).gameObject);             
                asd.transform.GetChild(0).gameObject.GetComponent<Dragpbject>().onDestroy += removemember;
                asd.transform.GetChild(0).parent = aumentHolder.transform;
            }
            if (asd.GetComponent<Dragpbject>() != null)
            {
                asd.GetComponent<Dragpbject>().onDestroy += removemember;
            }
        }

    }

    public void removemember(GameObject objectToRemove)
    {
       ObjToSpawn.Remove(objectToRemove);
    }
}
