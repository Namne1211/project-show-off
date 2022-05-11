using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragpbject : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZcord;

    private Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (transform.position.x < -14 || transform.position.x > 14 || transform.position.z < -5|| transform.position.z > 9)
        {
            Destroy(gameObject);
        }
    }
    private void OnMouseDown()
    {
        mZcord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();

    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZcord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        //decide moving range
        Vector3 movingRange = GetMouseWorldPos() + mOffset + new Vector3(0, 3, 0);
        //moving restriction
        movingRange.y = startPos.y;
        //movingRange.x = Mathf.Clamp(movingRange.x, -13, 13);
        //movingRange.z = Mathf.Clamp(movingRange.z, -4, 8);
        transform.position = movingRange;
    }

    private void OnMouseUp()
    {
        //transform.position = startPos;
    }

}
