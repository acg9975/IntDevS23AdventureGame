using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    Throwing cannon;

    [SerializeField]
    GameObject explosionFX;

    [SerializeField]
    float force = 10;
    [SerializeField]
    float explosionForce = 10;
    [SerializeField]
    bool implosion = false;


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
        yield return new WaitForSeconds(bombTimer);
        isExploding = true ;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Explodable") && isExploding)
        {
            Rigidbody2D oRB = other.GetComponent<Rigidbody2D>();

            Vector2 difference = new Vector2(other.transform.position.x - transform.position.x, other.transform.position.y - transform.position.y);

            //check if it is an implosion, if it is, just negate the force, otherwise keep it the same
            explosionForce = (implosion) ? -explosionForce : explosionForce;
            oRB.AddForce(difference * explosionForce, ForceMode2D.Impulse);
            
        }
        if (isExploding)
        {
            Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
