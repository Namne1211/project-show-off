using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotWheel : MonoBehaviour
{
    public float winRate = 20;
    public float progress;
    public Slider progressbar;
    public Gradient grad;
    public Image fill;

    
    private void Start()
    {
        progressbar.maxValue=winRate;
        fill.color = grad.Evaluate(0f);
    }

    private void Update()
    {
        if(progress>=0)
        progress -= 0.005f;
        //updating bar
        progressbar.value = progress;
        fill.color = grad.Evaluate(progressbar.normalizedValue);

        if (Input.GetMouseButton(0))
        {
            //findif mous position
            Vector3 dif = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) - transform.position;
            dif.Normalize();
            float rotateZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;

            //restric the rotating angle
            float degreeAngle;
            if (transform.eulerAngles.z>=0 && transform.eulerAngles.z <= 180)
            {
                if(rotateZ < transform.eulerAngles.z)
                {
                    if(rotateZ > -10) {
                        progress += 0.035f;
                        transform.LeanRotate(new Vector3(0, 0, rotateZ), 0.1f);
                    }
                    
                }

            }
            if (transform.eulerAngles.z > 180 && transform.eulerAngles.z < 360)
            {
                degreeAngle = 360 - transform.localEulerAngles.z;
                if (rotateZ >= 0 && rotateZ < 180)
                {
                    if (rotateZ >= -degreeAngle)
                    {
                        if (rotateZ > 170)
                        {
                            progress += 0.035f;
                            transform.LeanRotate(new Vector3(0, 0, rotateZ), 0.1f);
                        }
                        
                    }
                }else
                if (rotateZ < 0 && rotateZ >= -180)
                    if (rotateZ < -degreeAngle)
                    {
                        progress += 0.035f;
                        transform.LeanRotate(new Vector3(0, 0, rotateZ), 0.1f);
                    }
            }




        }


    }

    //if win
    void Win()
    {
        if (progress >= winRate)
        {
            Debug.Log("win");
        }
    }


}
