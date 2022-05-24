using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject holder;
    public GameObject line;
    Vector3 prevPos;
    public int point;
    private void Update()
    {

      
        transform.LookAt(new Vector3(0, 0, -1f), Vector3.left);

    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (other.gameObject.name == "lan")
            {
                Debug.Log("check");
                RenewPos();
                line.GetComponent<IndicateLine>().speed += 40f;
                line.GetComponent<IndicateLine>().direction = -line.GetComponent<IndicateLine>().direction;


            }

        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (other.gameObject.name == "lan")
            {
                Debug.Log("check");
                RenewPos();
            }

        }

    }

    void RenewPos()
    {
        
        point += 1;
        //float holderLength = (holder.transform.lossyScale.x - transform.lossyScale.x) / 2;

        // float ranX = Random.Range(-holderLength, holderLength);
        //  while(ranX > prevPos.x-2f && ranX <prevPos.x+2f)
        //    ranX = Random.Range(-holderLength, holderLength);

        // prevPos = new Vector3(ranX, transform.position.y, transform.position.z);
        //transform.position = new Vector3(ranX, transform.position.y, transform.position.z);
        float radius = 2f;
        float angle =Random.Range(0, 360);
        Vector3 randomCircle = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad)*radius, Mathf.Sin(angle * Mathf.Deg2Rad)*radius, -1f);
        //Vector3 worldPos = transform.TransformPoint(randomCircle * radius);
        transform.position = randomCircle;
    }

    void win()
    {
        if (point >= 5)
        {
            Debug.Log("win");
            point = 0;
        }
    }
}
