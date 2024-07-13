using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;
    [SerializeField] EventManager eventManager;
    [SerializeField] WeatherManager weatherManager;
    [SerializeField] CameraManager cameraManager;
    
    public bool Inanimation;
    public bool IsPause;
    void Start()
    {
        timeManager.StartFirstMonth();
    }
    void Update()
    {
        if (!Inanimation)
        {
            weatherManager.WeatherUpdata();
        }
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
    public void SetInanimationFalse()
    {
        Inanimation = false;
    }
}
