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
    bool spawning;
    bool moving;
    [SerializeField]
    List<GameObject> partList= new List<GameObject>();
    // Update is called once per frame

    private void Start()
    {
       // lr.SetPosition(0, transform.position);
    }
    void Update()
    {

        //recieve input
        if (moving == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                targetPosition = transform.position + Vector3.forward * movingtiles;
                startPosition = transform.position;
                moving = true;
                spawning = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                targetPosition = transform.position + Vector3.back * movingtiles;
                startPosition = transform.position;
                moving = true;
                spawning = true;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                targetPosition = transform.position + Vector3.left * movingtiles;
                startPosition = transform.position;
                moving = true;
                spawning = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                targetPosition = transform.position + Vector3.right * movingtiles;
                startPosition = transform.position;
                moving = true;
                spawning = true;
            }
        }
        
        //moving 
        if (moving)
        {

            if (Vector3.Distance(startPosition, transform.position) > snapDistance)
            {
                transform.position = targetPosition;
                lr.SetPosition(lr.positionCount - 1, targetPosition);
                moving = false;
                return;
            }
            if (spawning)
            {
                /*part.transform.position = startPosition;*/
                
                partList.Add(Instantiate(part, startPosition, new Quaternion(0, 0, 0, 1)));
                SetupLine();
               
                
                spawning = false;
            }
            lr.SetPosition(lr.positionCount - 1, transform.position);
            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            
            return;
        }
        


    }

    void SetupLine()
    {
        if (partList.Count > 0)
        {

            lr.positionCount += 1;

            if(lr.positionCount > 1)
            lr.SetPosition(lr.positionCount-2, partList[partList.Count-1].transform.position);
            
        }
    }
}
