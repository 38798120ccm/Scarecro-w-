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
        animator.Play("Meteor_FallDown");
    }
    public override void DuringEvent()
    {

    }
    public override void EndEvent()
    {
        SetInanimationFalse();
    }
}
