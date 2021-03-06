using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPad : MonoBehaviour
{
	[Header("Target Object")]
	public GameObject targetObject;
	[Header("Movement")]
	public bool toMove;
	public bool movementX;
	public bool movementY;

	[Header("Speed Increment")]
	public float speed = .1f;

	Vector2 currentMousePosition;
	Vector2 mouseDeltaPosition;
	Vector2 lastMousePosition;
	bool istouchpadactive;
	bool draging;

	GameObject dragingObj;
	GameObject current;
	void Start()
	{
		ResetMousePosition();
	}

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(targetObject.transform.position);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			if (hit.collider.tag == "Plant")
			{
				current = hit.collider.gameObject;
				current.GetComponent<Renderer>().materials[1].SetColor("_color", Color.green);

            }
            else
            {
				if(current!=null)
				current.GetComponent<Renderer>().materials[1].SetColor("_color", Color.black);

			}


		}
		//controll mouse
		if (istouchpadactive)
		{
			currentMousePosition = Input.mousePosition;
			mouseDeltaPosition = currentMousePosition - lastMousePosition;

			if (toMove)
			{
				if (movementX && movementY)
				{
					//Debug.Log(Camera.main.ScreenToWorldPoint(targetObject.transform.position));
					targetObject.transform.Translate(mouseDeltaPosition.x * speed, mouseDeltaPosition.y * speed, 0f);
					//targetObject.transform.position = new Vector3(Mathf.Clamp(targetObject.transform.position.x, 0, Display.displays[1].renderingWidth), Mathf.Clamp(targetObject.transform.position.y * speed,0, Display.displays[1].renderingHeight), targetObject.transform.position.z);
				}
				else
				if (movementX)
				{
					targetObject.transform.Translate(mouseDeltaPosition.x * speed, 0f, 0f);

				}
				else
				if (movementY)
				{
					targetObject.transform.Translate(0f, mouseDeltaPosition.y * speed, 0f);
					
				}
				
			}
			
		
			lastMousePosition = currentMousePosition;
		}
	}

	//reset mouse pos
	public void ResetMousePosition()
	{
		currentMousePosition = Input.mousePosition;
		lastMousePosition = currentMousePosition;
		mouseDeltaPosition = currentMousePosition - lastMousePosition;
	}

	//active onmouse click
	public void TouchpadActivate()
	{
		ResetMousePosition();
		istouchpadactive = true;
		
	}

	//on mouse drag
	public void TouchpadHold()
    {
        if (draging)
        {
			if(dragingObj!= null)
			dragingObj.GetComponent<Dragpbject>().IsMoving();
		}
		
	}

	//on mouse up
    public void TouchpadDeactivate()
	{
		if (dragingObj == null)
		{
			Ray ray = Camera.main.ScreenPointToRay(targetObject.transform.position);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.tag == "Plant")
				{
					dragingObj = hit.collider.gameObject;
					dragingObj.GetComponent<Dragpbject>().MovingStart();
					draging = true;

					hit.collider.gameObject.GetComponent<Renderer>().materials[1].SetColor("_color", Color.green);

				}

			}
        }
        else
        {
			draging = false;
			dragingObj = null;
		}		
		istouchpadactive = false;
	}
}
