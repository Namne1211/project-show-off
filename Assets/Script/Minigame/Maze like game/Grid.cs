using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private float size = 1f;
    [SerializeField]
    List<obstacle> vector3s = new List<obstacle>();
    public GameObject obstacle;
    public GameObject powerPoint;

    private void Start()
    {
        AddGridPos();
        InstantObstacle();
    }

    //add to list
    void AddGridPos()
    {
        for (float x = 0; x < size * 4; x += size)
            for (float z = 0; z < size * 4; z += size)
            {
                Vector3 point = GetNearestPointonGrid(new Vector3(x + transform.position.x, 0f, z + transform.position.z));
                vector3s.Add(new obstacle(point, false));
            }
    }

    void InstantObstacle()
    {
        //random choice for power station
        int firstPower=Random.Range(0, vector3s.Count-1);
        int SecondPower = Random.Range(0, vector3s.Count - 1);

        while(firstPower == SecondPower)
        {
            SecondPower = Random.Range(0, vector3s.Count - 1);
        }

        Instantiate(powerPoint,vector3s[firstPower].position,new Quaternion(0,0,0,0));
        vector3s[firstPower].Open = true;
        Instantiate(powerPoint, vector3s[SecondPower].position, new Quaternion(0, 0, 0, 0));
        vector3s[SecondPower].Open = true;
        
        //spawn other object
        foreach(obstacle op in vector3s)
        {
            if (op.Open) continue;
            Instantiate(obstacle,op.position,new Quaternion(0,0,0, 0));
        }
    }

    //create a point to follow the parent object
    public Vector3 GetNearestPointonGrid(Vector3 pos)
    {
        pos -= transform.position;
        int xCount = Mathf.RoundToInt(pos.x /size);
        int yCount = Mathf.RoundToInt(pos.y /size);
        int zCount = Mathf.RoundToInt(pos.z /size);


        Vector3 result= new Vector3((float)xCount *size, (float)yCount * size, (float)zCount * size);

        result+=transform.position;
        return result;
    }

    //draw gizmo
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        for (float x = 0; x < size * 4; x += size)
            for (float z = 0; z < size * 4; z += size)
            {
                Vector3 point = GetNearestPointonGrid(new Vector3(x + transform.position.x, 0f, z + transform.position.z));
                Gizmos.DrawSphere(point, 0.1f);
            }



    }

}

//class to hold position and state of the obstacle
class obstacle
{
    public Vector3 position;
    public bool Open;
    public obstacle(Vector3 pos,bool open)
    {
        position = pos;
        Open = open;
    }
    
}
