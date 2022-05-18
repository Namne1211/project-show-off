using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject holder;
    public GameObject line;
    Vector3 prevPos;
    public int point;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (other.gameObject.name == "line")
            {
                Debug.Log("check");
                RenewPos();
            }
            else
            {
                //Debug.Log("fault");
            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (other.gameObject.name == "line")
            {
                Debug.Log("check");
                RenewPos();
            }
            else
            {
                //  Debug.Log("fault");
            }
        }

    }


    /*  private void Update()
      {
          if (Input.GetMouseButtonDown(0))
          {
              if(line.transform.position.x > (transform.position.x + transform.lossyScale.x + line.transform.lossyScale.x)&&
                  line.transform.position.x < (transform.position.x + transform.lossyScale.x + line.transform.lossyScale.x))
              {
                  Debug.Log("check");
                  RenewPos();
              }
          }
          Debug.Log(-(transform.position.x + transform.lossyScale.x + line.transform.lossyScale.x));

      }*/
    void RenewPos()
    {
        point += 1;
        float holderLength = (holder.transform.lossyScale.x - transform.lossyScale.x) / 2;

        float ranX = Random.Range(-holderLength, holderLength);
        while(ranX > prevPos.x-2f && ranX <prevPos.x+2f)
            ranX = Random.Range(-holderLength, holderLength);

        prevPos = new Vector3(ranX, transform.position.y, transform.position.z);
        transform.position = new Vector3(ranX, transform.position.y, transform.position.z);
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
