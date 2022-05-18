using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotWheel : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 v = touchPos - transform.position;
            Vector3 new_pos = transform.position + (v.normalized * 50);
            transform.position = new_pos;
        }
    }



    private void OnMouseDrag()
    {
        
    }

    private void OnMouseExit()
    {

    }
}
