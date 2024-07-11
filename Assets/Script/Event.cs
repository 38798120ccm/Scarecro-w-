using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Event : MonoBehaviour
{
    abstract public bool CheckRequirement();
    abstract public void StartEvent();
    abstract public void DuringEvent();
    abstract public void EndEvent();
    public EventManager eventManager;
    public int MonthCode;
    void SetInanimationFalse()
    {
        eventManager.Inanimation = false;
    }
    void SetEventStarted()
    {
        eventManager.events_started.Add(this);
    }
    public void EndStartAnimation()
    {
        SetInanimationFalse();
        SetEventStarted();
    }
}
