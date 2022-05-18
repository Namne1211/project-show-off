using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    //set up grid moving
    [SerializeField]
    float moveSpeed = 0.25f;
    [SerializeField]
    float snapDistance = 0.25f;
    [SerializeField]
    float movingtiles = 4f;

    //setup line renderer
    [SerializeField]
    GameObject part;
    [SerializeField]
    LineRenderer lr;
    Vector3 targetPosition;
    Vector3 startPosition;
    Vector3 OriginPos;
    bool moving;
    [SerializeField]
    List<GameObject> partList = new List<GameObject>();

    //setup swipe input
    Vector3 StartTouchPos;
    Vector3 CurrentTouchPos;
    Vector3 EndTouchPos;
    float swipeRange=10;
    float tapRange=5;
    bool stopTouch;

    //setup winning state
    bool Winning;
    int powerCount;

    private void Awake()
    {
        //setup starting line
        startPosition = transform.position;
        OriginPos = transform.position;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position);
    }
    void Update()
    {
        //recieve swipe input
        if (!moving)
            swipe();
        


        //moving with input
        if (moving)
        {
            if (Vector3.Distance(startPosition, transform.position) > snapDistance)
            {
                transform.position = targetPosition;

                //rendering line and update at tartget
                SetupLine();
                startPosition = targetPosition;
                moving = false;
                Debug.Log(moving);
                return;
            }

            lr.SetPosition(lr.positionCount - 1, transform.position);
            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;

            return;
        }


    }

    void SetupLine()
    {
        lr.positionCount += 1;
        lr.SetPosition(lr.positionCount - 1, targetPosition);
        if (lr.positionCount > 1)
            lr.SetPosition(lr.positionCount - 2, targetPosition);

        partList.Add(Instantiate(part, startPosition, new Quaternion(0, 0, 0, 1)));
        lr.SetPosition(lr.positionCount - 3, startPosition);
    }

    //reset line
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Line")//line
        {
            resetGameState();

        }
        else if (other.tag == "Power")//powerpoint
        {
            PowerStation power = other.gameObject.GetComponent<PowerStation>();
            if (!power.IsTouch)
            {
                power.IsTouch = true;
                powerCount += 1;
                Debug.Log(powerCount);
            }
            
            
        }else if(other.tag == "finalPoint")//endstate
        {
            if (powerCount >= 2)
            {
                Debug.Log("win");
            }
            else
            {
                resetGameState();
            }
        }
    }

    private void resetGameState()
    {
        //reset line
        foreach (GameObject part in partList)
        {
            Destroy(part);
        }
        partList.Clear();
        transform.position = OriginPos;
        lr.positionCount = 2;
        startPosition = OriginPos;
        lr.SetPosition(0, OriginPos);
        lr.SetPosition(1, OriginPos);
        //stop movement
        moving = false;
        //reset game condition
        powerCount = 0;
        GameObject[] powerList = GameObject.FindGameObjectsWithTag("Power");
        foreach(GameObject power in powerList)
        {
            power.GetComponent<PowerStation>().IsTouch = false;
        }
    }

    //swipe input
    void swipe()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartTouchPos=Input.mousePosition;
        }

        if(Input.GetMouseButton(0))
        {
            CurrentTouchPos = Input.mousePosition;
            Vector3 Distance =CurrentTouchPos - StartTouchPos;
            if (!stopTouch)
            {
                if (Distance.x < -swipeRange)
                {
                    targetPosition = transform.position + Vector3.left * movingtiles;

                    moving = true;
                    stopTouch = true;
                }
                else if(Distance.x > swipeRange)
                {
                    targetPosition = transform.position + Vector3.right * movingtiles;

                    moving = true;
                    stopTouch = true;
                }else if (Distance.y < -swipeRange)
                {
                    targetPosition = transform.position + Vector3.back * movingtiles;

                    moving = true;
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange)
                {
                    targetPosition = transform.position + Vector3.forward * movingtiles;

                    moving = true;
                    stopTouch = true;
                }
              
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            stopTouch = false;
            EndTouchPos = Input.mousePosition;

            Vector3 Distance =EndTouchPos - StartTouchPos;
            
            if (Mathf.Abs(Distance.x)<tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                Debug.Log("tap");
            }
        }
    }
}
