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
    public MinigameManager minigameManager;
    
    private void Update()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plant")
        {
            switch (machineType)
            {
                case MachineTypes.environment:
                    if (other.gameObject.GetComponent<Augment>().environment == tasksManager.trop)
                    {
                        minigameManager.onRunningMinigame?.Invoke(0);
                    }
                    else
                    {
                        //false part animation
                    }
                    break;
                case MachineTypes.humid:
                    if (other.gameObject.GetComponent<Augment>().humid == tasksManager.humid)
                    {
                        minigameManager.onRunningMinigame?.Invoke(1);
                    }
                    else
                    {
                        
                        //false part animation
                    }
                    break;
                case MachineTypes.tempature:
                    if (other.gameObject.GetComponent<Augment>().temp == tasksManager.temp)
                    {
                        minigameManager.onRunningMinigame?.Invoke(2);
                    }
                    else
                    {
                        //false part animation
                    }
                    break;
            }
        }
    }
}
