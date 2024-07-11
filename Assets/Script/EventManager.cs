using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] Vector3 instantiatept;
    [SerializeField] List<Event> events_list;

    [SerializeField] List<Event> events_started;
    bool StartingEvent;
    public void StartEvents(Event e)
    {
        if(e.CheckRequirement() == true)
        {
            GameObject eventGameOject = Instantiate(e.gameObject,instantiatept,Quaternion.identity);
            eventGameOject.GetComponent<Event>().StartEvent();
        }
    }
    public void DuringEvent()
    {
        foreach(Event e in events_started)
        {
            e.DuringEvent();
        }
    }
    public void AddEvent(Event e)
    {   
        events_list.Add(e);
    }
}
