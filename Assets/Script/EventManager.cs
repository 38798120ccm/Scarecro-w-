using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [SerializeField] Vector3 instantiatept;
    public List<Event> events_list;
    [SerializeField] Text S_talk_text;
    [SerializeField] Text screen_text;
    [SerializeField] GameObject house;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] TimeManager timeManager;
    [SerializeField] WeatherManager weatherManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform sceneObjects;
    [SerializeField] Animator UI_Animator;
    [SerializeField] Animator S_Talk_Animator;
    public List<Event> events_started;
    public List<Event> events_stopping;
    public void StartEvents(Event e)
    {
        if(e.CheckRequirement() == true && gameManager.Inanimation == false)
        {
            gameManager.Inanimation = true;
            events_list.Remove(e);
            GameObject eventGameOject = Instantiate(e.gameObject, instantiatept, Quaternion.identity, sceneObjects);
            eventGameOject.GetComponent<SpriteRenderer>().color = weatherManager.WeatherColor();
            InitiateEvent(eventGameOject.GetComponent<Event>());
            eventGameOject.GetComponent<Event>().StartEvent();
            if(e.NoCamera) return;
            gameManager.ChangeCameraTarget(eventGameOject);
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
        e.weatherManager = weatherManager;
        e.S_Talk_Animator = S_Talk_Animator;
        e.UI_Animator = UI_Animator;
        e.explosion = explosion;
        e.house = house;
        e.S_talk = S_talk_text;
        e.screentext = screen_text;
        e.MonthCode = timeManager.now.monthcode;
    }
}
