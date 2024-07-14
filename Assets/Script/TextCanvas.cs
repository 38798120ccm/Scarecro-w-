using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCanvas : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;
    void NextMonth()
    {
        timeManager.NextMonth();
    }
    void FalseInanimation()
    {
        timeManager.FalseInanimation();
    }
}
