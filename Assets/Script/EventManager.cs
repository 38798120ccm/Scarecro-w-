using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    List<Event> events;
    List<Event> events_started;
    public void StartEvents()
    {
        foreach(Event e in events)
        {
            if(e.CheckRequirement() == true)
            {
                events_started.Add(e);
            }
        }
    }
    public void DuringEvent()
    {
        foreach (Event e in events_started)
        {
            if(e.CheckEndRequirement() == true)
            {
                e.EndEvent();
            }
            else
            {
                e.DuringEvent();
            }
        }
    }
}
