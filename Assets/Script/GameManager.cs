using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;
    [SerializeField] EventManager eventManager;
    
    public bool Inanimation;
    void Start()
    {
        timeManager.StartFirstMonth();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            timeManager.NextMonth();
        }
    }
    void FixedUpdate()
    {
        if (!Inanimation)
        {
            timeManager.DuringMonth();
            eventManager.DuringEvent();
        }
    }
}
