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
    public void DuringMonth()
    {
        if(eventManager.events_list.Count != 0)
        {
            eventManager.StartEvents(eventManager.events_list[0]);
        }
    }
    public void ExitMonth()
    {
        
    }
    public void StartFirstMonth()
    {
        EnterMonth(months[0]);
    }  
    public void NextMonth()
    {
        EnterMonth(months[months.IndexOf(now)+1]);
    }
}
