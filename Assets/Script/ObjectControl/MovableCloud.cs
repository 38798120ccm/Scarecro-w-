using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCloud : MonoBehaviour
{

    Vector3 mousePos;
    float startPosY;
    public float Ylimit;
    public float Yavailable;
    //float distance;
    // Rigidbody2D rb2d;

    bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        canMove = true;
        // rb2d = GetComponent<Rigidbody2D>();
        startPosY = transform.position.y;
        //distance = transform.position.y - mousePos.y;
    }

    void OnMouseDrag() {
        if (mousePos.y*4.5f <= startPosY && mousePos.y*4.5f >= (startPosY - Ylimit) && canMove) {
            transform.position = new Vector3(transform.position.x, mousePos.y*4.5f, 0.5f);
            // rb2d.velocity = Vector2.zero;
        }
    }

    void OnMouseUpAsButton()
    {
        // If the cloud being pulled to the area
        if (transform.position.y <= (startPosY - Ylimit) + Yavailable) {
            // call method
            Debug.Log("FUCK YOU");
            canMove = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        Debug.Log(mousePos);
    }

    // These methods are for other class calling.
    static MovableCloud instance;
    public static MovableCloud getInstance() { return instance; }

    public void wakeUp() {
        canMove = true;
    }

    

}