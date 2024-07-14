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
    [SerializeField] List<GameObject> clouds;
    public bool Inputed;
    public bool Inanimation;
    public bool IsPause;
    void Start()
    {
        cameraManager.GetComponent<Animator>().Play("Camera");
    }
    void Update()
    {
        if (!Inanimation)
        {
            cameraManager.ReCentre();
            if(eventManager.events_list.Count != 0) return;
            weatherManager.WeatherUpdata();
        }
        else if(cameraManager.TargetObjects != null)
        {
            cameraManager.moveTo();
        }
    }
    void FixedUpdate()
    {
        
        if (!Inanimation)
        {
            
            timeManager.DuringMonth();
            eventManager.DuringEvent();
        }
        else
        {
            
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
    public void EnableCloud()
    {
        foreach(GameObject cloud in clouds)
        {
            cloud.gameObject.SetActive(true);
        }
    }
}
