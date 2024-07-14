using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public Weather now_weather;
    [SerializeField] TimeManager timeManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] List<MovableCloud> movableClouds;
    [SerializeField] Color raining_color, snowy_color, sunny_color, cloudy_color, lightning_color;

    [SerializeField] GameObject snowy_particle;
    [SerializeField] GameObject raining_particle;
    [SerializeField] GameObject sceneObjects;
    
    public void WeatherUpdata()
    {
        foreach(MovableCloud cloud in movableClouds)
        {
            cloud.UIUpdata();
        }
    }
    public void ObjectsToColor(Color color)
    {
        Component[] sr = sceneObjects.GetComponentsInChildren( typeof(SpriteRenderer), true );
        foreach(SpriteRenderer spriteRenderer in sr)
        {
            spriteRenderer.color = color;
        }
    }
    public void ChangeWeather(Weather weather)
    {   
        raining_particle.SetActive(false);
        snowy_particle.SetActive(false);
        foreach(MovableCloud Cloud in movableClouds)
        {
            Cloud.ReSetCloud();
        }
        switch (weather)
        {
            case Weather.Raining:
                if(timeManager.now.season == Season.Winter)
                {
                    Snowy();
                }
                else
                {
                    Rain();
                }
                break;
            case Weather.Cloudy:
                Cloudy();
                break;
            case Weather.Sunny:
                Sunny();
                break;
            case Weather.Snowy:
                Snowy();
                break;
            case Weather.Lightning:
                Lightning();
                break;
        }
        now_weather = weather;
        if(!gameManager.Inputed) return;
        timeManager.ExitMonth();
    }
    public Color WeatherColor()
    {
        switch (now_weather)
        {
            case Weather.Raining:
                return raining_color;
            case Weather.Cloudy:
                return cloudy_color;
            case Weather.Sunny:
                return sunny_color;
            case Weather.Snowy:
                return snowy_color;
            case Weather.Lightning:
                return lightning_color;
        } 
        return sunny_color;
    }
    public void Cloudy()
    {
        ObjectsToColor(cloudy_color);
        movableClouds[0].EnableCloud();
    }
    public void Rain()
    {
        ObjectsToColor(raining_color);
        raining_particle.SetActive(true);
        movableClouds[1].EnableCloud();
    }
    public void Sunny()
    {
        ObjectsToColor(sunny_color);
    }
    public void Snowy()
    {
        ObjectsToColor(snowy_color);
        snowy_particle.SetActive(true);
        movableClouds[1].EnableCloud();
    }
    public void Lightning()
    {
        ObjectsToColor(lightning_color);
        raining_particle.SetActive(true);
        movableClouds[2].EnableCloud();
    }
}
public enum Weather
{
    Raining,
    Sunny,
    Snowy,
    Lightning,
    Cloudy
}
