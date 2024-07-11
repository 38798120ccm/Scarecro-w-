using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager plugin;
    public ObjectItem[] TargetObjects;

    public Vector3 offset;

    //float startTime;
    //float journeyLength;
    //Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        plugin = this;
        //startTime = Time.time;
        //startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveToCat();
    }

    public void moveTo(string name) {

        ObjectItem s = Array.Find(TargetObjects, x => x.name == name);
        if (s == null) {
            Debug.Log("Target is not found!");
            return;
        }

        if (!s.canMove) {
            return;
        }

        //transform.position = Vector3.Lerp(transform.position, s.transform.position, 0.001f);
        float step = s.speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, s.transform.position + offset, step);

        // Distance moved equals elapsed time times speed..
        //float distCovered = (Time.time - startTime) * s.speed;

        // Fraction of journey completed equals current distance divided by total distance.
        //float fractionOfJourney = distCovered / Vector3.Distance(startPos, s.transform.position + offset);

        // Set our position as a fraction of the distance between the markers.
        //transform.position = Vector3.Lerp(startPos, s.transform.position + offset, 0.001f);

        //if (transform.position == (s.transform.position + offset)) {
        //    s.canMove = false;
        //}

    }



    // Testing method
    public void moveToCat() {
        moveTo("cat");
    }

    public void cancelCatMove() {
        ObjectItem s = Array.Find(TargetObjects, x => x.name == name);
        if (s == null) {
            Debug.Log("Target is not found!");
            return;
        }

        s.canMove = false;
    }
}
