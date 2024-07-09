using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] List<Month> months;
    public Month now;
    void EnterMonth(Month month)
    {
        now = month;
    }
    void ExitMonth()
    {
        
    }
    public void ToMonth(Month month)
    {
        EnterMonth(month);
    }
}
