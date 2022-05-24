using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TasksManager : MonoBehaviour
{
    List<string> types = new List<string>() { "desert","tropical","artic"};
    List<string> humidity = new List<string>() { "dry", "moist", "wet" };
    List<string> tempature = new List<string>() { "hot", "cold", "tepyd" };

    public TextMeshProUGUI taskToShow;
    public tropical trop;
    public tempature temp;
    public humid humid;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NewTask();
        }
    }
    void NewTask()
    {

        trop = EnumExtend.RandomEnumValue<tropical>();
        temp = EnumExtend.RandomEnumValue<tempature>();
        humid = EnumExtend.RandomEnumValue<humid>();

        string taskName = "I need a product for the " + trop + " environment. It needs to be " + humid + " humid level and " + temp + " tempature level.";

        taskToShow.text = taskName;
    }


}
public static class EnumExtend
{
    public static T RandomEnumValue<T>()
    {
        var values = Enum.GetValues(typeof(T));
        int random = UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(random);
    }
}
