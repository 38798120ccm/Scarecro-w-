using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] List<Month> months;
    [SerializeField] GameManager gameManager;
    [SerializeField] WeatherManager weatherManager;
    [SerializeField] EventManager eventManager;
    public Month now;
    public void EnterMonth(Month month)
    {
        gameManager.Inputed = false;
        now = month;
        weatherManager.ChangeWeather(month.weather);
        foreach(Event e in now.events_Onable)
        {
            eventManager.AddEvent(e);
        }
    }
    public void DuringMonth()
    {
        if(eventManager.events_stopping.Count != 0)
        {
            eventManager.EndEvent(eventManager.events_started[0]);
        }
        else if(eventManager.events_list.Count != 0)
        {
            eventManager.StartEvents(eventManager.events_list[0]);
        }
        else if(gameManager.Inputed == true && eventManager.events_stopping.Count == 0 && eventManager.events_list.Count == 0)
        {
            NextMonth();
        }
    }
    public void ExitMonth()
    {
        eventManager.events_started.ForEach(i => eventManager.events_stopping.Add(i));
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
