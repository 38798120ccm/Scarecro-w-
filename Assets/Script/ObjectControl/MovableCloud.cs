using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCloud : MonoBehaviour
{
    bool startDrag;
    Vector2 startPos;
    public float posYlimit;
    public float posYavailable;

    bool canMove = true;

    bool detected;

    void Start() {
        startPos = transform.position;
    }

    public void StartDragUI() {
        if (detected) {
            return;
        }
        startDrag = true;
    }

    public void StopDragUI() {
        if (detected) {
            return;
        }
        startDrag = false;

        if (transform.position.y <= posYavailable) {
            // Call method
            Debug.Log("Object is in the area!");
            canMove = false;
            detected = true;
            return;
        }

        transform.position = startPos;
    }
    public void UIUpdata()
    {
        if (startDrag) {
            Vector3 mousePos = Input.mousePosition;
            // Debug.Log("mousePos Y: " + mousePos.y);
            // Debug.Log("new mousePos Y: " + Camera.main.);
            if (mousePos.y <= startPos.y && mousePos.y >= posYlimit && canMove) {
                // Debug.Log("transform position: " + transform.position);
                // Debug.Log("Mouse position: " + Input.mousePosition);
                transform.position = new Vector2(transform.position.x, mousePos.y);
            }
        }
    }
    

}