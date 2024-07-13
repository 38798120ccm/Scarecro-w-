using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;
    [SerializeField] EventManager eventManager;
    [SerializeField] CameraManager cameraManager;
    [SerializeField] Animator Weather_Animator;
    
    public bool Inanimation;
    void Start()
    {
        timeManager.StartFirstMonth();
    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        
        if (!Inanimation)
        {
            cameraManager.ReCentre();
            timeManager.DuringMonth();
            eventManager.DuringEvent();
        }
        else
        {
            cameraManager.moveTo();
        }
    }
    public void ChangeCameraTarget(GameObject target)
    {
        cameraManager.TargetObjects = target;
    }
    public void ChangeWeather(Weather weather)
    {   
        string An_name = "";
        switch (weather)
        {
            case Weather.Cloudy:
                An_name = "";
                break;
            case Weather.Raining:
                An_name = "";
                break;
        }
        Inanimation = true;
        Weather_Animator.Play(An_name);
        timeManager.now.weather = weather;
    }
    public void SetInanimationFalse()
    {
        Inanimation = false;
    }
}
