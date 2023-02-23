using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areadetection : MonoBehaviour
{
    [SerializeField]
    int boxes = 0;
    [SerializeField]
    int maxBoxes = 3;
    [SerializeField]
    GameObject PlatformToMove;

    //once the box script hits this, it causes something to happen. 
    // a counter that if it hits the threshold, it causes something to happen.
    // a separate platform that lerps to a position.


    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }

    private void movePlatform()
    {
        if (boxes >= maxBoxes)
        {
            PlatformToMove.GetComponent<moveablePlatScript>().changeCanMove(true);
        }
    }

    public void addBoxtoArea()
    {
        boxes++;
    }

    public void removeBoxtoArea()
    {
        boxes--;
    }



}