using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] List<Event> events_list;
    [SerializeField] List<Event> events_started;
    public void StartEvents(Event e)
    {
        if(e.CheckRequirement() == true)
        {
            events_started.Add(e);
            e.StartEvent();
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
