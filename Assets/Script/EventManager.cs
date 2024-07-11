using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] Vector3 instantiatept;
    public List<Event> events_list;
    [SerializeField] TimeManager timeManager;
    [SerializeField] GameManager gameManager;
    public List<Event> events_started;
    public List<Event> events_stopping;
    public void StartEvents(Event e)
    {
        if(e.CheckRequirement() == true && gameManager.Inanimation == false)
        {
            gameManager.Inanimation = true;
            events_list.Remove(e);
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
    public void EndEvent(Event e)
    {
        if(gameManager.Inanimation == false)
        {
            gameManager.Inanimation = true;
            events_started.Remove(e);
            events_stopping.Remove(e);
            e.EndEvent();
        }
    }
    public void AddEvent(Event e)
    {   
        events_list.Add(e);
    }
    public void InitiateEvent(Event e)
    {
        e.eventManager = this;
        e.gameManager = gameManager;
        e.timeManager = timeManager;
        e.MonthCode = timeManager.now.monthcode;
    }
}
