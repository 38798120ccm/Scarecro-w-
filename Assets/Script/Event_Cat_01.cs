using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Cat_01 : Event
{
    [SerializeField] int MonthCode;
    public override bool CheckRequirement()
    {
        if(MonthCode == 1)
        {
            return true;
        }
        else 
        {
            return false;
        }    
    }
    public override bool CheckEndRequirement()
    {
        if (MonthCode != 1)
        {
            return true;
        }
        else
        {
            return false;
        }  
    }
    public override void StartEvent()
    {

    }
    public override void DuringEvent()
    {
        
    }
    public override void EndEvent()
    {
        
    }
}
