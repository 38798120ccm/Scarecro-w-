using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Month : MonoBehaviour
{
    public Season season;
    public int monthcode;
    public Weather weather;
    public List<Event> events_Onable;
}
public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}
