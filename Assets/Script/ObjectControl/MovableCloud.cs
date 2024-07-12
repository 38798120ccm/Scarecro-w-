using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCloud : MonoBehaviour
{

    Vector2 mousePos;
    float startPosY;
    public float Ylimit;
    public float Yavailable;
    //float distance;
    Rigidbody2D rb2d;

    bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        canMove = true;
        rb2d = GetComponent<Rigidbody2D>();
        startPosY = transform.position.y;
        //distance = transform.position.y - mousePos.y;
    }

    void OnMouseDrag() {
        if (mousePos.y <= startPosY && mousePos.y >= (startPosY - Ylimit) && canMove) {
            transform.position = new Vector2(transform.position.x, mousePos.y);
            rb2d.velocity = Vector2.zero;
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
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // These methods are for other class calling.
    static MovableCloud instance;
    public static MovableCloud getInstance() { return instance; }

    public void wakeUp() {
        canMove = true;
    }

    

}