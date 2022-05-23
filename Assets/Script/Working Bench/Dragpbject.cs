using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragpbject : MonoBehaviour
{

    public GameObject targetCursor;
    private Vector3 mOffset;

    private float mZcord;

    private Vector3 startPos;
    private void Start()
    {
        targetCursor = GameObject.Find("mouse");
        startPos = transform.position;
    }

    private void Update()
    {
        if (transform.position.x < -20 || transform.position.x > 20 || transform.position.z < -7|| transform.position.z > 11)
        {
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
