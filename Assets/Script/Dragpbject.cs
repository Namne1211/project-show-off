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
        Vector3 movingRange = GetMouseWorldPos() + mOffset + new Vector3(0, 3, 0);
        movingRange.y = startPos.y;
        transform.position = movingRange;
        Debug.Log(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        transform.position = startPos;
    }

}
