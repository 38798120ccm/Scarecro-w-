using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Meteor_01 : Event
{
    [SerializeField] Animator animator;
    
    public override bool CheckRequirement()
    {
        return true;
    }
    public override void StartEvent()
    {
        animator.Play("RollingMeteor");
    }
    public override void DuringEvent()
    {

    }
    public override void EndEvent()
    {
        if(weatherManager.now_weather == Weather.Raining)
        {
            animator.Play("Meteor_02");
        }
        else
        {
            text_num = 25;
            animator.Play("Meteor_03");
        }
    }

    public void Explosion()
    {
        Destroy(house);
        explosion.Play();
    }
}
