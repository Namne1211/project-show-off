using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private float size = 1f;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x <20; x += size)
            for (float z = 0; z < 20; z += size)
            {
                var point = GetNearestPointonGrid(new Vector3(x+ transform.position.x, 0f, z+ transform.position.z));
                Gizmos.DrawSphere(point, 0.1f); ;
            }
                
    }

}
