using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 0.25f;
    [SerializeField]
    float snapDistance = 0.25f;
    [SerializeField]
    float movingtiles = 4f;

    [SerializeField]
    GameObject part;
    [SerializeField]
    LineRenderer lr;
    Vector3 targetPosition;
    Vector3 startPosition;
    Vector3 OriginPos;
    bool moving;
    [SerializeField]
    List<GameObject> partList= new List<GameObject>();
    // Update is called once per frame
    Vector3 mOffset;
    private void Awake()
    {
        startPosition =transform.position;
        OriginPos = transform.position;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position);
    }
    void Update()
    {

        //recieve input
        if (moving == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                targetPosition = transform.position + Vector3.forward * movingtiles;

                moving = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                targetPosition = transform.position + Vector3.back * movingtiles;

                moving = true;

            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                targetPosition = transform.position + Vector3.left * movingtiles;

                moving = true;

            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                targetPosition = transform.position + Vector3.right * movingtiles;

                moving = true;

            }

        }

        //moving 

        if (moving)
        {

            if (Vector3.Distance(startPosition, transform.position) > snapDistance)
            {
                transform.position = targetPosition;

                //rendering line and update at tartget
                SetupLine();
                startPosition = targetPosition;
                moving = false;

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Line")
        {
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
            moving = false;
            
        }else if(other.tag == "Power")
        {
            Debug.Log("1");
        }
    }
}
