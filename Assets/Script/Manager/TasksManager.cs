using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TasksManager : MonoBehaviour
{
    List<string> types = new List<string>() { "desert","tropical","artic"};
    List<string> humidity = new List<string>() { "dry", "moist", "wet" };
    List<string> tempature = new List<string>() { "hot", "cold", "tepyd" };

    public TextMeshProUGUI taskToShow;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NewTask();
        }
    }
    void NewTask()
    {
       
        int rndTypes = Random.Range(0,2);
        int rndHumid = Random.Range(0, 2);
        int rndtemp = Random.Range(0, 2);

        string taskName = "I need a product for the " + types[rndTypes] + " environment. It needs to be " + humidity[rndHumid] + " humid level and " + tempature[rndtemp] + " tempature level.";

        taskToShow.text = taskName;
    }
}
