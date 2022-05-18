using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicateLine : MonoBehaviour
{
    public GameObject holder;
    Vector3 movingDir;

    private void Start()
    {
        movingDir = Vector3.left*3 ;
    }
    private void Update()
    {
        float holderLength = (holder.transform.lossyScale.x - transform.lossyScale.x) / 2;
        if (transform.position.x >= holderLength || transform.position.x <= -holderLength)
        {
            movingDir = -movingDir;
        }
        transform.Translate(movingDir * Time.deltaTime);
    }
}
