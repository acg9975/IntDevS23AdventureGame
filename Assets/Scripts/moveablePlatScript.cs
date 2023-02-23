using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveablePlatScript : MonoBehaviour
{
    [SerializeField]
    Vector3 startPos, endPos;
    bool canMove;

    [SerializeField] [Range(0.1f, 5f)]
    float t = 1;


    private void Start()
    {
        transform.position = startPos;
    }

    public void changeCanMove(bool cm)
    {
        canMove = cm;
    }

    void Update()
    {
        lerpPos();
    }

    private void lerpPos()
    {
        if (canMove)
        {
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, endPos.x, Time.deltaTime * t), Mathf.Lerp(transform.position.y, endPos.y, t * Time.deltaTime));
        }


    }
}
