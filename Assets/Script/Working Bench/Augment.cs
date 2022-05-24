using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tropical
{
    artic,
    desert,
    tropical    
}

public enum humid
{
    wet,
    moise,
    dry
}
public enum tempature
{
    hot,
    cold,
    warm
}


public abstract class Augment : MonoBehaviour
{

    public tropical tropical;
}
