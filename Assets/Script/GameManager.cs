using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;
    [SerializeField] EventManager eventManager;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        eventManager.DuringEvent();
    }
    void Initiate()
    {

    }
}
