using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class CycleMovingObject : MonoBehaviour
{

    // can be extended

    // First Destination X & Y
    public float des1X;
    public float des1Y;
    
    // Second Destination X & Y
    // (Start Position)
    public float des2X;
    public float des2Y;
    

    // Moving speed
    public float speed;

    // Freeze time after arriving the destination
    public int freeze;

    // Rigidbody
    Rigidbody2D rb2d;

    // Start position
    float startX;
    float startY;

    Vector3 destination1;
    Vector3 destination2;

    bool onMove;


    // Start is called before the first frame update
    void Start()
    {
        onMove = false;
        destination1 = new Vector3(des1X, des1Y, 0);
        destination2 = new Vector3(des2X, des2Y, 0);

        rb2d = GetComponent<Rigidbody2D>();

        startX = transform.position.x;
        startY = transform.position.y;  

        //Move();

    }


//var t = 1 / ((transform.position - destination1).magnitude);
//gameObject.transform.position = Vector3.Lerp(transform.position, destination1, t*0.01f);

    // Update is called once per frame
    void FixedUpdate()
    {

        // rb2d.MovePosition(transform.position + Vector3.right * Time.fixedDeltaTime);
        float step = speed * Time.deltaTime;
        if (!onMove) {
            this.transform.position = Vector3.MoveTowards(this.transform.position, destination1, step);
        } else {
            this.transform.position = Vector3.MoveTowards(this.transform.position, destination2, step);
        }

        // When reach end;
        if (transform.position == destination1 && !onMove) {
            onMove = true;
        } else if (transform.position == destination2 && onMove) {
            onMove = false;
        }
    }

    // Flip
    void Flip() {

    }














    // NIGGER

    // Moving to the destination
    [Obsolete("Deprecated")]
    void Move() {
        if ((des1X - des2X) < 0) {
            rb2d.velocity = new Vector2(speed * -1, rb2d.velocity.y);
        } else {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

    }

    [Obsolete("Deprecated")]
    void MoveNext() {
        if ((des1X - des2X) > 0) {
            rb2d.velocity = new Vector2(speed * -1, rb2d.velocity.y);
        } else {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
    }
    
    [Obsolete("Deprecated")]
    void checkPos() {
        
        if (rb2d.position.x == des1X) {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            Debug.Log("Movement paused!");
            startToMoveNext();
            return;
        }

        if (rb2d.position.x == des2X) {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            Debug.Log("Movement paused!");
            backToInitial();
        }

    }

    [Obsolete("Deprecated")]
    IEnumerator startToMoveNext() {
        Debug.Log("start");

        // task delayed
        yield return new WaitForSeconds(freeze);

        Debug.Log("end");

        MoveNext();
    }

    [Obsolete("Deprecated")]
    IEnumerator backToInitial() {
        Debug.Log("start2");

        // task delayed
        yield return new WaitForSeconds(freeze);

        Debug.Log("end2");

        Move();
    }
}
