using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum MachineTypes
{
    environment,
    humid,
    tempature
}

public class machine : MonoBehaviour
{
    public TasksManager tasksManager;
    public MachineTypes machineType;

    GameObject currentAugment;
    private void Update()
    {
        checkCondition();
    }

    void checkCondition()
    {
        if(currentAugment != null)
        switch(machineType){
            case MachineTypes.environment:
                if (tasksManager.trop == Environment.artic)
                {
                    Debug.Log("1");
                }
                break;
            case MachineTypes.humid:
                if (tasksManager.humid == humid.wet)
                {
                    Debug.Log("2");
                }
                break;
            case MachineTypes.tempature:
                if (tasksManager.temp == tempature.hot)
                {
                    Debug.Log("3");
                }
                break;
        }
    }
    


    public void conditionToUse()
    {
        
    }


    public void function()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plant")
        {
            currentAugment = other.gameObject;
        }
    }
}
