using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Event : MonoBehaviour
{
    abstract public bool CheckRequirement();
    abstract public void StartEvent();
    abstract public void DuringEvent();
    abstract public void EndEvent();
    public GameManager gameManager;
    public EventManager eventManager;
    public TimeManager timeManager;
    public int MonthCode;
    public void SetInanimationFalse()
    {
        gameManager.Inanimation = false;
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
    public void EndEndAnimation()
    {
        SetInanimationFalse();
        Destroy(this.gameObject);
    }
}
