using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] Vector3 instantiatept;
    public List<Event> events_list;
    [SerializeField] TimeManager timeManager;
    [SerializeField] List<Event> events_started;
    public bool Inanimation;
    public void StartEvents(Event e)
    {
        if(e.CheckRequirement() == true && Inanimation == false)
        {
            Inanimation = true;
            GameObject eventGameOject = Instantiate(e.gameObject,instantiatept,Quaternion.identity);
            InitiateEvent(eventGameOject.GetComponent<Event>());
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
    public void InitiateEvent(Event e)
    {
        e.eventManager = this;
        e.MonthCode = timeManager.now.monthcode;
    }
}
