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
    [SerializeField] MovableCloud movableCloud;
    
    public bool Inanimation;
    public bool IsPause;
    void Start()
    {
        timeManager.StartFirstMonth();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            weatherManager.Rain();
        }
        if (!Inanimation)
        {
            // movableCloud.UIUpdata();
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
    public void ChangeWeather(Weather weather)
    {   

    }
    public void SetInanimationFalse()
    {
        Inanimation = false;
    }
}
