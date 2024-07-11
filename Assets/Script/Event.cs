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
    public void SetInanimationFalse()
    {
        eventManager.Inanimation = false;
    }
}
