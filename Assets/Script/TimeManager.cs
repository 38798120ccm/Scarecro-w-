using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] List<Month> months;
    [SerializeField] EventManager eventManager;
    public Month now;
    public void EnterMonth(Month month)
    {
        now = month;
        foreach(Event e in now.events_Onable)
        {
            eventManager.AddEvent(e);
        }
    }
    public void ExitMonth()
    {
        
    }
}
