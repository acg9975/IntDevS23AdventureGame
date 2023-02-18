using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    Throwing cannon;

    [SerializeField]
    float force = 10;
    [SerializeField]
    float explosionForce = 10;

    [SerializeField]
    float bombTimer = 3;

    bool isExploding = false;

    void Start()
    {
        transform.localScale = new Vector3(.2f, .2f, 1f);
        rb = GetComponent<Rigidbody2D>();
        cannon = GameObject.Find("Cannon").GetComponent<Throwing>();

        rb.AddForce(cannon.getTransformRight() * force, ForceMode2D.Impulse);

        StartCoroutine("bombCountdown");
    }


    IEnumerator bombCountdown()
    {
        yield return new WaitForSeconds(1);
        isExploding = true ;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Explodable") && isExploding)
        {
            Rigidbody2D oRB = other.GetComponent<Rigidbody2D>();
            oRB.AddForce(Vector2.SignedAngle( oRB.transform.position, transform.position)  * Vector2.one * explosionForce, ForceMode2D.Impulse);
            Debug.Log(Vector2.SignedAngle(oRB.transform.position, transform.position));
            
        }
        if (other.CompareTag("Pushable") && isExploding)
        {

        }

        if (isExploding)
        {
            Destroy(gameObject);
        }
    }


}
