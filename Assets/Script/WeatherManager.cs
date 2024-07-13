using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [SerializeField] Color raining;
    [SerializeField]GameObject raining_particle;
    [SerializeField] List <GameObject> sceneRenderer;
    
    public void ObjectsToColor(Color color)
    {
        foreach (GameObject obj in sceneRenderer)
        {
            obj.GetComponent<SpriteRenderer>().color = color;;
        }
    }
    public void Rain()
    {
        ObjectsToColor(raining);
        raining_particle.SetActive(true);
    }
}
