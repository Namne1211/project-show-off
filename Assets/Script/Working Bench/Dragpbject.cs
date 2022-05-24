using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnDestroyHandler(GameObject objectToDestroy);
public class Dragpbject : MonoBehaviour
{

    public GameObject targetCursor;
    private Vector3 mOffset;

    private float mZcord;

    private Vector3 startPos;

    public OnDestroyHandler onDestroy;

    //bounderies
    public int horizontalBounderies=25;

    public int verticalBounderies=10;
    
    private void Start()
    {
        targetCursor = GameObject.Find("mouse");
        startPos = transform.position;
    }

    private void Update()
    {
        RemoveObj();
    }

    void RemoveObj()
    {
        if (transform.position.x < -horizontalBounderies || transform.position.x > horizontalBounderies || 
            transform.position.z < -verticalBounderies || transform.position.z > verticalBounderies)
        {
            onDestroy?.Invoke(gameObject);
            Destroy(gameObject);
        }
    }
    public void MovingStart()
    {
        mZcord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();

    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = targetCursor.transform.position;

        mousePoint.z = mZcord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void IsMoving()
    {
        //decide moving range
        Vector3 movingRange = GetMouseWorldPos() + mOffset + new Vector3(0, 3, 0);
        //Debug.Log(GetMouseWorldPos());
        //moving restriction
        movingRange.y = startPos.y;
        //movingRange.x = Mathf.Clamp(movingRange.x, -13, 13);
        //movingRange.z = Mathf.Clamp(movingRange.z, -4, 8);
        transform.position = movingRange;
    }


}
