using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{

    // This class is for the objects
    // that can be moved by mouse.


    // Components needed:
    // Rigidbody 2D
    // XX Collider 2D (box/circle)

    Vector2 mousePos;
    Vector2 distance;

    // get Object box
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown() {
        distance = new Vector2(transform.position.x, transform.position.y) - mousePos;
    }

    void OnMouseDrag() {
        transform.position = mousePos + distance; 
        rb2D.velocity = Vector2.zero;
    }

    void OnMouseUpAsButton() {
        // Added if needed
    }


    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
