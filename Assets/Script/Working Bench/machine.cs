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

    private void Update()
    {
        checkCondition();
    }

    void checkCondition()
    {
        switch(machineType){
            case MachineTypes.environment:
                if (tasksManager.trop == tropical.artic)
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


}
