using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Cat_01 : Event
{

    public override bool CheckRequirement()
    {
        return true;
    }
    public override void StartEvent()
    {

    }
    public override void DuringEvent()
    {
        
    }
    public override void EndEvent()
    {
        Destroy(gameObject);
    }
}
