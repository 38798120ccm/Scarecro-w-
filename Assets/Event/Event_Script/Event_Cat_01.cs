using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event_Cat_01 : Event
{
    [SerializeField] Event Cat_02;
    [SerializeField] Animator animator;
    public override bool CheckRequirement()
    {
        return true;
    }
    public override void StartEvent()
    {
        animator.Play("Cat_01_GetInScene");
    }
    public override void DuringEvent()
    {
        animator.Play("Cat_01_Idle");
    }
    public override void EndEvent()
    {
        if(weatherManager.now_weather == Weather.Raining)
        {
            animator.Play("Cat_01_Raining");
        }
        else if(weatherManager.now_weather == Weather.Sunny)
        {
            animator.Play("Cat_01_Sunny");
        }
        
    }
    void PlayIdle()
    {
        animator.Play("Cat_01_Idle");
    }
    void End()
    {
        SceneManager.LoadScene(2);
    }
}
