using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovableCloud : MonoBehaviour
{
    [SerializeField] Weather weather;
    [SerializeField] GameManager gameManager;
    [SerializeField] WeatherManager weatherManager;
    [SerializeField] RectTransform rectTransform;
    RectTransform rect;
    bool startDrag;
    Vector2 startPos;
    float posYlimit;
    float posYavailableDown;
    float posYavailableUp;
    float posYFixed;

    bool enable = false;

    void Awake() {
        rect = GetComponent<RectTransform>();
        posYlimit = 110;
        posYavailableDown = 130;
        posYavailableUp = 160;
        posYFixed = 130;
        startPos = rect.anchoredPosition;
    }

    public void StartDragUI() {
        startDrag = true;
    }

    public void StopDragUI() {
        startDrag = false;
        if (enable == false)
        {
            if (rect.anchoredPosition.y <= posYavailableDown) 
            {
            // Call method
            gameManager.Inputed = true;
            weatherManager.ChangeWeather(weather);
            Debug.Log("Object is in the area! Down");
            EnableCloud();
            return;
            }
            rect.anchoredPosition = startPos;
        }
        if (enable == true)
        {
            if(rect.anchoredPosition.y >= posYavailableUp)
            {
                gameManager.Inputed = true;
                weatherManager.ChangeWeather(Weather.Sunny);
                Debug.Log("Object is in the area! Up");
                return;
            }
            rect.anchoredPosition = new Vector2(startPos.x, posYFixed);
        }
        
    }
    public void UIUpdata()
    {
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, Camera.main, out mousePos);
        if (startDrag) {
            // Debug.Log("mousePos Y: " + mousePos.y);
            // Debug.Log("new mousePos Y: " + Camera.main.);
            if (mousePos.y <= startPos.y && mousePos.y >= posYlimit) {
                // Debug.Log("transform position: " + transform.position);
                // Debug.Log("Mouse position: " + Input.mousePosition);
                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, mousePos.y);
            }
        }
    }
    public void ReSetCloud()
    {
        enable = false;
        rect.anchoredPosition = startPos;
    }
    public void EnableCloud()
    {
        enable = true;
        rect.anchoredPosition = new Vector2(startPos.x, posYFixed);
    }
}