using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum plantPart
{
    leaf,
    flower
}

public enum tropical
{
    artic,
    desert,
    tropical    
}


public abstract class Augment : MonoBehaviour
{
    public plantPart part;

    public tropical tropical;
}
