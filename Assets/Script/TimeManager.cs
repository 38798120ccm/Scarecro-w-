using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] List<Month> months;
    public Month now;
    public void EnterMonth(Month month)
    {
        now = month;
    }
    public void ExitMonth()
    {
        
    }
}
