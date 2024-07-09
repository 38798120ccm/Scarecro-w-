using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Month : ScriptableObject
{
    public Season season;
    public int monthcode;
    public List<Event> events_Onable;
}
public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}
