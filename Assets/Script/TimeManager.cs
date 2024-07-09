using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] EventManager eventManager;
    [SerializeField] List<Month> months;
    int MonthCode;
    void EnterMonth()
    {
        
    }
    void DuringMonth()
    {

    }
    void ExitMonth()
    {
        
    }
    void ToMonth(Month month)
    {
        MonthCode = month.monthcode;
    }
}
